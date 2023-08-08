import React, { useState } from 'react';
import '../ContactPage/Contact.css';
import Blog from '../../Assests/blog1.jpg';
import { FaMapMarkerAlt, FaPhoneAlt, FaEnvelope } from 'react-icons/fa';


const ContactPage = () => {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [message, setMessage] = useState('');
  const [isNameValid, setIsNameValid] = useState(true);
  const [isEmailValid, setIsEmailValid] = useState(true);
  const [isMessageValid, setIsMessageValid] = useState(true);

  const handleSubmit = (e) => {
    e.preventDefault();
    setIsNameValid(name.trim() !== '');
    setIsEmailValid(validateEmail(email));
    setIsMessageValid(message.trim() !== '');

    if (name.trim() !== '' && validateEmail(email) && message.trim() !== '') {
      alert('Thank you for your message! We will get back to you soon.');
    }
  };

  const validateEmail = (email) => {
    const re = /\S+@\S+\.\S+/;
    return re.test(email);
  };

  return (
    <div className='Contact-section'>
      <div className="contact-page-container">
        <h1 className="contact-page-title">Contact Us</h1>
        <p className="contact-page-description" style={{fontWeight:'bolder'}}>
          If you have any questions or inquiries, please feel free to contact us using the form below.
        </p>

        <div class="hero_section">
          <div class="hero_content">
            <div class="left_side">
              <div class="address details">
                <i class="fas fa-map-marker-alt"></i>
                <div class="topic">Address</div>
                <div class="text-one">Trip Booking, NP12</div>
                <div class="text-two">Chennai-06</div>
              </div>
              <div class="phone details">
                <i class="fas fa-phone-alt"></i>
                <div class="topic">Phone</div>
                <div class="text-one">+0098 9893 5647</div>
                <div class="text-two">+0096 3434 5678</div>
              </div>
              <div class="email details">
                <i class="fas fa-envelope"></i>
                <div class="topic">Email</div>
                <div class="text-one">tripbooking@gmail.com</div>
                <div class="text-two">info.codinglab@gmail.com</div>
              </div>
            </div>
            <div class="right_side">
              <div class="topic_text">Send us a message</div>
              <p>If you have any work from me or any types of quries related to my tutorial, you can send me message from
                here. It's my pleasure to help you.</p>
            </div>
          </div>
        </div>

        <iframe
          src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3889.0169423307143!2d80.22441831113612!3d12.906632016245817!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3a525d97c837366b%3A0xd99f0e98308ef647!2sKANINI%20Software%20Solutions%20India%20Private%20Limited!5e0!3m2!1sen!2sin!4v1691042846295!5m2!1sen!2sin"
          width="600"
          height="450"
          style={{ border: "0", paddingTop:'20px' }}
          allowFullScreen=""
          loading="lazy"
          title="GoogleMap"
        ></iframe>

      </div>
    </div>
  );
};

export default ContactPage;
