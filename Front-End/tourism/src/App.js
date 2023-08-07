import React, { useEffect, useState } from 'react';
import Navbar from './Components/Navbar/Navbar';
import Contact from './Components/ContactPage/Contact';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Feedback from './Components/FeedBack/FeedbackPage';
import Preloader from './Components/Preloader/Preloader';
import Hero from './Components/Hero/Hero';
import Footer from './Components/Footer/Footer';
import Recommend from './Components/Hero/Recommend';
import ScrollToTop from './Components/ScrolltoTop/ScrolltoTop';
import News from './Components/News/News';
import Testimonials from './Components/Hero/Testimonial';
import Login from './Components/Login/Login';
import Register from './Components/Register/Register';
import Gallery from './Components/GalleryPage/Gallery';
import 'bootstrap/dist/css/bootstrap.min.css';
import Admin from './Components/Admin/Admin';
import Package from './Components/Agent/Package';
import TravelAgent from './Components/Agent/TravelAgent';
import ProductCard from './Components/Agent/ProductCard';

function App() {
  const [isLoading, setIsLoading] = useState(true);

  const images = [
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg.jpg',
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg2.jpg',
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg3.jpg',
    // Add more image URLs as needed
  ];


  useEffect(() => {
    setTimeout(() => {
      setIsLoading(false); 
    }, 3000); 

    const innerCursor = document.querySelector('.inner-cursor');
    const outerCursor = document.querySelector('.outer-cursor');

    const moveCursor = (e) => {
      const x = e.clientX;
      const y = e.clientY;

      innerCursor.style.left = `${x}px`;
      innerCursor.style.top = `${y}px`;
      outerCursor.style.left = `${x}px`;
      outerCursor.style.top = `${y}px`;
    };

    document.addEventListener('mousemove', moveCursor);

    return () => {
      document.removeEventListener('mousemove', moveCursor);
    };
  }, []);

  return (
    <>
      {isLoading ? (
        <Preloader />
      ) : (
        <div className="app">
       

           <Navbar></Navbar> 
           <Hero></Hero>
          {/* <Card></Card> */}
          {/* <Contact></Contact> */}
          {/* <Feedback></Feedback> */}
          {/* <News></News> */}
          {/* <Testimonials></Testimonials> */}
          {/* <Recommend></Recommend> */}
          <Login></Login>
          <ProductCard></ProductCard>
          <Admin></Admin> 
          <Gallery/>
          <Package></Package>
          <Register></Register>
          <TravelAgent></TravelAgent>
          <Footer></Footer>
          <ScrollToTop></ScrollToTop>
          {/* <Slider images={images} /> */}
         
        </div>
      )}
    </>
  );
}

export default App;
