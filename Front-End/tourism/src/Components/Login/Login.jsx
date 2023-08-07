import React, { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa';
import logo from '../../Assests/logo.png';
import './Login.css';
import axios from 'axios'; // Import axios library

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

  const handleLogin = () => {
    if (isFormValid()) {
      // Create an object containing the username and password data
      const loginData = {
        username: username,
        password: password,
      };

      // Make the POST API request to the backend
      axios
        .post('https://localhost:7290/api/Users/LogIN', loginData) // Replace 'YOUR_BACKEND_API_URL' with the actual URL of your backend API
        .then((response) => {
          console.log('Login successful!');
          // Handle the response data from the backend if needed
        })
        .catch((error) => {
          console.log('Login failed:', error);
          // Handle any errors that occur during the API call
        });
    } else {
      console.log('Invalid form data.');
    }
  };

  return (
    <div className="login-page">
      {/* <div className="logo">
        <img src={logo} alt="Website Logo" />
      </div> */}
      <div className="login-form">
        <h2>Login</h2>
        <div className="form-group">
          <label htmlFor="username">
            <FaUser />Username:
          </label>
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
            <FaLock /> Password:
          </label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={handlePasswordChange}
            placeholder="Enter your password"
          />
        </div>
        <button className="btn btn-primary" onClick={handleLogin} disabled={!isFormValid()}>
          Login
        </button>
      </div>
    </div>
  );
};

export default Login;
