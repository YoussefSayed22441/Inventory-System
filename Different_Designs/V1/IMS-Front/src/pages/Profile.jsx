import { useState } from 'react';
import { motion } from 'motion/react';
import {
  User,
  Mail,
  Phone,
  Building2,
  MapPin,
  Calendar,
  Shield,
  Activity,
  CheckCircle2,
  Edit3,
  Save,
  Package,
  LogIn,
  FileText,
  Settings,
  Clock,
} from 'lucide-react';
import '../../styles/pages/Profile.css';

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
    transition: { duration: 0.45, ease: [0.4, 0, 0.2, 1] },
  },
};

/* ── Initial form data ───────────────────────────────────────────── */
const INITIAL_FORM = {
  fullName: 'Abdelrahman Al-Sayed',
  email: 'abdelrahman.ash@ims-corp.io',
  phone: '+20 100 234 5678',
  department: 'Systems Engineering',
  location: 'Cairo, Egypt',
  joined: 'March 12, 2022',
  employeeId: 'IMS-2022-0047',
};

/* ── Activity log ────────────────────────────────────────────────── */
const ACTIVITY = [
  { icon: <LogIn size={14} />,   action: 'Signed in from Cairo, EG',      time: '2 min ago' },
  { icon: <Package size={14} />, action: 'Updated inventory batch #INV-8812', time: '1 hr ago' },
  { icon: <FileText size={14} />,action: 'Generated Q2 Procurement Report', time: '3 hrs ago' },
  { icon: <Settings size={14} />,action: 'Changed notification preferences', time: 'Yesterday' },
  { icon: <Shield size={14} />,  action: 'Password reset completed',        time: '3 days ago' },
];

/* ── Quick stats ─────────────────────────────────────────────────── */
const STATS = [
  { value: '4.2k', label: 'Orders' },
  { value: '98%',  label: 'Accuracy' },
  { value: '3 yrs', label: 'Tenure' },
];

export default function Profile() {
  const [form, setForm]         = useState(INITIAL_FORM);
  const [isEditing, setIsEditing] = useState(false);
  const [saved, setSaved]       = useState(false);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setForm(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setIsEditing(false);
    setSaved(true);
    setTimeout(() => setSaved(false), 3000);
  };

  return (
    <motion.div
      className="profile-page"
      variants={pageVariants}
      initial="hidden"
      animate="visible"
    >
      {/* ── Page Header ── */}
      <motion.div className="page-header" variants={childVariants}>
        <h1 className="page-title">My Profile</h1>
        <p className="page-subtitle">Manage your personal information and account details</p>
      </motion.div>

      {/* ── Two-column grid ── */}
      <div className="profile-grid">

        {/* ── LEFT: ID Badge ── */}
        <motion.div className="glass-card profile-badge" variants={childVariants}>
          {/* Corner accent */}
          <div className="profile-badge__corner-bl" />

          {/* Avatar */}
          <div className="profile-avatar-wrap">
            <div className="profile-avatar">
              <span className="profile-avatar__initials">Ash</span>
            </div>
            <div className="profile-avatar-ring" />
            <div className="profile-avatar-ring profile-avatar-ring--outer" />
            <div className="profile-status-dot" title="Online" />
          </div>

          {/* Identity */}
          <div className="profile-badge__identity">
            <div className="profile-badge__username">Abdelrahman (Ash)</div>
            <div className="profile-badge__handle">@ash.sysadmin</div>
            <div className="profile-badge__role-pill">
              <span className="profile-badge__role-dot" />
              System Administrator
            </div>
          </div>

          {/* Divider */}
          <div className="profile-badge__divider" />

          {/* Quick Stats */}
          <div className="profile-stats">
            {STATS.map(({ value, label }) => (
              <div key={label} className="profile-stat">
                <div className="profile-stat__value">{value}</div>
                <div className="profile-stat__label">{label}</div>
              </div>
            ))}
          </div>

          {/* Divider */}
          <div className="profile-badge__divider" />

          {/* Meta info */}
          <div className="profile-badge__meta">
            <div className="profile-meta-row">
              <Building2 size={13} />
              <span>Systems Engineering Dept.</span>
            </div>
            <div className="profile-meta-row">
              <MapPin size={13} />
              <span>Cairo, Egypt</span>
            </div>
            <div className="profile-meta-row">
              <Calendar size={13} />
              <span>Joined March 2022</span>
            </div>
            <div className="profile-meta-row">
              <Shield size={13} />
              <span style={{ color: 'var(--neon-orange)', fontWeight: 600 }}>
                ID: IMS-2022-0047
              </span>
            </div>
            <div className="profile-meta-row">
              <Clock size={13} />
              <span>Last active: 2 min ago</span>
            </div>
          </div>
        </motion.div>

        {/* ── RIGHT: Editable Form ── */}
        <motion.div className="glass-panel profile-info" variants={childVariants}>
          <div className="profile-info__header">
            <h2 className="profile-info__title">
              <User size={18} />
              Personal Information
            </h2>
            <button
              type="button"
              className={`profile-edit-btn${saved ? ' is-saving' : ''}`}
              onClick={() => isEditing ? handleSubmit({ preventDefault: () => {} }) : setIsEditing(true)}
            >
              {saved ? (
                <><CheckCircle2 size={14} /> Saved</>
              ) : isEditing ? (
                <><Save size={14} /> Save Changes</>
              ) : (
                <><Edit3 size={14} /> Edit Profile</>
              )}
            </button>
          </div>

          <form className="profile-form" onSubmit={handleSubmit} noValidate>
            {/* Row 1 */}
            <div className="profile-form-row">
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="fullName">
                  <User size={12} /> Full Name
                </label>
                <input
                  id="fullName"
                  name="fullName"
                  className="form-input"
                  value={form.fullName}
                  onChange={handleChange}
                  disabled={!isEditing}
                  placeholder="Your full name"
                />
              </div>
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="employeeId">
                  <Shield size={12} /> Employee ID
                </label>
                <input
                  id="employeeId"
                  name="employeeId"
                  className="form-input"
                  value={form.employeeId}
                  disabled
                  placeholder="Auto-assigned"
                />
              </div>
            </div>

            {/* Row 2 */}
            <div className="profile-form-row">
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="email">
                  <Mail size={12} /> Email Address
                </label>
                <input
                  id="email"
                  name="email"
                  type="email"
                  className="form-input"
                  value={form.email}
                  onChange={handleChange}
                  disabled={!isEditing}
                  placeholder="you@company.io"
                />
              </div>
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="phone">
                  <Phone size={12} /> Phone Number
                </label>
                <input
                  id="phone"
                  name="phone"
                  type="tel"
                  className="form-input"
                  value={form.phone}
                  onChange={handleChange}
                  disabled={!isEditing}
                  placeholder="+1 000 000 0000"
                />
              </div>
            </div>

            {/* Row 3 */}
            <div className="profile-form-row">
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="department">
                  <Building2 size={12} /> Department
                </label>
                <input
                  id="department"
                  name="department"
                  className="form-input"
                  value={form.department}
                  onChange={handleChange}
                  disabled={!isEditing}
                  placeholder="Your department"
                />
              </div>
              <div className="profile-field">
                <label className="profile-field__label" htmlFor="location">
                  <MapPin size={12} /> Location
                </label>
                <input
                  id="location"
                  name="location"
                  className="form-input"
                  value={form.location}
                  onChange={handleChange}
                  disabled={!isEditing}
                  placeholder="City, Country"
                />
              </div>
            </div>

            {/* Joined (read-only) */}
            <div className="profile-field">
              <label className="profile-field__label" htmlFor="joined">
                <Calendar size={12} /> Member Since
              </label>
              <input
                id="joined"
                name="joined"
                className="form-input"
                value={form.joined}
                disabled
                placeholder="Join date"
              />
            </div>

            {/* Saved toast */}
            {saved && (
              <div className="profile-save-toast">
                <CheckCircle2 size={16} />
                Profile updated successfully. Changes are reflected immediately.
              </div>
            )}
          </form>
        </motion.div>
      </div>

      {/* ── Activity Log ── */}
      <motion.div className="glass-panel profile-activity" variants={childVariants}>
        <h2 className="profile-activity__title">
          <Activity size={17} />
          Recent Activity
        </h2>
        <ul className="profile-activity__list">
          {ACTIVITY.map(({ icon, action, time }, i) => (
            <li key={i} className="profile-activity-item">
              <div className="profile-activity-item__icon">{icon}</div>
              <span className="profile-activity-item__text">{action}</span>
              <span className="profile-activity-item__time">{time}</span>
            </li>
          ))}
        </ul>
      </motion.div>
    </motion.div>
  );
}