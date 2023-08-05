import React, { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa';
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
    const isUsernameValid = username.trim() !== '';
    const isPasswordValid = password.trim() !== '';

    return isUsernameValid && isPasswordValid;
  };

  const handleLoginClick = () => {
    if (isFormValid()) {
      // Perform login action here (e.g., API call, authentication)
      alert('Logged in successfully!');
    } else {
      alert('Please fill in all fields.');
    }
  };

  return (
    <div className="login-page">
      <div className="login-form">
        <h2>Login</h2>
        <div className="form-group">
          <label htmlFor="username" className="icon-input">
            UserName
            <FaUser />
            <input
              type="text"
              id="username"
              value={username}
              onChange={handleUsernameChange}
              placeholder="Username"
            />
          </label>
        </div>
        <div className="form-group">
          <label htmlFor="password" className="icon-input">
            Password
            <FaLock />
            <input
              type="password"
              id="password"
              value={password}
              onChange={handlePasswordChange}
              placeholder="Password"
            />
          </label>
        </div>
        <button className="btn btn-primary" onClick={handleLoginClick} disabled={!isFormValid()}>
          Login
        </button>
      </div>
    </div>
  );
};

export default Login;
