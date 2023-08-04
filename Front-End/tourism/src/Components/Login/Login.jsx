import React from 'react';
import logo from '../../Assests/logo.png';
import './Login.css'; 

const Login = () => {
  return (
    <div className="login-page">
      <div className="logo">
        <img src={logo} alt="Website Logo" />
      </div>
      <div className="login-form">
        <h2>Login</h2>
        <div className="form-group">
          <label htmlFor="username">Username:</label>
          <input type="text" id="username" placeholder="Enter your username" />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password:</label>
          <input type="password" id="password" placeholder="Enter your password" />
        </div>
        <button className="btn btn-primary">Login</button>
      </div>
    </div>
  );
};

export default Login;
