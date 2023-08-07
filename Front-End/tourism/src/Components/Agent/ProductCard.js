import React, { useEffect, useState } from 'react';
import { Card, TextField, Button, InputAdornment, Grid } from '@mui/material';
// import SearchIcon from '@mui/icons-material/Search';
// import Header from './Header';
// import travel from '../images/tropical2.png';

const ProductCard = () => {
  const [searchTerm, setSearchTerm] = useState('');
  const [searchResults, setSearchResults] = useState([]);
  const [filteredResults, setFilteredResults] = useState([]);

  const handleSearchChange = (e) => {
    setSearchTerm(e.target.value);
    // Filter the packages based on the search term (package name) and price
    const filtered = searchResults.filter((product) =>
      product.packageName.toLowerCase().includes(e.target.value.toLowerCase())
      // product.packagePrice < parseFloat(e.target.value) // Filtering based on price
    );
    setFilteredResults(filtered);
  };

  useEffect(() => {
    handleSearchClick();
  }, []);

  const handleSearchClick = async () => {
    try {
      const response = await fetch(`https://localhost:7290/api/Package/Get_All_PackageDetails`);
      if (response.ok) {
        const data = await response.json();
        setSearchResults(data);
        setFilteredResults(data); // Initialize filtered results with all packages
        console.log(data);
      } else {
        console.error('Failed to fetch data from the server');
      }
    } catch (error) {
      console.error('Error occurred while fetching data:', error);
    }
  };

  return (
    <div>
      {/* <Header /> */}

      <div style={{ flex: 1 }}>
        {/* <img
          src={travel}
          alt="Eiffel Tower"
          style={{
            height: '450px',
            width: '100%',
            objectFit: 'cover',
            borderBottomLeftRadius: '60%',
            borderBottomRightRadius: '60%',
          }}
        /> */}
      </div>

      <div style={{ margin: '20px', display: 'flex', alignItems: 'center', borderColor: 'blue' }}>
        {/* Search bar */}
        <TextField
          type="text"
          value={searchTerm}
          onChange={handleSearchChange}
          placeholder="Search by package name..."
          fullWidth
          variant="outlined"
          InputProps={{
            startAdornment: (
              // <InputAdornment position="start">
              //   <SearchIcon />
              // </InputAdornment>
              <></>
            ),
            style: { fontSize: '16px' },
          }}
        />
        {/* Search button */}
        <Button variant="contained" color="primary" onClick={handleSearchClick} style={{ marginLeft: '10px', height: '56px' }}>
          Search
        </Button>
      </div>

      {/* Display search results */}
      <div>
        <div>
          <Grid container spacing={2} justifyContent="space-around"> {/* Center align the cards */}
            {filteredResults.map((product) => (
              <Grid item xs={12} sm={6} md={4} key={product.id}> {/* Each card occupies 4 columns on medium-sized screens */}
                <Card>
                  <img
                    src={`data:image/jpeg;base64,${product.imagepath}`}
                    alt={`Image`}
                    style={{ width: '100%', height: '250px', objectFit: 'cover' }}
                  />
                  <h2>{product.packageName}</h2>
                  <p>PACKAGE PRICE: {product.packagePrice}</p>
                  {/* Add the "Book" button here */}
                  <div style={{ display: 'flex', justifyContent: 'center', marginTop: 'auto', marginBottom: '10px' }}>
                    <Button variant="contained" color="primary" style={{ width: '20%', height: '50px' }}>
                      Book
                    </Button>
                  </div>
                </Card>
              </Grid>
            ))}
          </Grid>
        </div>
      </div>
    </div>
  );
};

export default ProductCard;
