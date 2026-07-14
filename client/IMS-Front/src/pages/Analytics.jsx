import React, { useState, useEffect, useMemo, useRef, useCallback } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { motion } from 'motion/react';
import { fetchProducts } from '../store/inventorySlice';
import { fetchNotifications } from '../store/notificationSlice';
import { TrendingUp, Activity, Database, AlertCircle, BarChart3, Radio } from 'lucide-react';
import '../styles/pages/Analytics.css';

/* ─── Mock Data Generators for Dashboard Elements ──────────────────── */

import { fetchStockHistory } from '../store/stockHistorySlice';

/* ─── Formatters ───────────────────────────────────────────────────── */
const fmt$ = (n) =>
{
  if (n >= 1_000_000) return `$${(n / 1_000_000).toFixed(2)}M`;
  if (n >= 1_000) return `$${(n / 1_000).toFixed(1)}K`;
  return `$${(n || 0).toFixed(0)}`;
};

/* ══════════════════════════════════════════════════════════════════
   1. HERO METRIC (Sparkline)
   ══════════════════════════════════════════════════════════════════ */
const HeroMetric = ({ totalValue }) =>
{
  const SVGW = 340, SVGH = 160;

  // Create a gentle upward curving sparkline
  const pts = [
    [0, 140], [60, 130], [120, 100], [180, 110],
    [240, 70], [300, 50], [340, 20]
  ];

  let lineD = `M ${pts[0][0]} ${pts[0][1]}`;
  for (let i = 1; i < pts.length; i++)
  {
    const prev = pts[i - 1], curr = pts[i];
    const cpX = (prev[0] + curr[0]) / 2;
    lineD += ` C ${cpX} ${prev[1]}, ${cpX} ${curr[1]}, ${curr[0]} ${curr[1]}`;
  }
  const areaD = `${lineD} L 340 160 L 0 160 Z`;

  return (
    <motion.div
      className="bento-panel panel-hero"
      initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: 0.1 }}
    >
      <div className="panel-header">
        <Database size={16} className="text-secondary" />
        <span>NET INVENTORY VALUE</span>
      </div>
      <div className="hero-content">
        <h2 className="hero-value">{fmt$(totalValue)}</h2>
        <div className="hero-trend">
          <TrendingUp size={14} className="text-primary" />
          <span className="text-primary">+12.4%</span>
          <span className="text-muted" style={{ marginLeft: 6 }}>vs last month</span>
        </div>
      </div>
      <div className="sparkline-wrap">
        <svg viewBox={`0 0 ${SVGW} ${SVGH}`} className="spark-svg">
          <defs>
            <linearGradient id="hero-grad" x1="0" y1="0" x2="0" y2="1">
              <stop offset="0%" stopColor="#2F80FF" stopOpacity="0.4" />
              <stop offset="100%" stopColor="#2F80FF" stopOpacity="0.0" />
            </linearGradient>
            <filter id="hero-glow">
              <feGaussianBlur stdDeviation="4" result="coloredBlur" />
              <feMerge><feMergeNode in="coloredBlur" /><feMergeNode in="SourceGraphic" /></feMerge>
            </filter>
          </defs>
          <path d={areaD} fill="url(#hero-grad)" />
          <motion.path
            d={lineD} fill="none" stroke="#2F80FF" strokeWidth="3" filter="url(#hero-glow)"
            initial={{ pathLength: 0 }} animate={{ pathLength: 1 }} transition={{ duration: 1.5, ease: "easeInOut" }}
          />
        </svg>
      </div>
    </motion.div>
  );
};

/* ══════════════════════════════════════════════════════════════════
   2. VELOCITY TRACKER (Mixed Combination Chart)
   ══════════════════════════════════════════════════════════════════ */
const MONTHS = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

const VelocityTracker = ({ stockHistory }) =>
{
  const { INBOUND, OUTBOUND } = useMemo(() => {
    const inbound = new Array(12).fill(0);
    const outbound = new Array(12).fill(0);
    const currentYear = new Date().getFullYear();
    stockHistory.forEach((tx) => {
      if (!tx.createdAt) return;
      const d = new Date(tx.createdAt);
      if (d.getFullYear() === currentYear) {
        if (tx.type === 0) inbound[d.getMonth()] += tx.quantity;
        if (tx.type === 1) outbound[d.getMonth()] += tx.quantity;
      }
    });
    return { INBOUND: inbound, OUTBOUND: outbound };
  }, [stockHistory]);

  const CW = 800, CH = 260;
  const PAD = { t: 30, r: 20, b: 30, l: 40 };
  const IW = CW - PAD.l - PAD.r, IH = CH - PAD.t - PAD.b;
  let maxVal = Math.max(...INBOUND, ...OUTBOUND) * 1.1;
  if (maxVal === 0) maxVal = 100;

  const barW = (IW / 12) * 0.35;
  const gap = (IW / 12);

  // Bezier for rolling average
  const avg = INBOUND.map((v, i) => (v + OUTBOUND[i]) * 0.55);
  let lineD = `M ${PAD.l + gap / 2} ${PAD.t + IH - (avg[0] / maxVal) * IH}`;
  for (let i = 1; i < 12; i++)
  {
    const x1 = PAD.l + gap * (i - 0.5), y1 = PAD.t + IH - (avg[i - 1] / maxVal) * IH;
    const x2 = PAD.l + gap * (i + 0.5), y2 = PAD.t + IH - (avg[i] / maxVal) * IH;
    const cpX = (x1 + x2) / 2;
    lineD += ` C ${cpX} ${y1}, ${cpX} ${y2}, ${x2} ${y2}`;
  }

  return (
    <motion.div
      className="bento-panel panel-velocity"
      initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: 0.2 }}
    >
      <div className="panel-header space-between">
        <div style={{ display: 'flex', gap: 10, alignItems: 'center' }}>
          <BarChart3 size={16} className="text-primary" />
          <span>VELOCITY TRACKER</span>
        </div>
        <div className="velocity-legend">
          <span><div className="dot" style={{ background: '#2F80FF' }} /> Inbound</span>
          <span><div className="dot" style={{ background: 'rgba(255,107,0,0.5)' }} /> Outbound</span>
          <span><div className="line-dash" /> Moving Avg</span>
        </div>
      </div>
      <svg viewBox={`0 0 ${CW} ${CH}`} className="velocity-svg">
        <defs>
          <filter id="vel-glow"><feGaussianBlur stdDeviation="3" result="b" /><feMerge><feMergeNode in="b" /><feMergeNode in="SourceGraphic" /></feMerge></filter>
        </defs>

        {/* Grid */}
        {[0, 0.5, 1].map(pct =>
        {
          const y = PAD.t + IH - IH * pct;
          return (
            <g key={pct}>
              <line x1={PAD.l} y1={y} x2={CW - PAD.r} y2={y} stroke="rgba(255,255,255,0.05)" />
              <text x={PAD.l - 8} y={y + 4} fill="rgba(255,255,255,0.3)" fontSize="11" textAnchor="end">{Math.round(maxVal * pct)}</text>
            </g>
          )
        })}

        {/* Bars */}
        {MONTHS.map((m, i) =>
        {
          const cx = PAD.l + gap * (i + 0.5);
          const inH = (INBOUND[i] / maxVal) * IH;
          const outH = (OUTBOUND[i] / maxVal) * IH;
          return (
            <g key={m}>
              <text x={cx} y={CH - 5} fill="rgba(255,255,255,0.3)" fontSize="11" textAnchor="middle">{m}</text>
              {/* Outbound Bar */}
              <motion.rect
                x={cx - barW - 2} y={PAD.t + IH - outH} width={barW} height={outH} rx="3"
                fill="rgba(255,107,0,0.4)" stroke="#FF6B00" strokeWidth="1"
                initial={{ height: 0, y: PAD.t + IH }} animate={{ height: outH, y: PAD.t + IH - outH }} transition={{ delay: 0.3 + i * 0.05 }}
              />
              {/* Inbound Bar */}
              <motion.rect
                x={cx + 2} y={PAD.t + IH - inH} width={barW} height={inH} rx="3"
                fill="rgba(47,128,255,0.4)" stroke="#2F80FF" strokeWidth="1"
                initial={{ height: 0, y: PAD.t + IH }} animate={{ height: inH, y: PAD.t + IH - inH }} transition={{ delay: 0.3 + i * 0.05 }}
              />
            </g>
          )
        })}

        {/* Avg Line */}
        <motion.path
          d={lineD} fill="none" stroke="#fff" strokeWidth="2.5" filter="url(#vel-glow)"
          initial={{ pathLength: 0 }} animate={{ pathLength: 1 }} transition={{ delay: 1, duration: 1.5 }}
        />
      </svg>
    </motion.div>
  );
};

/* ══════════════════════════════════════════════════════════════════
   3. CAPACITY RINGS (Nested Radial Bar)
   ══════════════════════════════════════════════════════════════════ */
const CapacityRings = ({ products }) =>
{
  const rings = useMemo(() => {
    if (!products || products.length === 0) return [];
    
    // Group by warehouse
    const whMap = {};
    let totalUnits = 0;
    products.forEach(p => {
      if (!whMap[p.warehouse]) whMap[p.warehouse] = 0;
      whMap[p.warehouse] += p.quantity;
      totalUnits += p.quantity;
    });

    // Create rings
    const colors = ['#FF6B00', '#2F80FF', '#00ff88', '#E62E2D'];
    const rBase = 80;
    
    return Object.keys(whMap)
      .map((whName, i) => {
        const val = totalUnits > 0 ? Math.round((whMap[whName] / totalUnits) * 100) : 0;
        return {
          name: whName || 'Unknown',
          val,
          r: rBase - (i * 20),
          c: colors[i % colors.length]
        };
      })
      .slice(0, 4); // Show top 4 max
  }, [products]);

  return (
    <motion.div
      className="bento-panel panel-rings"
      initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: 0.3 }}
    >
      <div className="panel-header">
        <Database size={16} className="text-secondary" />
        <span>CAPACITY UTILIZATION</span>
      </div>
      <div className="rings-body">
        <svg viewBox="0 0 200 200" className="rings-svg">
          {rings.map((rng, i) =>
          {
            const circ = 2 * Math.PI * rng.r;
            const dash = (rng.val / 100) * circ;
            return (
              <g key={rng.name} transform="rotate(-90 100 100)">
                <circle cx="100" cy="100" r={rng.r} fill="none" stroke="rgba(255,255,255,0.05)" strokeWidth="14" />
                <motion.circle
                  cx="100" cy="100" r={rng.r} fill="none" stroke={rng.c} strokeWidth="14"
                  strokeLinecap="round" strokeDasharray={`${dash} ${circ}`}
                  style={{ filter: `drop-shadow(0 0 6px ${rng.c}88)` }}
                  initial={{ strokeDashoffset: circ }} animate={{ strokeDashoffset: 0 }} transition={{ delay: 0.5 + i * 0.2, duration: 1.5 }}
                />
              </g>
            )
          })}
        </svg>
        <div className="rings-legend">
          {rings.map(rng => (
            <div key={rng.name} className="ring-leg-item">
              <div className="ring-leg-left">
                <div className="dot" style={{ background: rng.c, boxShadow: `0 0 8px ${rng.c}` }} />
                <span>{rng.name}</span>
              </div>
              <span style={{ color: rng.c, fontWeight: 800 }}>{rng.val}%</span>
            </div>
          ))}
        </div>
        {rings.length === 0 && (
          <div style={{ textAlign: 'center', color: 'var(--text-muted)', fontSize: '0.85rem', marginTop: '20px' }}>
            No data available
          </div>
        )}
      </div>
    </motion.div>
  );
};
/* ══════════════════════════════════════════════════════════════════
   4. ACTIVITY HEATMAP
   ══════════════════════════════════════════════════════════════════ */
const ActivityHeatmap = ({ stockHistory }) =>
{
  const heatmap = useMemo(() => {
    const data = [];
    const now = new Date();
    const map = {};

    stockHistory.forEach((tx) => {
      if (!tx.createdAt) return;
      const d = new Date(tx.createdAt).toDateString();
      map[d] = (map[d] || 0) + 1;
    });

    for (let i = 0; i < 90; i++)
    {
      const d = new Date(now);
      d.setDate(d.getDate() - (89 - i));
      const ds = d.toDateString();
      const count = map[ds] || 0;
      let intensity = 0;
      if (count > 0 && count <= 2) intensity = 1;
      else if (count > 2 && count <= 5) intensity = 2;
      else if (count > 5 && count <= 10) intensity = 3;
      else if (count > 10) intensity = 4;
      
      data.push({ date: d, val: intensity });
    }
    return data;
  }, [stockHistory]);

  // Group into weeks for grid columns (13 weeks roughly)
  const weeks = [];
  for (let i = 0; i < heatmap.length; i += 7)
  {
    weeks.push(heatmap.slice(i, i + 7));
  }

  const getColor = (val) =>
  {
    if (val === 0) return 'rgba(255,255,255,0.03)';
    if (val === 1) return 'rgba(255,107,0,0.2)';
    if (val === 2) return 'rgba(255,107,0,0.5)';
    if (val === 3) return 'rgba(255,107,0,0.8)';
    return '#FF6B00';
  };

  return (
    <motion.div
      className="bento-panel panel-heatmap"
      initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: 0.4 }}
    >
      <div className="panel-header space-between">
        <div style={{ display: 'flex', gap: 10, alignItems: 'center' }}>
          <Activity size={16} className="text-primary" />
          <span>90-DAY TRANSACTION DENSITY</span>
        </div>
        <span className="text-muted" style={{ fontSize: '0.7rem' }}>Live Tracking</span>
      </div>

      <div className="heatmap-grid-wrap">
        <div className="heatmap-grid">
          {weeks.map((week, wi) => (
            <div key={wi} className="heat-col">
              {week.map((day, di) => (
                <motion.div
                  key={di} className="heat-cell"
                  style={{
                    backgroundColor: getColor(day.val),
                    boxShadow: day.val > 3 ? '0 0 8px rgba(255,107,0,0.6)' : 'none'
                  }}
                  initial={{ scale: 0 }} animate={{ scale: 1 }} transition={{ delay: 0.5 + (wi * 0.05) }}
                  title={`${day.date.toDateString()}: Level ${day.val}`}
                />
              ))}
            </div>
          ))}
        </div>
        <div className="heatmap-legend">
          <span>Less</span>
          {[0, 1, 2, 3, 4].map(v => (
            <div key={v} className="heat-cell" style={{ backgroundColor: getColor(v), width: 10, height: 10 }} />
          ))}
          <span>More</span>
        </div>
      </div>
    </motion.div>
  );
};

/* ══════════════════════════════════════════════════════════════════
   5. LIVE ANOMALY FEED (Ticker)
   ══════════════════════════════════════════════════════════════════ */
const LiveAnomalyFeed = ({ lowStockItems }) =>
{
  // Synthesize anomalies based on low stock or randomly
  const anomalies = lowStockItems.slice(0, 8).map((p, i) => ({
    id: p.id,
    title: `Rapid Drain: ${p.name}`,
    time: `${i * 12 + 5}m ago`,
    type: i % 3 === 0 ? 'spike' : 'drop'
  }));

  return (
    <motion.div
      className="bento-panel panel-anomaly"
      initial={{ opacity: 0, y: 20 }} animate={{ opacity: 1, y: 0 }} transition={{ delay: 0.5 }}
    >
      <div className="panel-header">
        <Radio size={16} className="text-secondary pulse-icon" />
        <span>LIVE ANOMALY FEED</span>
      </div>
      <div className="anomaly-list">
        {anomalies.length > 0 ? anomalies.map((a, i) => (
          <motion.div
            key={a.id} className="anomaly-item"
            initial={{ opacity: 0, x: 20 }} animate={{ opacity: 1, x: 0 }} transition={{ delay: 0.8 + i * 0.1 }}
          >
            <div className={`anomaly-dot ${a.type}`} />
            <div className="anomaly-info">
              <span className="anomaly-title">{a.title}</span>
              <span className="anomaly-time">{a.time}</span>
            </div>
            {a.type === 'spike' ? <TrendingUp size={14} color="#00ff88" /> : <AlertCircle size={14} color="#FF6B00" />}
          </motion.div>
        )) : (
          <div style={{ textAlign: 'center', color: 'var(--text-muted)', fontSize: '0.85rem', padding: '20px 0' }}>
            No anomalies detected
          </div>
        )}
      </div>
      <div className="anomaly-footer">
        System monitoring active...
      </div>
    </motion.div>
  );
};

/* ══════════════════════════════════════════════════════════════════
   MAIN PAGE LAYOUT
   ══════════════════════════════════════════════════════════════════ */
export default function Analytics()
{
  const dispatch = useDispatch();
  const { items: products } = useSelector(s => s.inventory);
  const { items: stockHistory } = useSelector(s => s.stockHistory);

  useEffect(() =>
  {
    dispatch(fetchProducts());
    dispatch(fetchNotifications({ pageSize: 10 })); // Keep cache warm just in case
    dispatch(fetchStockHistory({ pageSize: 2000 }));
  }, [dispatch]);

  const stats = useMemo(() =>
  {
    let totalValue = 0;
    const lowStock = [];
    products.forEach(p =>
    {
      totalValue += (p.quantity * (p.sellingPrice || 0));
      if (p.quantity > 0 && p.quantity <= (p.reorderLevel || 0))
      {
        lowStock.push(p);
      }
    });
    return { totalValue, lowStock };
  }, [products]);

  return (
    <div className="bento-layout-root">
      {/* Background Glows for Deep Integration */}
      <div className="bento-ambient-glow glow-1" />
      <div className="bento-ambient-glow glow-2" />

      {/* The Bento Grid Container */}
      <div className="bento-grid">
        <HeroMetric totalValue={stats.totalValue} />
        <VelocityTracker stockHistory={stockHistory} />
        <CapacityRings products={products} />
        <ActivityHeatmap stockHistory={stockHistory} />
        <LiveAnomalyFeed lowStockItems={stats.lowStock} />
      </div>
    </div>
  );
}
