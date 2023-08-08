import React, { createContext, useState, useEffect } from 'react';


const ApiContext = createContext();

const ApiContextProvider = ({ children }) => {
    const [userRole, setUserRole] = useState(null);
  const [userToken, setUserToken] = useState(null);
  const [userName, setUserName] = useState(null);
  const [userId, setUserId] = useState(null);

  const [selectedPackage, setSelectedPackage] = useState();
  const [selectedPackagePrice, setSelectedPackagePrice] = useState();

  
  
  useEffect(() => {
    // Get user role and token from sessionStorage when the component mounts
    const storedRole = sessionStorage.getItem('userRole');
    const storedToken = sessionStorage.getItem('userToken');
    const storedUsername = sessionStorage.getItem('userName');
    const storedUserId = sessionStorage.getItem('userId');

    // Set the state with the values from sessionStorage
    setUserRole(storedRole);
    setUserToken(storedToken);
    setUserName(storedUsername);
    setUserId(storedUserId);

  }, []);
  return (
    <ApiContext.Provider value={{ userRole, userToken, userName, setUserName,userId, setUserId, setUserRole, setUserToken,
        selectedPackage, setSelectedPackage, selectedPackagePrice, setSelectedPackagePrice}}>
     {children}
   </ApiContext.Provider>
 );  
}

export { ApiContext, ApiContextProvider };