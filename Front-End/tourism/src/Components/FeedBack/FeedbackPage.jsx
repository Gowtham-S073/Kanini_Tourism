import React, { useRef } from 'react';
import emailjs from '@emailjs/browser';
import './FeedbackPage.css';

const Feedback = () => {
  const form = useRef();

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs.sendForm('service_gci1za7',
      'template_5mhiphk',
      form.current, '644-tQT8ozp9KLGxl')
      .then((result) => {
        console.log(result.text);
        alert("message sent");
        form.current.reset();
      }, (error) => {
        console.log(error.text);
      });
  };

  return (
    <div className='Feedback-bg'>
    <div className='Feedback_Form'>
      <h1>Give Your Valuable Feedback :</h1>
      <br></br><br></br>
      <form ref={form} onSubmit={sendEmail}>
        <label>Name</label>
        <input type="text" name="user_name" />
        <label>Email</label>
        <input type="email" name="user_email" />
        <label htmlFor='phone'>Phone:</label>
        <input
          type='tel'
          id='phone'
          name='phone'
          required
          pattern="[0-9]{10}"
          title="Please enter a 10-digit phone number"
        />
        <label>Message</label>
        <textarea name="message" />
        <input type="submit" value="Send" />
      </form>
    </div>
    </div>
  );
};

export default Feedback;