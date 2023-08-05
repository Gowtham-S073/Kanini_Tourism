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
import Services from './Components/Servic/Service';
import Testimonials from './Components/Hero/Testimonial';
import Login from './Components/Login/Login';
import Register from './Components/Register/Register';
import GalleryPage from './Components/GalleryPage/GalleryPage';
import 'bootstrap/dist/css/bootstrap.min.css';
import html2canvas from 'html2canvas';
import jsPDF from 'jspdf';
import Pdf from './Components/Hero/pdf';

function App() {
  const [isLoading, setIsLoading] = useState(true);
  const [loader, setLoader] = useState(false);

  
  const downloadPDF = () =>{
    const capture = document.querySelector('.actual-receipt');
    setLoader(true);
    html2canvas(capture).then((canvas)=>{
      const imgData = canvas.toDataURL('img/png');
      const doc = new jsPDF('p', 'mm', 'a4');
      const componentWidth = doc.internal.pageSize.getWidth();
      const componentHeight = doc.internal.pageSize.getHeight();
      doc.addImage(imgData, 'PNG', 0, 0, componentWidth, componentHeight);
      setLoader(false);
      doc.save('receipt.pdf');
    })
  }

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
           {/* <Hero></Hero> */}
          {/* <Card></Card> */}
          {/* <Contact></Contact> */}
          {/* <Feedback></Feedback> */}
          {/* <Services></Services> */}
          {/* <Testimonials></Testimonials> */}
          {/* <Recommend></Recommend> */}
          <Login></Login> 
          <Register></Register>
          <Pdf></Pdf>
          <GalleryPage></GalleryPage>
          <Footer></Footer>
          <ScrollToTop></ScrollToTop>
          {/* <Slider images={images} /> */}

        </div>
      )}
    </>
  );
}

export default App;
