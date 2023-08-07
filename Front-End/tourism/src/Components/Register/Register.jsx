import React, { useState } from 'react';
import logo from '../../Assests/logo.png';
import './Register.css'; // Create a CSS file for RegisterPage styles
import axios from 'axios';

const RegisterPage = () => {
  const [formData, setFormData] = useState({
    username: '',
    phone: '',
    email: '',
    name: '',
    userPassword: '',
    role: ''
  });

  const registerData = async () => {
    try {
      const response = await axios.post(
        'https://localhost:7290/api/Users/Register',
        formData,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      );
      console.log(response?.data);
      console.log(response);
    } catch (error) {
      console.log('Error:', error.message);
      console.log('Response data:', error.response?.data);
    }
  };

  const [passwordError, setPasswordError] = useState('');

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(formData);
  };

  const handleConfirmPassword = () => {
    if (formData.userPassword !== formData.confirmPassword) {
      return false;
    }
    return true;
  };

  const validatePassword = (password) => {
    // Use a regular expression to validate the password
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordPattern.test(password);
  };

  const handlePasswordChange = (e) => {
    const { value } = e.target;
    setFormData({
      ...formData,
      userPassword: value,
    });
    if (!validatePassword(value)) {
      setPasswordError(
        'Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.'
      );
    } else {
      setPasswordError('');
    }
  };

  return (
    <div className="register-page">
      {/* <div className="logo">
        <img src={logo} alt="Logo" />
      </div> */}
      <div className="register-form">
        <h2>Register</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label htmlFor="username">Username:</label>
            <input
              type="text"
              id="username"
              name="username"
              value={formData.username}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="phone">Phone:</label>
            <input
              type="text"
              id="phone"
              name="phone"
              value={formData.phone}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="name">Name:</label>
            <input
              type="text"
              id="name"
              name="name"
              value={formData.name}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label htmlFor="password">Password:</label>
            <input
              type="password"
              id="password"
              name="userPassword"
              value={formData.userPassword}
              onChange={handlePasswordChange}
              required
            />
            {passwordError && <span className="error">{passwordError}</span>}
          </div>
          <div className="form-group">
            <label htmlFor="confirmPassword">Confirm Password:</label>
            <input
              type="password"
              id="confirmPassword"
              name="confirmPassword"
              value={formData.confirmPassword}
              onChange={handleInputChange}
              required
            />
            {!handleConfirmPassword() && (
              <span className="error">Passwords do not match.</span>
            )}
          </div>
          <div className="form-group">
            <label htmlFor="role">Role:</label>
            <select
              id="role"
              name="role"
              value={formData.role}
              onChange={handleInputChange}
              required
            >
              <option value="User">User</option>
              <option value="Agent">Agent</option>
            </select>
          </div>
          <div className="form-group">
            <button onClick={registerData}>Register</button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default RegisterPage;
