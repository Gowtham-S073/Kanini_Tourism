import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './Agent.css';
import { TextField, Button, Select, MenuItem, FormControl, InputLabel, Box, Typography, Container, Grid, Paper } from '@mui/material';

const Agent = () => {
    const [packageData, setPackageData] = useState({
        id: 0,
        packagePrice: 0,
        packageName: "",
        travelAgentId: 5,
        region: "",
        imagepath: "",
        duration: null,
        FormFile: null,

    });
    const [showPostButton, setShowPostButton] = useState(false);


    const [packagedetails, setPackageDetails] = useState({
        id: 0,
        PackageId: 0,
        Placename: "",
        DayNumber: 0,
        itinerary: "",
        FormFile: null,
    });

    const [placedata, setPlaceData] = useState([]);
    const [fileList, setFileList] = useState([]);
    const [datafromdb, setDatafromdb] = useState();


    const [packagedetailstodb, setPackageDetailstodb] = useState([]);

    const handleDataInputChange = (e) => {
        const { name, value } = e.target;
        setPackageData((prevPackageData) => ({
            ...prevPackageData,
            [name]: value,
        }));
        console.log(packageData);
        if (name === 'duration' && parseInt(value, 10) > 0) {
            setShowPostButton(true);
        }

    };

    const handleDetailsInputChange = (e) => {
        const { name, value } = e.target;
        setPackageDetails((prevPackageDetails) => ({
            ...prevPackageDetails,
            [name]: value,
        }));
    };

    const handleFile1Change = (e) => {
        const file = e.target.files[0];
        setPackageData((prevPackageData) => ({
            ...prevPackageData,
            FormFile: file,
        }));
    };

    const handlePlaceSelect = (e, i) => {
        const { name, value } = e.target;
        setPackageDetails((prevPackageDetails) => ({
            ...prevPackageDetails,
            [name]: value,
        }));


        setPackageDetailstodb((prevPackageDetailsToDb) => {
            const updatedDetails = [...prevPackageDetailsToDb];
            if (!updatedDetails[i]) {
                updatedDetails[i] = {};
            }
            updatedDetails[i]["PlaceId"] = value;
            return updatedDetails;
        });
    };

    const handleFileChange = (e, i) => {
        const file = e.target.files[0];
        setPackageDetailstodb((prevPackageDetails) => {
            const updatedDetails = [...prevPackageDetails];
            if (!updatedDetails[i]) {
                updatedDetails[i] = {};
            }
            updatedDetails[i].FormFile = file;
            return updatedDetails;
        });
    };

    const getPlaceData = async () => {
        try {
            const res = await axios.get('https://localhost:7290/api/Place/Get_All_Place');
            setPlaceData(res.data);
        } catch (ex) {
            console.log('Error fetching data:', ex);
        }
    };

    useEffect(() => {
        getPlaceData();
    }, []);
    useEffect(() => {
        console.log(packagedetailstodb);
    }, [packagedetailstodb]);

    useEffect(() => {
        const updatedPackageDetails = [];
        for (let i = 0; i < packageData.duration; i++) {
            const packageDetail = {
                PackageId: packagedetails[`PackageId${i}`] || 0,
                PlaceId: packagedetails[`PlaceId${i}`] || 0,
                DayNumber: packagedetails[`DayNumber${i}`] || 0,
                itinerary: packagedetails[`itinerary${i}`] || "",
                FormFile: packagedetails[`FormFile${i}`] || null,
            };
            updatedPackageDetails.push(packageDetail);
        }

        // Update the packagedetailstodb with the array of package details objects
        setPackageDetailstodb(updatedPackageDetails);
    }, [packagedetails, fileList, packageData.duration]);

    const handleSubmit = () => {
        const formData = new FormData();
        formData.append('PackagePrice', packageData.packagePrice);
        formData.append('PackageName', packageData.packageName);
        formData.append('TravelAgentId', packageData.travelAgentId);
        formData.append('Region', packageData.region);
        formData.append('imagepath', packageData.imagepath);
        formData.append('Duration', packageData.duration);
        formData.append('FormFile', packageData.FormFile);
        console.log(formData);

        const apiUrl = "https://localhost:7290/api/Package/PostPackageImage";
        fetch(apiUrl, {
            method: 'POST',
            headers: {
                accept: 'text/plain',
            },
            body: formData,
        })
            .then(async (data) => {
                if (data.status === 200) {
                    var myData = await data.json();
                    console.log(myData);
                    setDatafromdb(myData);
                    alert(' post happened');

                } else {
                    var myData = await data.json();
                    console.log(myData);
                    alert('no post happened');
                }
            })
            .catch((err) => {
                console.log(err.error);
            });
    }


    const handlePostData = async () => {
        try {
            for (let i = 0; i < packagedetailstodb.length; i++) {
                const packageDetail = packagedetailstodb[i];
                console.log(packageDetail);
                console.log(datafromdb.id);
                const formData = new FormData();

                formData.append('PackageId', datafromdb.id);
                formData.append('PlaceId', packageDetail.PlaceId);
                formData.append('DayNumber', packageDetail.DayNumber);
                formData.append('Itinerary', packageDetail.itinerary);
                formData.append('FormFile', packageDetail.FormFile);
                console.log(formData);




                // Post the individual packageDetail object
                const response = await axios.post('https://localhost:7290/api/PackageDetails/PostPlace', formData);
                console.log('Response:', response.data);
                alert(' post happened');

            }
            console.log('All objects posted successfully!');
        } catch (error) {
            console.log('Error posting data:', error);
            alert(' no post happened');

        }
    };


    const renderPackageDetails = () => {
        if (packageData.duration > 0) {
            const detailsInputs = [];
            for (let i = 0; i < packageData.duration; i++) {
                detailsInputs.push(
                    <Grid item xs={12} key={i}>
                        <Paper elevation={3} sx={{ padding: 2 }}>
                            <Typography variant="h5">Day {i + 1} Plan</Typography>
                            <FormControl fullWidth sx={{ mt: 2 }}>
                                <InputLabel htmlFor={`PlaceId${i}`}>Place Name</InputLabel>
                                <Select
                                    id={`PlaceId${i}`}
                                    name={`PlaceId${i}`}
                                    value={packagedetails[`PlaceId${i}`]}
                                    onChange={(e) => handlePlaceSelect(e, i)}
                                >
                                    <MenuItem value="">
                                        <em>Select Place</em>
                                    </MenuItem>
                                    {placedata.map((place) => (
                                        <MenuItem key={place.id} value={place.id}>
                                            {place.placeName}
                                        </MenuItem>
                                    ))}
                                </Select>
                            </FormControl>
                            <TextField
                                fullWidth
                                id={`DayNumber${i}`}
                                name={`DayNumber${i}`}
                                label="Day Number"
                                type="number"
                                value={packagedetails[`DayNumber${i}`]}
                                onChange={handleDetailsInputChange}
                                sx={{ mt: 2 }}
                            />
                            <TextField
                                fullWidth
                                id={`itinerary${i}`}
                                name={`itinerary${i}`}
                                label="Itinerary"
                                value={packagedetails[`itinerary${i}`]}
                                onChange={handleDetailsInputChange}
                                multiline
                                rows={4}
                                sx={{ mt: 2 }}
                            />
                            <TextField
                                fullWidth
                                type="file"
                                id={`FormFile${i}`}
                                name={`FormFile${i}`}
                                onChange={(e) => handleFileChange(e, i)}
                                sx={{ mt: 2 }}
                            />
                        </Paper>
                    </Grid>
                );
            }
            return detailsInputs;
        }
        return null;
    };

    return (
        <div className="agent-container">
            <Container maxWidth="md" sx={{ mt: 4 }}>
                <Box component="form" onSubmit={handleSubmit}>
                    <Grid container spacing={2}>
                        <Grid item xs={12}>
                            <TextField
                                fullWidth
                                id="packageName"
                                name="packageName"
                                label="Package Name"
                                value={packageData.packageName}
                                onChange={handleDataInputChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                fullWidth
                                id="packagePrice"
                                name="packagePrice"
                                label="Package Price"
                                type="number"
                                value={packageData.packagePrice}
                                onChange={handleDataInputChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                fullWidth
                                id="region"
                                name="region"
                                label="Region"
                                value={packageData.region}
                                onChange={handleDataInputChange}
                            />
                        </Grid>

                        <Grid item xs={12}>
                            <TextField
                                fullWidth
                                id="duration"
                                name="duration"
                                label="Duration"
                                type="number"
                                value={packageData.duration === null ? '' : packageData.duration}
                                onChange={handleDataInputChange}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <input
                                type="file"
                                id="FormFile"
                                name="FormFile"
                                onChange={handleFile1Change}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <Button variant="contained" onClick={handleSubmit}>
                                Add Package
                            </Button>
                        </Grid>
                    </Grid>
                </Box>

                <Box sx={{ mt: 4 }}>
                    <Grid container spacing={2}>
                        {renderPackageDetails()}
                    </Grid>
                </Box>

                {showPostButton && (
                    <Box mt={4}>
                        <Button variant="contained" onClick={handlePostData}>
                            Post Data
                        </Button>
                    </Box>
                )}
            </Container>
        </div>
    );
};

export default Agent;