// Preloader.js
import React from 'react';
import './Preloader.css'; 
import Loader from '../../Assests/GlassLoader.gif';

const Preloader = () => {
  return (
    <div className="preloader">
      <img src={Loader} alt='Loading...'></img>
    </div>
  );
};

export default Preloader;
