import { useState } from 'react'
import './App.css'
import { Routes, Route } from "react-router-dom";

import Navbar from './layouts/Navbar';
import Sidebar from './layouts/Sidebar';

import NotFound from "./pages/NotFound"
import Home from './pages/Home';
import Login from './pages/Login';
import Inventory from "./pages/Inventory"
import Suppliers from "./pages/Suppliers"
import Pos from "./pages/Pos"
import Finance from "./pages/Finance"
function App() {

 const showLayout = location.pathname !== '/login';

  return (
    <>
    {showLayout && <Navbar />}
    {showLayout && <Sidebar />}
    
    <Routes>
      <Route path='/' element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/inventory" element={<Inventory/>} />
      <Route path="/finance" element={<Finance/>} />
      <Route path="/pos" element={<Pos/>} />
      <Route path="/suppliers" element={<Suppliers/>} />
      <Route path="*" element={<NotFound />}/>
    </Routes>
    </>
  )
}

export default App
