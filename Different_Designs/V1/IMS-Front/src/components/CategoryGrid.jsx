import React from 'react';
import { motion } from 'motion/react';
import { Search, Plus } from 'lucide-react';
import './CategoryGrid.css';

const MOCK_CATEGORIES = [
  {
    id: 1,
    title: 'Quantum Processors',
    description: 'High-frequency sub-atomic computing units capable of multi-dimensional state processing.',
    count: 42,
  },
  {
    id: 2,
    title: 'Neural Interfaces',
    description: 'Direct cortex-to-machine synaptic relays for seamless cybernetic integration and control.',
    count: 108,
  },
  {
    id: 3,
    title: 'Cybernetic Optics',
    description: 'Advanced ocular implants with augmented reality overlays and thermal scanning capabilities.',
    count: 17,
  },
  {
    id: 4,
    title: 'Cryo-Storage Units',
    description: 'Absolute-zero containment modules designed for preserving volatile biomatter and experimental tech.',
    count: 56,
  },
  {
    id: 5,
    title: 'Plasma Emitters',
    description: 'High-energy focused beam emitters used in heavy industrial cutting and tactical defense grids.',
    count: 8,
  },
  {
    id: 6,
    title: 'Synthetic Myomer',
    description: 'Artificial muscle fibers providing superhuman strength and agility for exoskeleton frames.',
    count: 312,
  },
];

// Animation variants for the staggered grid entrance
const containerVariants = {
  hidden: { opacity: 0 },
  show: {
    opacity: 1,
    transition: {
      staggerChildren: 0.1,
      delayChildren: 0.2,
    },
  },
};

const cardVariants = {
  hidden: { 
    opacity: 0, 
    scale: 0.92,
    y: 40 
  },
  show: { 
    opacity: 1, 
    scale: 1,
    y: 0,
    transition: {
      type: "tween",
      ease: [0.16, 1, 0.3, 1],
      duration: 0.8
    }
  },
};

const CategoryGrid = () => {
  return (
    <div className="category-grid-container">
      {/* Header Section */}
      <header className="category-grid-header">
        <div className="neon-search-container">
          <Search className="search-icon" />
          <input 
            type="text" 
            className="neon-search-input" 
            placeholder="Initialize query..." 
          />
        </div>
        <button className="btn-geometric">
          <Plus size={18} />
          Create Category
        </button>
      </header>

      {/* Grid Layout */}
      <motion.div 
        className="category-grid"
        variants={containerVariants}
        initial="hidden"
        animate="show"
      >
        {MOCK_CATEGORIES.map((category) => (
          <motion.div 
            key={category.id} 
            className="category-card"
            variants={cardVariants}
          >
            {/* Decorative elements */}
            <div className="card-decor-corner"></div>
            
            <div className="status-badge">
              <span className="status-badge-dot"></span>
              {category.count} ONLINE
            </div>
            
            <div className="card-content">
              <h3 className="category-title">{category.title}</h3>
              <p className="category-desc">{category.description}</p>
            </div>
            
            <div className="card-decor-line"></div>
          </motion.div>
        ))}
      </motion.div>
    </div>
  );
};

export default CategoryGrid;
