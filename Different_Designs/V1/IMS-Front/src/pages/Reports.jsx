import React from 'react';

const Reports = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Analytical Reports</h1>
        <p className="page-subtitle">Compile metrics, audits, and business intelligence graphs</p>
      </div>

      <div className="grid-container">
        <div className="glass-card glow-blue">
          <h3>Generated Sheets</h3>
          <p className="stat-number">34</p>
          <span className="stat-trend green">Audits verified</span>
        </div>
        <div className="glass-card glow-orange">
          <h3>Shrinkage rate</h3>
          <p className="stat-number">0.12%</p>
          <span className="stat-trend green">-0.05% improvement</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Audited SKU Ratio</h3>
          <p className="stat-number">100%</p>
          <span className="stat-trend blue">All SKUs scanned</span>
        </div>
      </div>

      <div className="glass-panel">
        <h2>Report Dashboard</h2>
        <div style={{ marginTop: '16px', padding: '24px', background: 'rgba(0,0,0,0.1)', borderRadius: '12px', border: '1px dashed var(--glass-border)' }}>
          <p style={{ color: 'var(--text-muted)', textAlign: 'center' }}>
            Loading audit summaries and charts...
          </p>
        </div>
      </div>
    </div>
  );
};

export default Reports;
