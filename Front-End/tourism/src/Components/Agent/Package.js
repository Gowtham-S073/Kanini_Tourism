import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Package = () => {
  const [uploadedFileData, setUploadedFileData] = useState(null);

  const myObject = {
    idInt: 1,
    idString: 'string',
  };

  const getFileData = async () => {
    try {
      // Make the POST API request to the backend
      const response = await axios.post('https://localhost:7290/api/Package/Get_Package_Details', myObject);

      // Handle the successful response
      console.log(response.data);
      setUploadedFileData(response?.data);
    } catch (error) {
      console.log('Error fetching data:', error);
    }
  };

  useEffect(() => {
    getFileData();
  }, []);

  return (
    <div>
      <button onClick={getFileData}>Get File Data</button>
      {uploadedFileData && (
        <div>
          <h2>Uploaded File Data</h2>
          <table>
            <thead>
              <tr>
                <th>Package ID</th>
                <th>Package Price</th>
                <th>Image</th>
                <th>Travel Agent ID</th>
                <th>Region</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>{uploadedFileData.id}</td>
                <td>{uploadedFileData.packagePrice}</td>
                <td>
                  {uploadedFileData.imagepath && (
                    <img
                      src={`data:image/jpeg;base64,${uploadedFileData.imagepath}`}
                      alt={`Image`}
                      style={{ maxWidth: '100%', maxHeight: '100px' }}
                    />
                  )}
                </td>
                <td>{uploadedFileData.travelAgentId}</td>
                <td>{uploadedFileData.region}</td>
              </tr>
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default Package;
