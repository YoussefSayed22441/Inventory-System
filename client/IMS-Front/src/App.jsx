import { useState } from 'react';
import './App.css';
import { Routes, Route, useLocation, useNavigate } from "react-router-dom";

import BoxIntroAnimation from './components/ui/BoxIntroAnimation';

import Navbar from './layouts/Navbar';
import Sidebar from './layouts/Sidebar';
import BackgroundCanvas from './components/ui/BackgroundCanvas';

import NotFound from "./pages/NotFound";
import Home from './pages/Home';
import Login from './pages/Login';
import Inventory from "./pages/Inventory";
import Categories from "./pages/Categories";
import Suppliers from "./pages/Suppliers";
import PurchaseOrders from "./pages/PurchaseOrders";
import SalesOrders from "./pages/SalesOrders";
import Warehouses from "./pages/Warehouses";
import Transfers from "./pages/Transfers";
import Reports from "./pages/Reports";
import Users from "./pages/Users";
import Settings from "./pages/Settings";
import Finance from "./pages/Finance";
import Pos from "./pages/Pos";
import Profile from "./pages/Profile";

function App() {
  const location = useLocation();
  const navigate = useNavigate();
  const showLayout = location.pathname !== '/login';
  const [isMobileSidebarOpen, setIsMobileSidebarOpen] = useState(false);

  // Show the box intro only on the very first visit
  const [showIntro, setShowIntro] = useState(
    () => !localStorage.getItem('ims_intro_done')
  );

  const handleIntroComplete = () => {
    localStorage.setItem('ims_intro_done', '1');
    setShowIntro(false);
    navigate('/login');
  };

  return (
    <div className="app-container">
      <BackgroundCanvas />

      {/* First-visit box animation — renders above everything */}
      {showIntro && (
        <BoxIntroAnimation onComplete={handleIntroComplete} />
      )}
      {showLayout && (
        <Sidebar
          isOpen={isMobileSidebarOpen}
          onClose={() => setIsMobileSidebarOpen(false)}
        />
      )}

      {showLayout && isMobileSidebarOpen && (
        <div
          className="sidebar-mobile-overlay"
          onClick={() => setIsMobileSidebarOpen(false)}
        />
      )}

      <div className={showLayout ? "main-content" : "auth-content"}>
        {showLayout && (
          <Navbar
            onMenuClick={() => setIsMobileSidebarOpen(true)}
          />
        )}
        <main className="page-body">
          <Routes>
            <Route path='/' element={<Home />} />
            <Route path="/login" element={<Login />} />
            <Route path="/inventory" element={<Inventory />} />
            <Route path="/categories" element={<Categories />} />
            <Route path="/suppliers" element={<Suppliers />} />
            <Route path="/purchase-orders" element={<PurchaseOrders />} />
            <Route path="/sales-orders" element={<SalesOrders />} />
            <Route path="/warehouses" element={<Warehouses />} />
            <Route path="/transfers" element={<Transfers />} />
            <Route path="/reports" element={<Reports />} />
            <Route path="/users" element={<Users />} />
            <Route path="/settings" element={<Settings />} />
            <Route path="/finance" element={<Finance />} />
            <Route path="/pos" element={<Pos />} />
            <Route path="/profile" element={<Profile />} />
            <Route path="*" element={<NotFound />} />
          </Routes>
        </main>
      </div>
    </div>
  );
}

export default App;
