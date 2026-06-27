import React from 'react';

const StatCard = ({ icon: Icon, title, value, trend, glowVariant = 'blue' }) => {
  // Map our glowing variant classes
  const glowClass = glowVariant === 'orange' ? 'glow-orange' : 'glow-blue';

  return (
    <div className={`glass-card ${glowClass}`}>
      <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'flex-start' }}>
        <div style={{ display: 'flex', flexDirection: 'column' }}>
          <span style={{ color: 'var(--text-muted)', fontSize: '0.9rem', fontWeight: '500' }}>
            {title}
          </span>
          <p className="stat-number">{value}</p>
        </div>
        {Icon && (
          <div 
            style={{ 
              padding: '12px', 
              borderRadius: '12px', 
              background: glowVariant === 'orange' ? 'rgba(255, 107, 0, 0.1)' : 'rgba(47, 128, 255, 0.1)',
              border: `1px solid ${glowVariant === 'orange' ? 'var(--glass-border-orange)' : 'var(--glass-border-blue)'}`,
              color: glowVariant === 'orange' ? 'var(--neon-orange)' : 'var(--neon-blue-data)',
              display: 'flex',
              alignItems: 'center',
              justifycontent: 'center'
            }}
          >
            <Icon size={24} />
          </div>
        )}
      </div>

      {trend && (
        <div style={{ display: 'flex', alignItems: 'center', gap: '6px', marginTop: '12px' }}>
          <span className={`stat-trend ${trend.type || 'blue'}`}>
            {trend.text}
          </span>
          <span style={{ color: 'var(--text-muted)', fontSize: '0.8rem' }}>
            {trend.label || 'vs last month'}
          </span>
        </div>
      )}
    </div>
  );
};

export default StatCard;
