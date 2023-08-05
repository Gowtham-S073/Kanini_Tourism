import React, { useState } from 'react';
import logo from '../../Assests/logo.png';
import './Register.css'; // Create a CSS file for RegisterPage styles

const RegisterPage = () => {
  const [formData, setFormData] = useState({
    username: '',
    phone: '',
    email: '',
    name: '',
    password: '',
    confirmPassword: '',
    role: 'User',
  });

  const [passwordError, setPasswordError] = useState('');
  const [fieldTouched, setFieldTouched] = useState({});
  const [phoneError, setPhoneError] = useState('');

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleInputBlur = (e) => {
    const { name } = e.target;
    setFieldTouched({
      ...fieldTouched,
      [name]: true,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(formData);
    // Add your registration logic here
  };

  const handleConfirmPassword = () => {
    return formData.password === formData.confirmPassword;
  };

  const validatePassword = (password) => {
    // Use a regular expression to validate the password
    const passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    return passwordPattern.test(password);
  };

  const isFormValid = () => {
    const isPasswordValid = validatePassword(formData.password) && handleConfirmPassword();
    const isFormFilled = Object.values(formData).every((value) => value !== '');

    // Additional validation for Username and Name fields
    const isUsernameValid = formData.username.length >= 3;
    const isNameValid = formData.name.length >= 3;
    const isPhoneValid = /^\d+$/.test(formData.phone);

    return (
      isPasswordValid &&
      isFormFilled &&
      isUsernameValid &&
      isNameValid &&
      isPhoneValid
    );
  };

  return (
    <div className="register-page">
      <div className="logo">
        <img src={logo} alt="Logo" />
      </div>
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
              onBlur={handleInputBlur}
              required
            />
            {fieldTouched.username && formData.username.length < 3 && (
              <span className="error">Username must be at least 3 characters long.</span>
            )}
          </div>
          <div className="form-group">
            <label htmlFor="phone">Phone:</label>
            <input
              type="text"
              id="phone"
              name="phone"
              value={formData.phone}
              onChange={handleInputChange}
              onBlur={handleInputBlur}
              required
            />
            {fieldTouched.phone && !/^\d+$/.test(formData.phone) && (
              <span className="error">Type only numbers in the Phone field.</span>
            )}
          </div>
          <div className="form-group">
            <label htmlFor="email">Email:</label>
            <input
              type="email"
              id="email"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              onBlur={handleInputBlur}
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
              onBlur={handleInputBlur}
              required
            />
            {fieldTouched.name && formData.name.length < 3 && (
              <span className="error">Name must be at least 3 characters long.</span>
            )}
          </div>
          <div className="form-group">
            <label htmlFor="password">Password:</label>
            <input
              type="password"
              id="password"
              name="password"
              value={formData.password}
              onChange={handleInputChange}
              onBlur={handleInputBlur}
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
              onBlur={handleInputBlur}
              required
            />
            {!handleConfirmPassword() && fieldTouched.confirmPassword && (
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
              onBlur={handleInputBlur}
              required
            >
              <option value="Admin">Admin</option>
              <option value="User">User</option>
              <option value="Agent">Agent</option>
            </select>
          </div>
          <div className="form-group">
            <button
              className="btn btn-primary"
              type="submit"
              disabled={!isFormValid()}
            >
              Register
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default RegisterPage;
