import React, { useEffect, useRef } from 'react';
import * as THREE from 'three';

const BackgroundCanvas = () => {
  const mountRef = useRef(null);

  useEffect(() => {
    // isActive lives inside the closure — resets every time the effect runs.
    // This correctly handles BOTH React StrictMode double-mount AND Vite HMR reloads.
    let isActive = true;

    const scene = new THREE.Scene();

    const width = window.innerWidth;
    const height = window.innerHeight;
    const camera = new THREE.PerspectiveCamera(60, width / height, 0.1, 100);
    camera.position.z = 12;

    const renderer = new THREE.WebGLRenderer({ antialias: true, alpha: true });
    renderer.setSize(width, height);
    renderer.setPixelRatio(Math.min(window.devicePixelRatio, 2));

    if (mountRef.current) {
      mountRef.current.appendChild(renderer.domElement);
    }

    const ambientLight = new THREE.AmbientLight(0xffffff, 0.8);
    scene.add(ambientLight);

    // Soft radial gradient sprite texture
    const createFuzzySprite = () => {
      const canvas = document.createElement('canvas');
      canvas.width = 64;
      canvas.height = 64;
      const ctx = canvas.getContext('2d');

      const gradient = ctx.createRadialGradient(32, 32, 0, 32, 32, 32);
      gradient.addColorStop(0, 'rgba(255, 255, 255, 1)');
      gradient.addColorStop(0.2, 'rgba(255, 255, 255, 0.8)');
      gradient.addColorStop(0.5, 'rgba(255, 255, 255, 0.25)');
      gradient.addColorStop(1, 'rgba(255, 255, 255, 0)');

      ctx.fillStyle = gradient;
      ctx.fillRect(0, 0, 64, 64);

      return new THREE.CanvasTexture(canvas);
    };

    const fuzzyTexture = createFuzzySprite();

    const furBalls = [];
    const colors = [
      new THREE.Color(0xff6b00), // Neon Orange
      new THREE.Color(0x2f80ff), // Electric Blue
      new THREE.Color(0x00d2ff), // Cyan
      new THREE.Color(0x7928ca), // Purple
      new THREE.Color(0xff007a), // Magenta
    ];

    const xLimit = 9;
    const yLimit = 5;
    const numBalls = 10;

    for (let i = 0; i < numBalls; i++) {
      const radius = 1.0 + Math.random() * 1.8;
      const baseColor = colors[i % colors.length];

      const particleCount = 200;
      const geometry = new THREE.BufferGeometry();

      // Current positions (mutated each frame during split)
      const positions = new Float32Array(particleCount * 3);
      // Rest positions — the "home" shape of the ball, never mutated
      const restPositions = new Float32Array(particleCount * 3);
      // Per-particle velocities for the split explosion
      const particleVelocities = new Float32Array(particleCount * 3);
      // Per-particle explosion direction (unit vector from ball center)
      const explodeDirs = new Float32Array(particleCount * 3);

      const ptColors = new Float32Array(particleCount * 3);

      for (let j = 0; j < particleCount; j++) {
        const theta = Math.random() * Math.PI * 2;
        const phi = Math.acos(Math.random() * 2 - 1);
        const dist = radius * (0.7 + Math.random() * 0.7);

        const px = dist * Math.sin(phi) * Math.cos(theta);
        const py = dist * Math.sin(phi) * Math.sin(theta);
        const pz = dist * Math.cos(phi);

        positions[j * 3] = px;
        positions[j * 3 + 1] = py;
        positions[j * 3 + 2] = pz;

        restPositions[j * 3] = px;
        restPositions[j * 3 + 1] = py;
        restPositions[j * 3 + 2] = pz;

        // Normalize the rest position as the explosion direction
        const len = Math.sqrt(px * px + py * py + pz * pz) || 1;
        explodeDirs[j * 3] = px / len;
        explodeDirs[j * 3 + 1] = py / len;
        explodeDirs[j * 3 + 2] = pz / len;

        const brightness = 0.8 + Math.random() * 0.4;
        ptColors[j * 3] = baseColor.r * brightness;
        ptColors[j * 3 + 1] = baseColor.g * brightness;
        ptColors[j * 3 + 2] = baseColor.b * brightness;
      }

      geometry.setAttribute('position', new THREE.BufferAttribute(positions, 3));
      geometry.setAttribute('color', new THREE.BufferAttribute(ptColors, 3));

      const material = new THREE.PointsMaterial({
        size: radius * 0.35,
        map: fuzzyTexture,
        vertexColors: true,
        transparent: true,
        opacity: 0.45,
        blending: THREE.AdditiveBlending,
        depthWrite: false,
      });

      const points = new THREE.Points(geometry, material);

      const homeX = (Math.random() * 2 - 1) * xLimit;
      const homeY = (Math.random() * 2 - 1) * yLimit;
      const homeZ = -3 + Math.random() * 3;

      points.position.set(homeX, homeY, homeZ);
      scene.add(points);

      furBalls.push({
        points,
        geometry,
        homePosition: new THREE.Vector3(homeX, homeY, homeZ),
        velocity: new THREE.Vector3(0, 0, 0),
        driftOffset: Math.random() * 100,
        driftSpeed: 0.008 + Math.random() * 0.015,
        spinSpeed: (Math.random() > 0.5 ? 1 : -1) * (0.002 + Math.random() * 0.004),
        radius,
        // Split state
        restPositions,
        particleVelocities,
        explodeDirs,
        splitAmount: 0,
        isHovered: false,
      });
    }

    // Mouse tracking
    const mouse = new THREE.Vector2(-9999, -9999);
    const mouse3D = new THREE.Vector3(-9999, -9999, 0);
    const raycaster = new THREE.Raycaster();
    const planeZ = new THREE.Plane(new THREE.Vector3(0, 0, 1), 0);

    const handleMouseMove = (e) => {
      mouse.x = (e.clientX / window.innerWidth) * 2 - 1;
      mouse.y = -(e.clientY / window.innerHeight) * 2 + 1;
    };

    const handleMouseLeave = () => {
      mouse.x = -9999;
      mouse.y = -9999;
    };

    window.addEventListener('mousemove', handleMouseMove);
    window.addEventListener('mouseleave', handleMouseLeave);

    // Render loop
    const clock = new THREE.Clock();

    const animate = () => {
      // Stop scheduling new frames as soon as this effect instance is torn down
      if (!isActive) return;

      requestAnimationFrame(animate);
      const elapsed = clock.getElapsedTime();

      // Project mouse to Z = 0 plane
      if (mouse.x !== -9999) {
        raycaster.setFromCamera(mouse, camera);
        const intersectPoint = new THREE.Vector3();
        raycaster.ray.intersectPlane(planeZ, intersectPoint);
        mouse3D.copy(intersectPoint);
      }

      furBalls.forEach((ball) => {
        // A. Drifting
        const timeOffset = elapsed * ball.driftSpeed * 100 + ball.driftOffset;
        const driftForceX = Math.sin(timeOffset) * 0.008;
        const driftForceY = Math.cos(timeOffset * 0.8) * 0.008;
        ball.velocity.x += driftForceX;
        ball.velocity.y += driftForceY;

        // B. Whole-ball mouse repulsion + hover detection
        const hoverSplitRadius = ball.radius * 1.6;
        ball.isHovered = false;

        if (mouse.x !== -9999) {
          const ballFlatPos = new THREE.Vector3(ball.points.position.x, ball.points.position.y, 0);
          const distance = ballFlatPos.distanceTo(mouse3D);
          const repulsionRadius = 4.2;

          if (distance < repulsionRadius) {
            const forceDir = new THREE.Vector3().subVectors(ballFlatPos, mouse3D);
            forceDir.z = 0;
            forceDir.normalize();
            const strengthFactor = (repulsionRadius - distance) / repulsionRadius;
            ball.velocity.addScaledVector(forceDir, strengthFactor * 0.18);
          }

          if (distance < hoverSplitRadius) {
            ball.isHovered = true;
          }
        }

        // C. Return force
        const returnForce = new THREE.Vector3().subVectors(ball.homePosition, ball.points.position);
        returnForce.z = 0;
        ball.velocity.addScaledVector(returnForce, 0.008);

        // D. Friction
        ball.velocity.multiplyScalar(0.97);
        ball.points.position.add(ball.velocity);
        ball.points.position.z = ball.homePosition.z;

        // E. Spin
        ball.points.rotation.y += ball.spinSpeed;
        ball.points.rotation.x += ball.spinSpeed * 0.4;

        // F. Per-particle split explosion
        const splitTarget = ball.isHovered ? 1 : 0;
        ball.splitAmount += (splitTarget - ball.splitAmount) * 0.08;

        const posAttr = ball.geometry.attributes.position;
        const posArr = posAttr.array;
        const particleCount = posArr.length / 3;

        for (let j = 0; j < particleCount; j++) {
          const rx = ball.restPositions[j * 3];
          const ry = ball.restPositions[j * 3 + 1];
          const rz = ball.restPositions[j * 3 + 2];

          const cx = posArr[j * 3] - rx;
          const cy = posArr[j * 3 + 1] - ry;
          const cz = posArr[j * 3 + 2] - rz;

          const ex = ball.explodeDirs[j * 3];
          const ey = ball.explodeDirs[j * 3 + 1];
          const ez = ball.explodeDirs[j * 3 + 2];

          const explodeScale = ball.splitAmount * ball.radius * 2.2;
          const tx = ex * explodeScale;
          const ty = ey * explodeScale;
          const tz = ez * explodeScale;

          // Spring each particle toward its target offset
          ball.particleVelocities[j * 3] = (ball.particleVelocities[j * 3] + (tx - cx) * 0.1) * 0.75;
          ball.particleVelocities[j * 3 + 1] = (ball.particleVelocities[j * 3 + 1] + (ty - cy) * 0.1) * 0.75;
          ball.particleVelocities[j * 3 + 2] = (ball.particleVelocities[j * 3 + 2] + (tz - cz) * 0.1) * 0.75;

          posArr[j * 3] = rx + cx + ball.particleVelocities[j * 3];
          posArr[j * 3 + 1] = ry + cy + ball.particleVelocities[j * 3 + 1];
          posArr[j * 3 + 2] = rz + cz + ball.particleVelocities[j * 3 + 2];
        }

        posAttr.needsUpdate = true;

        // Fade opacity based on splitAmount
        ball.points.material.opacity = 0.45 + ball.splitAmount * 0.35;
      });

      renderer.render(scene, camera);
    };

    animate();

    // Resize handler
    const handleResize = () => {
      const w = window.innerWidth;
      const h = window.innerHeight;
      camera.aspect = w / h;
      camera.updateProjectionMatrix();
      renderer.setSize(w, h);
    };

    window.addEventListener('resize', handleResize);

    // Cleanup — runs on StrictMode unmount AND on HMR reload AND on real unmount
    return () => {
      isActive = false; // stops the RAF loop immediately at next frame check
      window.removeEventListener('mousemove', handleMouseMove);
      window.removeEventListener('mouseleave', handleMouseLeave);
      window.removeEventListener('resize', handleResize);

      // Safely remove only the canvas we added (not innerHTML wipe which can race)
      if (mountRef.current && renderer.domElement.parentNode === mountRef.current) {
        mountRef.current.removeChild(renderer.domElement);
      }

      fuzzyTexture.dispose();
      scene.traverse((obj) => {
        if (obj.geometry) obj.geometry.dispose();
        if (obj.material) {
          if (Array.isArray(obj.material)) {
            obj.material.forEach((m) => m.dispose());
          } else {
            obj.material.dispose();
          }
        }
      });
      renderer.dispose();
    };
  }, []);

  return (
    <div
      ref={mountRef}
      className="background-canvas"
    />
  );
};

export default BackgroundCanvas;