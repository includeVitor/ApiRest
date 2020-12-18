import React, { useEffect } from 'react'
import './App.css'
import Routes from './route' 
import { CheckAuthentication } from "./route/CheckAuthentication"

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const App: React.FC = () => {

  useEffect(() => {
    CheckAuthentication()
  }, [])

  return (
    <div className="App">
      <Routes/>
      <ToastContainer autoClose={5000} />
    </div>
  )
}

export default App
