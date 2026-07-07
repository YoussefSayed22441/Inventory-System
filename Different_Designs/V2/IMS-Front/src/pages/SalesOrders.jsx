import React from 'react';

const SalesOrders = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Sales Orders</h1>
        <p className="page-subtitle">Track customer sales, receipts, and order fulfillment</p>
      </div>

      <div className="grid-container">
        <div className="glass-card glow-blue">
          <h3>Open Sales</h3>
          <p className="stat-number">23</p>
          <span className="stat-trend green">+5 today</span>
        </div>
        <div className="glass-card glow-orange">
          <h3>Revenue Generated</h3>
          <p className="stat-number">$84,120</p>
          <span className="stat-trend orange">+18% growth</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Shipping Queue</h3>
          <p className="stat-number">12</p>
          <span className="stat-trend blue">Ready to pack</span>
        </div>
      </div>

      <div className="glass-panel">
        <h2>Sales Transaction Ledger</h2>
        <div style={{ marginTop: '16px', padding: '24px', background: 'rgba(0,0,0,0.1)', borderRadius: '12px', border: '1px dashed var(--glass-border)' }}>
          <p style={{ color: 'var(--text-muted)', textAlign: 'center' }}>
            Loading sales transaction ledger database...
          </p>
        </div>
      </div>
    </div>
  );
};

export default SalesOrders;
