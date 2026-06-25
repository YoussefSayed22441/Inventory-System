import { Link, useLocation } from 'react-router-dom';
import { Home, ShelvingUnit, BadgeDollarSign, FileText, ShoppingCart, Calendar, MessageSquare, Info, Users } from 'lucide-react';
import "../styles/layouts/Sidebar.css";

const navItems = [
  { name: 'Home', path: '/', icon: Home },
  { name: 'Inventory', path: '/inventory', icon: ShelvingUnit },
  { name: 'Finacnce', path: '/finance', icon: BadgeDollarSign },
  { name: 'POS', path: '/pos', icon:ShoppingCart  },
  { name: 'Suppliers', path: '/suppliers', icon:Users},
  
];

const Sidebar = () => {
  const location = useLocation();

  return (
    <aside className="sidebar">
      <nav className="sidebar-nav">
        {navItems.map((item) => {
          const Icon = item.icon;
          const isActive = location.pathname === item.path;

          return (
            <Link
              key={item.name}
              to={item.path}
              className={`sidebar-link ${isActive ? 'active' : ''}`}
            >
              <div className="sidebar-icon-container">
                <Icon 
                    size={24} 
                    strokeWidth={isActive ? 2.5 : 2} 
                    className="sidebar-icon" 
                />
              </div>
              <span className="sidebar-text">
                {item.name}
              </span>
            </Link>
          );
        })}
      </nav>
    </aside>
  );
};

export default Sidebar;
