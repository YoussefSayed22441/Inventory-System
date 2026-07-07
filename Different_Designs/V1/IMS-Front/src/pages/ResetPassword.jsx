import { useState } from 'react';
import { motion, AnimatePresence } from 'motion/react';
import {
  KeyRound,
  Eye,
  EyeOff,
  CheckCircle2,
  XCircle,
  ArrowLeft,
  ShieldCheck,
  Lock,
} from 'lucide-react';
import '../../styles/pages/ResetPassword.css';

/* ── Animation variants ──────────────────────────────────────────── */
const pageVariants = {
  hidden: { opacity: 0, y: 20 },
  visible: {
    opacity: 1,
    y: 0,
    transition: {
      duration: 0.5,
      ease: [0.4, 0, 0.2, 1],
      staggerChildren: 0.08,
    },
  },
};

const childVariants = {
  hidden: { opacity: 0, y: 14 },
  visible: {
    opacity: 1,
    y: 0,
    transition: { duration: 0.4, ease: [0.4, 0, 0.2, 1] },
  },
};

/* ── Password strength logic ─────────────────────────────────────── */
function getStrength(pwd) {
  const checks = {
    length:  pwd.length >= 8,
    upper:   /[A-Z]/.test(pwd),
    number:  /[0-9]/.test(pwd),
    special: /[^A-Za-z0-9]/.test(pwd),
  };
  const score = Object.values(checks).filter(Boolean).length;

  const meta = {
    0: { label: '',       color: 'transparent',            hint: '' },
    1: { label: 'Weak',   color: 'var(--color-danger)',    hint: 'Very easy to guess' },
    2: { label: 'Fair',   color: 'var(--color-warning)',   hint: 'Could be stronger' },
    3: { label: 'Good',   color: 'var(--neon-blue-data)',  hint: 'Almost there!' },
    4: { label: 'Strong', color: 'var(--color-success)',   hint: 'Great password!' },
  };

  return { checks, score, ...meta[score] };
}

/* ── Eye-toggle input ────────────────────────────────────────────── */
function PasswordInput({ id, label, value, onChange, placeholder }) {
  const [visible, setVisible] = useState(false);
  return (
    <div className="rp-field">
      <label className="rp-field__label" htmlFor={id}>{label}</label>
      <div className="rp-input-wrap">
        <input
          id={id}
          className="form-input"
          type={visible ? 'text' : 'password'}
          value={value}
          onChange={onChange}
          placeholder={placeholder}
          autoComplete="new-password"
        />
        <button
          type="button"
          className="rp-eye-btn"
          onClick={() => setVisible(v => !v)}
          aria-label={visible ? 'Hide password' : 'Show password'}
        >
          {visible ? <EyeOff size={17} /> : <Eye size={17} />}
        </button>
      </div>
    </div>
  );
}

/* ── Strength bars ───────────────────────────────────────────────── */
function StrengthMeter({ password }) {
  if (!password) return null;
  const { score, label, color, hint, checks } = getStrength(password);

  const REQS = [
    { key: 'length',  text: '8+ characters' },
    { key: 'upper',   text: 'Uppercase letter' },
    { key: 'number',  text: 'Number (0-9)' },
    { key: 'special', text: 'Special character' },
  ];

  return (
    <motion.div
      className="rp-strength"
      initial={{ opacity: 0, y: -6 }}
      animate={{ opacity: 1, y: 0 }}
      exit={{ opacity: 0, y: -6 }}
      transition={{ duration: 0.25 }}
    >
      {/* Bars */}
      <div className="rp-strength__bars">
        {[0, 1, 2, 3].map(i => (
          <div
            key={i}
            className={`rp-strength__bar${i < score ? ' filled' : ''}`}
            style={{ background: i < score ? color : undefined }}
          />
        ))}
      </div>

      {/* Label & hint */}
      <div className="rp-strength__meta">
        <span className="rp-strength__label" style={{ color }}>{label}</span>
        <span className="rp-strength__hint">{hint}</span>
      </div>

      {/* Requirement checklist */}
      <div className="rp-requirements" style={{ marginTop: 10 }}>
        {REQS.map(({ key, text }) => (
          <div key={key} className={`rp-req-item${checks[key] ? ' met' : ''}`}>
            {checks[key]
              ? <CheckCircle2 size={13} />
              : <XCircle size={13} style={{ opacity: 0.35 }} />
            }
            {text}
          </div>
        ))}
      </div>
    </motion.div>
  );
}

/* ── Match indicator ─────────────────────────────────────────────── */
function MatchIndicator({ newPwd, confirmPwd }) {
  if (!confirmPwd) return null;
  const match = newPwd === confirmPwd;
  return (
    <div className={`rp-match-indicator ${match ? 'match' : 'no-match'}`}>
      {match
        ? <><CheckCircle2 size={14} /> Passwords match</>
        : <><XCircle size={14} /> Passwords do not match</>
      }
    </div>
  );
}

/* ── Main component ──────────────────────────────────────────────── */
export default function ResetPassword() {
  const [currentPwd, setCurrentPwd] = useState('');
  const [newPwd,     setNewPwd]     = useState('');
  const [confirmPwd, setConfirmPwd] = useState('');
  const [submitted,  setSubmitted]  = useState(false);
  const [error,      setError]      = useState('');

  const strength   = getStrength(newPwd);
  const canSubmit  = currentPwd.length > 0 && strength.score >= 3 && newPwd === confirmPwd;

  const handleSubmit = (e) => {
    e.preventDefault();
    setError('');

    if (!currentPwd) {
      setError('Please enter your current password.');
      return;
    }
    if (strength.score < 3) {
      setError('Your new password is not strong enough. Aim for at least "Good".');
      return;
    }
    if (newPwd !== confirmPwd) {
      setError('The new passwords do not match.');
      return;
    }

    /* Simulate success — no real network call */
    setSubmitted(true);
  };

  const handleReset = () => {
    setCurrentPwd('');
    setNewPwd('');
    setConfirmPwd('');
    setError('');
    setSubmitted(false);
  };

  return (
    <motion.div
      className="rp-page"
      variants={pageVariants}
      initial="hidden"
      animate="visible"
    >
      <motion.div className="glass-panel rp-panel" variants={childVariants}>

        <AnimatePresence mode="wait">
          {submitted ? (
            /* ── Success state ── */
            <motion.div
              key="success"
              className="rp-success"
              initial={{ opacity: 0, scale: 0.92 }}
              animate={{ opacity: 1, scale: 1 }}
              exit={{ opacity: 0 }}
              transition={{ duration: 0.4, ease: [0.4, 0, 0.2, 1] }}
            >
              <div className="rp-success__icon">
                <ShieldCheck size={34} />
              </div>
              <div className="rp-success__title">Password Updated!</div>
              <p className="rp-success__text">
                Your password has been changed successfully. All other sessions have been
                signed out for your security.
              </p>
              <button
                type="button"
                className="rp-submit-btn"
                style={{ maxWidth: 260 }}
                onClick={handleReset}
              >
                Set Another Password
              </button>
            </motion.div>

          ) : (
            /* ── Form state ── */
            <motion.div
              key="form"
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              exit={{ opacity: 0 }}
              transition={{ duration: 0.25 }}
            >
              {/* Header */}
              <div className="rp-header">
                <div className="rp-icon">
                  <KeyRound size={28} />
                </div>
                <h1 className="rp-title">Reset Password</h1>
                <p className="rp-subtitle">
                  Create a new strong password for your account.<br />
                  You'll be signed out of other sessions automatically.
                </p>
              </div>

              <div className="rp-divider" />

              {/* Form */}
              <form className="rp-form" onSubmit={handleSubmit} noValidate>

                {/* Current password */}
                <PasswordInput
                  id="current-password"
                  label="Current Password"
                  value={currentPwd}
                  onChange={e => setCurrentPwd(e.target.value)}
                  placeholder="Enter your current password"
                />

                {/* New password */}
                <PasswordInput
                  id="new-password"
                  label="New Password"
                  value={newPwd}
                  onChange={e => setNewPwd(e.target.value)}
                  placeholder="Create a strong new password"
                />

                {/* Strength meter */}
                <AnimatePresence>
                  {newPwd && (
                    <StrengthMeter key="meter" password={newPwd} />
                  )}
                </AnimatePresence>

                {/* Confirm password */}
                <PasswordInput
                  id="confirm-password"
                  label="Confirm New Password"
                  value={confirmPwd}
                  onChange={e => setConfirmPwd(e.target.value)}
                  placeholder="Repeat your new password"
                />

                {/* Match indicator */}
                <AnimatePresence>
                  {confirmPwd && (
                    <motion.div
                      key="match"
                      initial={{ opacity: 0, y: -4 }}
                      animate={{ opacity: 1, y: 0 }}
                      exit={{ opacity: 0 }}
                      transition={{ duration: 0.2 }}
                    >
                      <MatchIndicator newPwd={newPwd} confirmPwd={confirmPwd} />
                    </motion.div>
                  )}
                </AnimatePresence>

                {/* Error message */}
                {error && (
                  <div className="rp-match-indicator no-match">
                    <XCircle size={14} /> {error}
                  </div>
                )}

                {/* Submit */}
                <button
                  id="reset-password-submit"
                  type="submit"
                  className="rp-submit-btn"
                  disabled={!canSubmit}
                >
                  <Lock size={16} style={{ marginRight: 6, verticalAlign: 'middle' }} />
                  Update Password
                </button>
              </form>
            </motion.div>
          )}
        </AnimatePresence>

      </motion.div>
    </motion.div>
  );
}
