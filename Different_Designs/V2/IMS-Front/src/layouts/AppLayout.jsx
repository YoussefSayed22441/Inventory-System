import Sidebar from './Sidebar';
import Navbar from './Navbar';
import '../styles/layouts/AppLayout.css';

const AppLayout = ({ children }) => {
  return (
    <div className="app-layout">
      <Sidebar />
      <div className="app-main-wrapper">
        <Navbar />
        <main className="app-main-content">
          {children}
        </main>
      </div>
    </div>
  );
};

export default AppLayout;
