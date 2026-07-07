import React from 'react';

const PurchaseOrders = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Purchase Orders</h1>
        <p className="page-subtitle">Manage supply acquisition and purchase requisitions</p>
      </div>

      <div className="grid-container">
        <div className="glass-card glow-orange">
          <h3>Active Requests</h3>
          <p className="stat-number">8</p>
          <span className="stat-trend orange">4 pending approval</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Total Expenditure</h3>
          <p className="stat-number">$24,850</p>
          <span className="stat-trend green">-12% vs last month</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Fulfilled Orders</h3>
          <p className="stat-number">142</p>
          <span className="stat-trend blue">98.2% fulfillment rate</span>
        </div>
      </div>

      <div className="glass-panel">
        <h2>Purchase Logs</h2>
        <div style={{ marginTop: '16px', padding: '24px', background: 'rgba(0,0,0,0.1)', borderRadius: '12px', border: '1px dashed var(--glass-border)' }}>
          <p style={{ color: 'var(--text-muted)', textAlign: 'center' }}>
            Loading supply purchase logs...
          </p>
        </div>
      </div>
    </div>
  );
};

export default PurchaseOrders;
