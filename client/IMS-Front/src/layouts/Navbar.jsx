import React from 'react';
import { Menu, Boxes } from 'lucide-react';
import { useSelector } from 'react-redux';

const Navbar = ({ onMenuClick }) => {
  const { user } = useSelector((state) => state.auth);

  return (
    <nav className="mobile-navbar">
      {/* Mobile Hamburger menu */}
      <button className="nav-icon-button" onClick={onMenuClick} title="Open Navigation Menu">
        <Menu size={20} />
      </button>
      
      {/* Mobile Center Logo */}
      <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
        <Boxes size={22} color="var(--neon-orange)" />
        <span style={{ fontWeight: '800', fontSize: '1.1rem', letterSpacing: '0.5px', color: 'var(--text-pure-white)' }}>
          IMS CORE
        </span>
      </div>

      {/* Mobile Right Avatar */}
      <div className="profile-avatar" style={{ width: '32px', height: '32px', fontSize: '0.75rem' }}>
        {user?.username?.[0]?.toUpperCase() || user?.name?.[0]?.toUpperCase() || 'A'}
      </div>
    </nav>
  );
};

export default Navbar;