import { useState } from 'react'


import './App.css'
import temp from "../public/temp.jpg"


function App() {

  return (
    <div className='container'>
      <h1>Hold Please..., We Are Cooking🔥</h1>
      <img src={temp} />
    </div>
  )
}

export default App
