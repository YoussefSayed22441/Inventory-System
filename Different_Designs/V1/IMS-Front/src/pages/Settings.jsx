import { useState } from 'react';
import { motion, AnimatePresence } from 'motion/react';
import {
  Settings2,
  Bell,
  Shield,
  Globe,
  Moon,
  Languages,
  Monitor,
  Volume2,
  Mail,
  Smartphone,
  AlertTriangle,
  Trash2,
  UserX,
  Download,
  ChevronRight,
  Lock,
  Key,
  Eye,
  RefreshCw,
  Zap,
} from 'lucide-react';
import '../../styles/pages/Settings.css';

/* ── Animation variants ──────────────────────────────────────────── */
const pageVariants = {
  hidden: { opacity: 0, y: 20 },
  visible: {
    opacity: 1,
    y: 0,
    transition: {
      duration: 0.5,
      ease: [0.4, 0, 0.2, 1],
      staggerChildren: 0.1,
    },
  },
};

const childVariants = {
  hidden: { opacity: 0, y: 16 },
  visible: {
    opacity: 1,
    y: 0,
    transition: { duration: 0.4, ease: [0.4, 0, 0.2, 1] },
  },
};

const panelVariants = {
  hidden: { opacity: 0, x: 10 },
  visible: {
    opacity: 1,
    x: 0,
    transition: { duration: 0.35, ease: [0.4, 0, 0.2, 1] },
  },
  exit: {
    opacity: 0,
    x: -10,
    transition: { duration: 0.2 },
  },
};

/* ── Toggle Switch ───────────────────────────────────────────────── */
function Toggle({ id, checked, onChange }) {
  return (
    <label className="toggle-switch" htmlFor={id}>
      <input
        id={id}
        type="checkbox"
        checked={checked}
        onChange={onChange}
      />
      <span className="toggle-slider" />
    </label>
  );
}

/* ── Nav item ────────────────────────────────────────────────────── */
const NAV_ITEMS = [
  { id: 'general',       label: 'General',       icon: <Settings2 size={16} /> },
  { id: 'security',      label: 'Security',       icon: <Shield size={16} /> },
  { id: 'notifications', label: 'Notifications',  icon: <Bell size={16} />, badge: '3' },
];

/* ── General tab content ─────────────────────────────────────────── */
function GeneralPanel({ settings, onChange }) {
  return (
    <motion.div
      key="general"
      className="settings-content"
      variants={panelVariants}
      initial="hidden"
      animate="visible"
      exit="exit"
    >
      {/* Appearance */}
      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Monitor size={18} /></div>
          <div>
            <div className="settings-panel__title">Appearance</div>
            <div className="settings-panel__subtitle">Customize how the interface looks and feels</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Dark Mode</div>
            <div className="settings-row__desc">Use the dark theme across the entire application</div>
          </div>
          <Toggle id="dark-mode" checked={settings.darkMode} onChange={() => onChange('darkMode')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Compact View</div>
            <div className="settings-row__desc">Reduce spacing for higher information density</div>
          </div>
          <Toggle id="compact-view" checked={settings.compactView} onChange={() => onChange('compactView')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Animations &amp; Motion</div>
            <div className="settings-row__desc">Enable entrance animations and hover effects</div>
          </div>
          <Toggle id="animations" checked={settings.animations} onChange={() => onChange('animations')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Language</div>
            <div className="settings-row__desc">Choose your preferred interface language</div>
          </div>
          <select
            className="settings-select"
            value={settings.language}
            onChange={(e) => onChange('language', e.target.value)}
          >
            <option value="en">English (US)</option>
            <option value="ar">العربية</option>
            <option value="fr">Français</option>
            <option value="de">Deutsch</option>
          </select>
        </div>
      </div>

      {/* System */}
      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Zap size={18} /></div>
          <div>
            <div className="settings-panel__title">System</div>
            <div className="settings-panel__subtitle">Performance and behaviour settings</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Auto-save Changes</div>
            <div className="settings-row__desc">Automatically save form changes every 30 seconds</div>
          </div>
          <Toggle id="autosave" checked={settings.autoSave} onChange={() => onChange('autoSave')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Telemetry &amp; Analytics</div>
            <div className="settings-row__desc">Share anonymous usage data to improve the product</div>
          </div>
          <Toggle id="telemetry" checked={settings.telemetry} onChange={() => onChange('telemetry')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Timezone</div>
            <div className="settings-row__desc">Set the timezone for all timestamps and reports</div>
          </div>
          <select
            className="settings-select"
            value={settings.timezone}
            onChange={(e) => onChange('timezone', e.target.value)}
          >
            <option value="utc+2">UTC+2 (Cairo)</option>
            <option value="utc+0">UTC+0 (London)</option>
            <option value="utc-5">UTC-5 (New York)</option>
            <option value="utc+8">UTC+8 (Singapore)</option>
          </select>
        </div>
      </div>
    </motion.div>
  );
}

/* ── Security tab content ────────────────────────────────────────── */
function SecurityPanel({ settings, onChange }) {
  return (
    <motion.div
      key="security"
      className="settings-content"
      variants={panelVariants}
      initial="hidden"
      animate="visible"
      exit="exit"
    >
      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Lock size={18} /></div>
          <div>
            <div className="settings-panel__title">Authentication</div>
            <div className="settings-panel__subtitle">Control how you verify your identity</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Two-Factor Authentication</div>
            <div className="settings-row__desc">Require OTP code on every new login (Recommended)</div>
          </div>
          <Toggle id="tfa" checked={settings.twoFA} onChange={() => onChange('twoFA')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Biometric Login</div>
            <div className="settings-row__desc">Use fingerprint or face scan when available</div>
          </div>
          <Toggle id="biometric" checked={settings.biometric} onChange={() => onChange('biometric')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Login Alerts</div>
            <div className="settings-row__desc">Notify me via email on unrecognised sign-in attempts</div>
          </div>
          <Toggle id="login-alerts" checked={settings.loginAlerts} onChange={() => onChange('loginAlerts')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Session Duration</div>
            <div className="settings-row__desc">Automatically log out after inactivity period</div>
          </div>
          <select
            className="settings-select"
            value={settings.sessionDuration}
            onChange={(e) => onChange('sessionDuration', e.target.value)}
          >
            <option value="1h">1 Hour</option>
            <option value="8h">8 Hours</option>
            <option value="24h">24 Hours</option>
            <option value="7d">7 Days</option>
          </select>
        </div>
      </div>

      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Eye size={18} /></div>
          <div>
            <div className="settings-panel__title">Privacy</div>
            <div className="settings-panel__subtitle">Manage data visibility and access</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Profile Visibility</div>
            <div className="settings-row__desc">Allow other team members to view your profile card</div>
          </div>
          <Toggle id="profile-vis" checked={settings.profileVisible} onChange={() => onChange('profileVisible')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Activity Status</div>
            <div className="settings-row__desc">Show your online / away status to the team</div>
          </div>
          <Toggle id="activity-status" checked={settings.activityStatus} onChange={() => onChange('activityStatus')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Audit Log Access</div>
            <div className="settings-row__desc">Allow admins to review your activity history</div>
          </div>
          <Toggle id="audit-log" checked={settings.auditLog} onChange={() => onChange('auditLog')} />
        </div>
      </div>

      {/* Danger Zone */}
      <div className="glass-card danger-zone">
        <div className="danger-zone__header">
          <div className="danger-zone__icon"><AlertTriangle size={18} /></div>
          <div>
            <div className="danger-zone__title">Danger Zone</div>
            <div className="danger-zone__subtitle">Irreversible and destructive actions</div>
          </div>
        </div>

        <div className="danger-action">
          <div className="danger-action__info">
            <h4>Download My Data</h4>
            <p>Export a full archive of your account data as a .zip file</p>
          </div>
          <button type="button" className="btn-danger">
            <Download size={14} /> Export Data
          </button>
        </div>
        <div className="danger-action">
          <div className="danger-action__info">
            <h4>Reset All Preferences</h4>
            <p>Restore all settings to their factory defaults</p>
          </div>
          <button type="button" className="btn-danger">
            <RefreshCw size={14} /> Reset
          </button>
        </div>
        <div className="danger-action">
          <div className="danger-action__info">
            <h4>Deactivate Account</h4>
            <p>Temporarily disable your account — you can reactivate anytime by contacting an admin</p>
          </div>
          <button type="button" className="btn-danger">
            <UserX size={14} /> Deactivate Account
          </button>
        </div>
        <div className="danger-action">
          <div className="danger-action__info">
            <h4>Delete Account Permanently</h4>
            <p>Permanently erase all data. This action <strong>cannot</strong> be undone</p>
          </div>
          <button type="button" className="btn-danger">
            <Trash2 size={14} /> Delete Forever
          </button>
        </div>
      </div>
    </motion.div>
  );
}

/* ── Notifications tab content ───────────────────────────────────── */
function NotificationsPanel({ settings, onChange }) {
  return (
    <motion.div
      key="notifications"
      className="settings-content"
      variants={panelVariants}
      initial="hidden"
      animate="visible"
      exit="exit"
    >
      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Mail size={18} /></div>
          <div>
            <div className="settings-panel__title">Email Notifications</div>
            <div className="settings-panel__subtitle">Choose what gets sent to your inbox</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Order Status Updates</div>
            <div className="settings-row__desc">Get notified when purchase or sales orders change state</div>
          </div>
          <Toggle id="email-orders" checked={settings.emailOrders} onChange={() => onChange('emailOrders')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Low Stock Alerts</div>
            <div className="settings-row__desc">Alert when inventory items fall below reorder threshold</div>
          </div>
          <Toggle id="email-stock" checked={settings.emailStock} onChange={() => onChange('emailStock')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Weekly Summary Report</div>
            <div className="settings-row__desc">Receive a digest of key metrics every Monday at 8:00 AM</div>
          </div>
          <Toggle id="email-report" checked={settings.emailReport} onChange={() => onChange('emailReport')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Security Alerts</div>
            <div className="settings-row__desc">Immediate notification for login anomalies or permission changes</div>
          </div>
          <Toggle id="email-security" checked={settings.emailSecurity} onChange={() => onChange('emailSecurity')} />
        </div>
      </div>

      <div className="glass-panel settings-panel">
        <div className="settings-panel__header">
          <div className="settings-panel__icon"><Smartphone size={18} /></div>
          <div>
            <div className="settings-panel__title">In-App &amp; Push Notifications</div>
            <div className="settings-panel__subtitle">Real-time alerts within the dashboard</div>
          </div>
        </div>

        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Desktop Push Notifications</div>
            <div className="settings-row__desc">Show browser notifications even when the tab is inactive</div>
          </div>
          <Toggle id="push-desktop" checked={settings.pushDesktop} onChange={() => onChange('pushDesktop')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Sound Alerts</div>
            <div className="settings-row__desc">Play a subtle sound on critical system events</div>
          </div>
          <Toggle id="sound-alerts" checked={settings.soundAlerts} onChange={() => onChange('soundAlerts')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Team Mentions</div>
            <div className="settings-row__desc">Notify when a colleague tags you in a comment</div>
          </div>
          <Toggle id="mentions" checked={settings.mentions} onChange={() => onChange('mentions')} />
        </div>
        <div className="settings-row">
          <div className="settings-row__info">
            <div className="settings-row__name">Notification Frequency</div>
            <div className="settings-row__desc">How often to batch and deliver non-critical alerts</div>
          </div>
          <select
            className="settings-select"
            value={settings.notifFreq}
            onChange={(e) => onChange('notifFreq', e.target.value)}
          >
            <option value="realtime">Real-time</option>
            <option value="hourly">Hourly digest</option>
            <option value="daily">Daily digest</option>
          </select>
        </div>
      </div>
    </motion.div>
  );
}

/* ── Main component ──────────────────────────────────────────────── */
export default function Settings() {
  const [activeTab, setActiveTab] = useState('general');

  const [settings, setSettings] = useState({
    /* General */
    darkMode: true,
    compactView: false,
    animations: true,
    language: 'en',
    autoSave: true,
    telemetry: false,
    timezone: 'utc+2',
    /* Security */
    twoFA: true,
    biometric: false,
    loginAlerts: true,
    sessionDuration: '8h',
    profileVisible: true,
    activityStatus: true,
    auditLog: true,
    /* Notifications */
    emailOrders: true,
    emailStock: true,
    emailReport: false,
    emailSecurity: true,
    pushDesktop: true,
    soundAlerts: false,
    mentions: true,
    notifFreq: 'realtime',
  });

  const handleChange = (key, value) => {
    setSettings(prev => ({
      ...prev,
      [key]: value !== undefined ? value : !prev[key],
    }));
  };

  return (
    <motion.div
      className="settings-page"
      variants={pageVariants}
      initial="hidden"
      animate="visible"
    >
      {/* ── Page Header ── */}
      <motion.div className="page-header" variants={childVariants}>
        <h1 className="page-title">Settings</h1>
        <p className="page-subtitle">Configure your account, security, and notification preferences</p>
      </motion.div>

      <motion.div className="settings-layout" variants={childVariants}>
        {/* ── Side Navigation ── */}
        <div className="glass-card settings-nav">
          <div className="settings-nav__label">Preferences</div>
          {NAV_ITEMS.map(({ id, label, icon, badge }) => (
            <button
              key={id}
              type="button"
              id={`settings-nav-${id}`}
              className={`settings-nav__item${activeTab === id ? ' active' : ''}`}
              onClick={() => setActiveTab(id)}
            >
              {icon}
              {label}
              {badge && <span className="settings-nav__badge">{badge}</span>}
              {activeTab !== id && <ChevronRight size={14} style={{ marginLeft: 'auto', opacity: 0.4 }} />}
            </button>
          ))}
        </div>

        {/* ── Tab panels ── */}
        <AnimatePresence mode="wait">
          {activeTab === 'general' && (
            <GeneralPanel key="general" settings={settings} onChange={handleChange} />
          )}
          {activeTab === 'security' && (
            <SecurityPanel key="security" settings={settings} onChange={handleChange} />
          )}
          {activeTab === 'notifications' && (
            <NotificationsPanel key="notifications" settings={settings} onChange={handleChange} />
          )}
        </AnimatePresence>
      </motion.div>
    </motion.div>
  );
}
