import React, { useState, useEffect } from 'react';
import axios from 'axios';
import styles from './Gallery.css';
import { Card, Col, Row } from 'react-bootstrap';

const Gallery = () => {
  const [uploadedFileData, setUploadedFileData] = useState([]);

  const getGalleryData = async () => {
    try {
      const res = await axios.get('https://localhost:7290/api/Gallery/Get_All_Gallery', {
        responseType: 'json',
      });
      setUploadedFileData(res.data);
    } catch (ex) {
      console.log('Error fetching data:', ex);
    }
  };

  useEffect(() => {
    getGalleryData();
  }, []);

  return (
    <div>
      <Row xs={1} md={4} className="g-4">
        {uploadedFileData.map((item, index) => (
          <Col key={index}>
            <Card>
              <Card.Img variant="top" src={`data:image/jpeg;base64,${item.adminImage}`} />
            </Card>
          </Col>
        ))}
      </Row>
    </div>
  );
};

export default Gallery;
