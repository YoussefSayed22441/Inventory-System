import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'

import ReactDOM from "react-dom/client";
import {BrowserRouter} from "react-router-dom"

import "./styles/global.css"
import "./styles/variables.css"
import "./styles/reset.css"

import App from './App.jsx'

ReactDOM.createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <App />
  </BrowserRouter>,
)
