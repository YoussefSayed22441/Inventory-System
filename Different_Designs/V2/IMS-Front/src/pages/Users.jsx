import React from 'react';

const Users = () => {
  return (
    <div className="page-container">
      <div className="page-header">
        <h1 className="page-title">User Accounts</h1>
        <p className="page-subtitle">Configure system credentials, permissions, and session access</p>
      </div>

      <div className="grid-container">
        <div className="glass-card glow-blue">
          <h3>Active Workers</h3>
          <p className="stat-number">18</p>
          <span className="stat-trend green">4 currently online</span>
        </div>
        <div className="glass-card glow-blue">
          <h3>Role Distribution</h3>
          <p className="stat-number">3 Roles</p>
          <span className="stat-trend blue">Admin, Lead, Operator</span>
        </div>
        <div className="glass-card glow-orange">
          <h3>Security Alerts</h3>
          <p className="stat-number">0</p>
          <span className="stat-trend green">System integrity nominal</span>
        </div>
      </div>

      <div className="glass-panel">
        <h2>Active User Accounts Directory</h2>
        <div style={{ marginTop: '16px', padding: '24px', background: 'rgba(0,0,0,0.1)', borderRadius: '12px', border: '1px dashed var(--glass-border)' }}>
          <p style={{ color: 'var(--text-muted)', textAlign: 'center' }}>
            Loading workforce accounts registry...
          </p>
        </div>
      </div>
    </div>
  );
};

export default Users;
