import React, { useEffect, useState } from 'react';
import Navbar from './Components/Navbar/Navbar';
import Contact from './Components/ContactPage/Contact';
import { BrowserRouter as Router, Route, Routes, BrowserRouter } from 'react-router-dom';
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
import ProductCard from './Components/Agent/ProductCard';
import Home from './Components/Homepage/homepage';
import { useParams } from 'react-router-dom';
import Agent from './Components/Agent/Agent';
import Error from './Components/Error';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



function App() {
  const [isLoading, setIsLoading] = useState(true);

  const userRole = sessionStorage.getItem('role');


  const images = [
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg.jpg',
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg2.jpg',
    'https://rawgit.com/creativetimofficial/material-kit/master/assets/img/bg3.jpg',
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
          <BrowserRouter>
            <Navbar></Navbar>
            <Routes>
              <Route path='/' element={<Hero></Hero>}></Route>
              <Route path='Contact' element={<Contact></Contact>}></Route>
              <Route path='Login' element={<Login></Login>}></Route>
              <Route path='Feedback' element={<Feedback></Feedback>}></Route>
              <Route path='Register' element={<Register></Register>}></Route>
              <Route path='PostImage' element={<Admin></Admin>}></Route>
              <Route path='Gallery' element={<Gallery></Gallery>}></Route>
              <Route path='ProductCard' element={<ProductCard></ProductCard>}></Route>
              <Route path='Admin' element={<Admin></Admin>}></Route>
              <Route path='Agent' element={<Agent></Agent>}></Route>
              <Route path='News' element={<News></News>}></Route>
              <Route path="Home" element={<Home></Home>}></Route>
              <Route path='/Login' element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<Login />:<Error/>} />
              <Route path='/Register' element={(userRole !== 'Admin' && userRole !=='Agent' && userRole !=='User') ?<Register />:<Error/>} />
              <Route path='/Contact' element={(userRole === 'Admin' || userRole ==='User'|| userRole===null) ?<Contact />:<Error/>} />
              <Route path='*' element={<Error />} />


              {/* <Route path='' element={}></Route>
              <Route path='' element={}></Route>
              <Route path='' element={}></Route>
              <Route path='' element={}></Route>
              <Route path='' element={}></Route> */}
            </Routes>
            <Footer></Footer>
          <ScrollToTop></ScrollToTop>
          </BrowserRouter>

          {/* <Navbar></Navbar>  */}
          {/* <Hero></Hero> */}
          {/* <Card></Card> */}
          {/* <Contact></Contact> */}
          {/* <Feedback></Feedback> */}
          {/* <News></News> */}
          {/* <Testimonials></Testimonials> */}
          {/* <Recommend></Recommend> */}
          {/* <Login></Login> */}
          {/* <Home></Home> */}
          {/* <ProductCard></ProductCard> */}
          {/* <Admin></Admin>  */}
          {/* <Gallery/> */}
          {/* <Package></Package> */}
          {/* <Register></Register> */}
          {/* <TravelAgent></TravelAgent> */}
          {/* <Slider images={images} /> */}

        </div>
      )}
    </>
  );
}

export default App;
