import React, { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa'; 
import logo from '../../Assests/logo.png';
import './Login.css';

const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleUsernameChange = (event) => {
    setUsername(event.target.value);
  };

  const handlePasswordChange = (event) => {
    setPassword(event.target.value);
  };

  const isFormValid = () => {
    // Check if username and password are not empty
    if (username.trim() === '' || password.trim() === '') {
      return false;
    }

    // Password validation
    const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+{};:'",<.>/?]).{8,}$/;
    return passwordRegex.test(password);
  };

  return (
    <div className="login-page">
      <div className="logo">
        <img src={logo} alt="Website Logo" />
      </div>
      <div className="login-form">
        <h2>Login</h2>
        <div className="form-group">
          <label htmlFor="username">
          <FaUser />Username:</label>
          <input
            type="text"
            id="username"
            value={username}
            onChange={handleUsernameChange}
            placeholder="Enter your username"
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">
            <FaLock/> Password:</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={handlePasswordChange}
            placeholder="Enter your password"
          />
        </div>
        <button className="btn btn-primary" disabled={!isFormValid()}>
          Login
        </button>
      </div>
    </div>
  );
};

export default Login;
