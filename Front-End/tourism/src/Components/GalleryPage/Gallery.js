// import React from 'react'
// import Card from 'react-bootstrap/Card';
// import Col from 'react-bootstrap/Col';
// import Row from 'react-bootstrap/Row';
// import Carousel from 'react-bootstrap/Carousel';
// import ExampleCarouselImage from '../GalleryPage/ExampleCarouselImage ';


// function GalleryPage() {

//     const carouselImages = [
//         'https://themewagon.github.io/ecoland/images/destination-single.jpg',
//         'https://themewagon.github.io/ecoland/images/destination-3.jpg'
//         // Add more image URLs here
//       ];

//   return (
//     <div>
//  <Carousel>
//       <Carousel.Item interval={1}>
//         <ExampleCarouselImage text="First slide" />
//         <Carousel.Caption>
//           <h3>First slide label</h3>
//           <p>Nulla vitae elit libero, a pharetra augue mollis interdum.</p>
//         </Carousel.Caption>
//       </Carousel.Item>
//       <Carousel.Item interval={5}>
//         <ExampleCarouselImage text="Second slide" />
//         <Carousel.Caption>
//           <h3>Second slide label</h3>
//           <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
//         </Carousel.Caption>
//       </Carousel.Item>
//       <Carousel.Item>
//         <ExampleCarouselImage text="Third slide" />
//         <Carousel.Caption>
//           <h3>Third slide label</h3>
//           <p>
//             Praesent commodo cursus magna, vel scelerisque nisl consectetur.
//           </p>
//         </Carousel.Caption>
//       </Carousel.Item>
//     </Carousel>

// <Row xs={1} md={4} className="g-4">
//       {Array.from({ length: 4 }).map((_, idx) => (
//         <Col key={idx}>
//           <Card>
//             <Card.Img variant="top" src="holder.js/100px160" />
//             <Card.Body>
//               <Card.Title>Card title</Card.Title>
//               <Card.Text>
//                 This is a longer card with supporting text below as a natural
//                 lead-in to additional content. This content is a little bit
//                 longer.
//               </Card.Text>
//             </Card.Body>
//           </Card>
//         </Col>
//       ))}
//     </Row>
// </div>
    
//   )
// }

// export default GalleryPage


import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from "./Gallery.css";


const Gallery = () => {
  const [uploadedFileData, setUploadedFileData] = useState([]);
  const [currentIndex, setCurrentIndex] = useState(0);

  const getGalleryData = async () => {
    try {
      const res = await axios.get('https://localhost:7290/api/Gallery/Get_All_Gallery', {
        responseType: 'json',
      });
      console.log(res.data);
      console.log(res);
      // Filter only the images with imageType: "imageslider"
      // const filteredImages = res.data.filter((image) => image.imageType === 'imageslider');
      setUploadedFileData(res.data);
      console.log(uploadedFileData);
    } catch (ex) {
      console.log('Error fetching data:', ex);
    }
  };

  useEffect(() => {
    getGalleryData();
  }, []);

  // useEffect(() => {
  //   const interval = setInterval(() => {
  //     setCurrentIndex((prevIndex) => (prevIndex + 1) % uploadedFileData.length);
  //   }, 5000); // Change the value to the desired interval in milliseconds (e.g., 5000ms = 5 seconds)

  //   return () => clearInterval(interval);
  // }, [uploadedFileData]);

  return (
    // <div id="carouselExample" className="carousel slide" data-bs-ride="carousel">
    //   <div className="carousel-inner">
    //     {uploadedFileData.map((image, index) => (
    //       <div key={index} className={`carousel-item ${index === currentIndex ? 'active' : ''}`}>
    //         <img src={`data:image/jpeg;base64,${image.adminimage}`} className="d-block w-100" alt={`Slide ${index}`} />
    //       </div>
    //     ))}
    //   </div>
    // </div>
    <div>
      <div className={styles.card_container}>
        {uploadedFileData.map((item, index) => (
          <div className={styles.card} key={index}>
            <img
              src={`data:image/jpeg;base64,${item.adminImage}`}
              alt={`Image ${index + 1}`}
              className={styles.card_image}
            />
            <div className={styles.card_details}>
              {/* <p>Package ID: {item.id}</p>
              <p>Package Price: {item.packagePrice}</p>
              <p>Region: {item.region}</p>
              <button className={styles.Bookbutton} type="button" onClick={handleBook}>Book</button> */}

              {/* Add other data here */}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Gallery; 
