import React from 'react';

const Transfers = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">Stock Transfers</h1>
        <p className="page-subtitle">Track and coordinate material transitions between hubs</p>
      </div>

      <div className="grid-container">
        <div className="glass-card glow-orange">
          <h3>In Transit</h3>
          <p className="stat-number">5</p>
          <span className="stat-trend orange">3 arriving today</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Completed Transfers</h3>
          <p className="stat-number">48</p>
          <span className="stat-trend green">+12 this week</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Avg. Transit Duration</h3>
          <p className="stat-number">1.4d</p>
          <span className="stat-trend blue">Within nominal range</span>
        </div>
      </div>

      <div className="glass-panel">
        <h2>Stock Relocation Queue</h2>
        <div style={{ marginTop: '16px', padding: '24px', background: 'rgba(0,0,0,0.1)', borderRadius: '12px', border: '1px dashed var(--glass-border)' }}>
          <p style={{ color: 'var(--text-muted)', textAlign: 'center' }}>
            Loading internal warehouse stock transfers...
          </p>
        </div>
      </div>
    </div>
  );
};

export default Transfers;
