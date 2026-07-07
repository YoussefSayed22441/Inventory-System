import React, { useState, useCallback } from 'react';
import '../../styles/BoxIntroAnimation.css';

const TOTAL_CLICKS = 4;
let _coinKey = 0;

/**
 * First-visit intro animation.
 * Shows a floating cardboard box. Each click:
 *  - pops a Mario-style coin from the top
 *  - bumps the box upward
 *  - grows the box slightly
 * After TOTAL_CLICKS the lid opens, the box spins + shrinks away,
 * then onComplete() is called.
 */
const BoxIntroAnimation = ({ onComplete }) => {
  const [clicks,      setClicks]      = useState(0);
  const [coins,       setCoins]       = useState([]);   // [{id, x}]
  const [isBouncing,  setIsBouncing]  = useState(false);
  const [isOpen,      setIsOpen]      = useState(false);
  const [isDone,      setIsDone]      = useState(false);

  const handleClick = useCallback(() => {
    if (isOpen || isDone) return;

    // Spawn a coin above the box
    const id = ++_coinKey;
    const x  = (Math.random() - 0.5) * 72;
    setCoins(prev => [...prev, { id, x }]);
    setTimeout(() => setCoins(prev => prev.filter(c => c.id !== id)), 960);

    // Bump the box upward
    setIsBouncing(true);
    setTimeout(() => setIsBouncing(false), 400);

    const next = clicks + 1;
    setClicks(next);

    if (next >= TOTAL_CLICKS) {
      // Short delay then open
      setTimeout(() => setIsOpen(true), 420);
      // Fade overlay then call onComplete
      setTimeout(() => {
        setIsDone(true);
        setTimeout(() => onComplete?.(), 680);
      }, 2600);
    }
  }, [clicks, isOpen, isDone, onComplete]);

  // Scale grows with each click (1× → ~1.7× over 4 clicks)
  const scale = (1 + clicks * 0.18).toFixed(3);

  const hints = [
    '✨  Click the box!',
    'Again!',
    'Keep going...',
    'One more!',
    '🎉  Opening...',
  ];
  const hint = hints[Math.min(clicks, TOTAL_CLICKS)];

  return (
    <div className={`bxo${isDone ? ' bxo--out' : ''}`} aria-label="First visit animation">
      {/* Animated hint text */}
      <p className="bxo__hint" key={hint}>{hint}</p>

      {/* Click target */}
      <div
        className="bxo__stage"
        onClick={handleClick}
        role="button"
        tabIndex={0}
        aria-label="Click the cardboard box to open it"
        onKeyDown={e => e.key === 'Enter' || e.key === ' ' ? handleClick() : null}
        style={{ cursor: isOpen ? 'default' : 'pointer' }}
      >
        {/* Mario-style coin popups */}
        {coins.map(({ id, x }) => (
          <span key={id} className="bxo__coin" style={{ '--x': `${x}px` }}>
            🪙
          </span>
        ))}

        {/*
          Two-layer wrapper:
          - Outer (.bxo__scale) handles the per-click scale growth
          - Inner (.bxo__anim)  handles float / bounce / spin animations
          This keeps scale and animation from fighting over the transform property.
        */}
        <div
          className="bxo__scale"
          style={{ transform: `scale(${scale})`, transformOrigin: 'center bottom' }}
        >
          <div
            className={[
              'bxo__anim',
              !isOpen && !isBouncing ? 'bxo__anim--float'  : '',
              isBouncing              ? 'bxo__anim--bounce' : '',
              isOpen                  ? 'bxo__anim--spin'   : '',
            ].filter(Boolean).join(' ')}
          >
            {/* ── BOX FACES ── */}

            {/* Top-right corner (connects lid to side) */}
            <div className="bxo__corner" />

            {/* Lid — the top face that rotates open */}
            <div className="bxo__lid-wrap">
              <div className={`bxo__lid-face${isOpen ? ' bxo__lid-face--open' : ''}`} />
            </div>

            {/* Interior top strip — visible once lid opens */}
            <div className="bxo__top-face" />

            {/* Right side face */}
            <div className="bxo__side" />

            {/* Main front face */}
            <div className="bxo__front">
              {/* Tape cross */}
              <div className="bxo__tape bxo__tape--h" />
              <div className="bxo__tape bxo__tape--v" />
              {/* Cardboard crease lines for realism */}
              <div className="bxo__crease bxo__crease--l" />
              <div className="bxo__crease bxo__crease--r" />
            </div>
          </div>
        </div>

        {/* Elliptical ground shadow */}
        <div
          className="bxo__shadow"
          style={{
            transform: `scaleX(${(scale * 0.82).toFixed(3)})`,
            opacity: isOpen ? 0 : undefined,
          }}
        />
      </div>

      {/* Click progress indicator */}
      <div className="bxo__dots" role="progressbar" aria-valuenow={clicks} aria-valuemax={TOTAL_CLICKS}>
        {Array.from({ length: TOTAL_CLICKS }).map((_, i) => (
          <div key={i} className={`bxo__dot${i < clicks ? ' bxo__dot--on' : ''}`} />
        ))}
      </div>
    </div>
  );
};

export default BoxIntroAnimation;
