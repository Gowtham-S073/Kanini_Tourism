import React, { useEffect, useState } from 'react';
import axios from 'axios';

import {
  Card,
  TextField,
  Button,
  InputAdornment,
  Grid,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  Typography,
} from '@mui/material';

const ProductCard = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [filteredResults, setFilteredResults] = useState([]);

  const [data, setData] = useState({
    id: 0,
    userId: 0,
    packageId: 0,
    feedback: '',
    totalAmount: 0,
    date: '',
    no_of_person: 0,
  });

  const [open, setOpen] = useState(false);
  const [userInput, setUserInput] = useState('');
  const [currentproduct,setCurrentproduct] = useState();

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
    const filtered = searchResults.filter(
      (product) =>
        product.packageName.toLowerCase().includes(e.target.value.toLowerCase())
    );
    setFilteredResults(filtered);
  };

  useEffect(() => {
    handleSearchClick();
  }, []);

  useEffect(() => {
    if (data.packageId !== 0) {
      posttodb();
    }
  }, [data]);

  const handleSearchClick = async () => {
    try {
      const response = await fetch(
        'https://localhost:7290/api/Package/Get_All_PackageDetails'
      );
      if (response.ok) {
        const data = await response.json();
        setSearchResults(data);
        setFilteredResults(data);
      } else {
        console.error('Failed to fetch data from the server');
      }
    } catch (error) {
      console.error('Error occurred while fetching data:', error);
    }
  };
  const handleBookNowClick = async () => {
    // ... Other code ...

    const total = currentproduct.packagePrice * data.no_of_person;
    setData((prevData) => ({
      ...prevData,
      packageId: currentproduct.id,
      id: 0,
      userId: 2,
      totalAmount: total,
      feedback: '',
    }));

    // Close the dialog
    setOpen(false);
  };


  const posttodb = async () => {
    console.log(data);
    try {
      const response = await axios.post(
        'https://localhost:7290/api/Bookings/Add_Booking',
        data
      );
      console.log('Response:', response.data);
      alert('Post happened');
    } catch (error) {
      console.error('Error occurred while posting data:', error);
      alert('Error occurred while posting data');
    }
  };


  
  
  const handleBookButtonClick =  (product) => {
    setCurrentproduct(product);
  
        
    setOpen(true);
    setUserInput('');
  };
  
  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div>
      <div style={{ margin: '20px', display: 'flex', alignItems: 'center' }}>
        <TextField
          type="text"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Search by package name..."
          fullWidth
          variant="outlined"
          InputProps={{
            startAdornment: <></>,
            style: { fontSize: '16px' },
          }}
        />
        <Button
          variant="contained"
          color="primary"
          onClick={handleSearchClick}
          style={{ marginLeft: '10px', height: '56px' }}
        >
          Search
        </Button>
      </div>

      <div>
        <div>
          <Grid container spacing={2} justifyContent="space-around">
            {filteredResults.map((product) => (
              <Grid item xs={12} sm={6} md={4} key={product.id}>
                <Card>
                  <img
                    src={`data:image/jpeg;base64,${product.imagepath}`}
                    alt="Image"
                    style={{ width: '100%', height: '250px', objectFit: 'cover' }}
                  />
                  <h2>{product.packageName}</h2>
                  <p>PACKAGE PRICE: {product.packagePrice}</p>
                  <div
                    style={{ display: 'flex', justifyContent: 'center', marginTop: 'auto', marginBottom: '10px' }}
                  >
                    <Button
                      variant="contained"
                      color="primary"
                      style={{ width: '20%', height: '50px' }}
                      onClick={() => handleBookButtonClick(product)}
                    >
                      Book
                    </Button>
                  </div>
                </Card>
              </Grid>
            ))}
          </Grid>
        </div>
      </div>

      <Dialog open={open} onClose={handleClose} maxWidth="sm" fullWidth>
        <DialogTitle>Booking Details</DialogTitle>
        <DialogContent>
          <Typography variant="h6">Package Name: {data.packageName}</Typography>
          <Typography variant="body1">Package Price: {data.packagePrice}</Typography>

          {/* Input box that accepts only a maximum of 100 digits */}
          <TextField
            type="number"
            value={userInput}
            onChange={(e) => {
              const value = e.target.value;
              // Only set the user input if it's a number and it's less than or equal to 19
              if (/^\d*$/.test(value) && parseInt(value) <= 19) {
                setUserInput(value);
                setData((prevData) => ({
                  ...prevData,
                  no_of_person: parseInt(value), // Store the entered value in the no_of_person property of data
                }));
              }
            }}
            inputProps={{
              maxLength: 2, // Maximum of 100 digits
              style: { textAlign: 'center' },
            }}
            variant="outlined"
            fullWidth
            label="Enter number of People (max 19)"
          />

          {/* Date picker */}
          <TextField
            type="date"
            value={data.date}
            onChange={(e) => {
              const selectedDate = e.target.value;
              setData((prevData) => ({
                ...prevData,
                date: selectedDate, // Store the selected date in the date property of data
              }));
            }}
            inputProps={{
              min: new Date().toISOString().slice(0, 10), // Minimum date is the current date
              style: { textAlign: 'center' },
            }}
            variant="outlined"
            fullWidth
            label="Select a date"
          />
        </DialogContent>
        <DialogActions>
          <Button onClick={handleClose} color="primary">
            Close
          </Button>
          <Button onClick={handleBookNowClick} color="primary">
            Book Now
          </Button>
        </DialogActions>
      </Dialog>
    </div>
  );
};

export default ProductCard;
