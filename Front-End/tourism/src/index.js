import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';


function moveCursor(e) {
  let innerCursor = document.querySelector('.inner-cursor');
  let outerCursor = document.querySelector('.outer-cursor');

  let x = e.clientX;
  let y = e.clientY;

  innerCursor.style.left = `${x}px`;
  innerCursor.style.top = `${y}px`;
  outerCursor.style.left = `${x}px`;
  outerCursor.style.top = `${y}px`;
}

document.addEventListener('DOMContentLoaded', () => {
  document.addEventListener('mousemove', moveCursor);

  ReactDOM.render(
    <React.StrictMode>
      <App />
    </React.StrictMode>,
    document.getElementById('root')
  );

  reportWebVitals();
});



