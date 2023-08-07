// import React, { useEffect, useState, useContext } from 'react';
// import Modal from 'react-modal';

// import "../Css/Admin.css"


// const Admin = () => {
//     const [data, setData] = useState([
//         {
//             id: 0,
//             username: '',
//             phone: '',
//             email: '',
//             name: '',
//             hashkey: '',
//             password: '',
//             role: '',
//             isActive: true,
//         },
//         // Add more data objects as needed
//     ]);

//     const [dataAgent, setDataAgent] = useState(
//         {
//             id: 0,
//             username: '',
//             phone: '',
//             email: '',
//             name: '',
//             hashkey: '',
//             password: '',
//             role: '',
//             isActive: true,
//         }
//     );
//     const [myObject, setMyObject] = useState({
//         Id: 0,
//         AdminId: 1,
//         Adminimage: "a",
//         ImageType: "imageSlider",
//         FormFile: null,
//     });

//     const handleFileChange = (event) => {
//         const file = event.target.files[0];
//         setMyObject({
//             ...myObject,
//             FormFile: file,
//         });
//     };
//     const handleInputChange = (event) => {
//         const type = event.target.value;
//         setMyObject({
//             ...myObject,
//             ImageType: type,
//         });
//     };
//     // const Popup = () => {
//     //     const [modalIsOpen, setModalIsOpen] = useState(false);
//     //     const [formData, setFormData] = useState({
//     //         packageImg: null,
//     //         role: 'User',
//     //     });

//         const postToDb = () => {
//             const formData = new FormData();
//             formData.append('Id', myObject.Id);
//             formData.append('AdminId', myObject.AdminId);
//             formData.append('Adminimage', myObject.Adminimage);
//             formData.append('ImageType', myObject.ImageType);
//             formData.append('FormFile', myObject.FormFile);

//             console.log(myObject);


//             const apiUrl = "https://localhost:7290/api/PostGalleries/PostPostGalleryImage";
//             fetch(apiUrl, {
//                 method: 'POST',
//                 headers: {
//                     accept: 'text/plain',
//                 },
//                 body: formData,
//             })
//                 .then(async (data) => {
//                     if (data.status === 200) {
//                         var myData = await data.json();
//                         console.log(myData);
//                     } else {
//                         var myData = await data.json();
//                         console.log(myData);
//                         alert('no post happened');
//                     }
//                 })
//                 .catch((err) => {
//                     console.log(err.error);
//                 });




//         }

//         const handledata = () => {
//             fetch('https://localhost:7290/api/Users/GetUnApprovedAgent', {
//                 method: 'GET',
//                 headers: {
//                     accept: 'text/plain',
//                     'Content-Type': 'application/json',
//                 },

//             })
//                 .then(async (data) => {

//                     var myData = await data.json();
//                     console.log(myData);
//                     setData(myData);

//                 })
//                 .catch((error) => {
//                     console.error(error);
//                 });
//         }
//         useEffect(() => {


//             handledata();

//         }, []);
//         var handleApprove = (item) => {
//             const toapprove =
//             {
//                 id: item.id,
//                 username: item.username,
//                 phone: item.phone,
//                 email: item.email,
//                 name: item.name,
//                 hashkey: item.hashkey,
//                 password: item.password,
//                 role: item.role,
//                 isActive: true,
//             }
//             console.log(toapprove);
//             const apiUrl = "https://localhost:7290/api/Users/ApproveAgent";
//             fetch(apiUrl, {
//                 method: 'PUT',
//                 headers: {
//                     accept: 'text/plain',
//                     'Content-Type': 'application/json',
//                 },
//                 body: JSON.stringify({ ...toapprove }),
//             })
//                 .then(async (data) => {
//                     if (data.status === 200) {
//                         var myData = await data.json();
//                         console.log(myData);
//                     } else {
//                         alert('Invalid username or password');
//                     }
//                 })
//                 .catch((err) => {
//                     console.log(err.error);
//                 });
//             window.location.reload();


//         }

//         const handleDecline = (item) => {

//             const todecline =
//             {
//                 id: item.id,
//                 username: item.username,
//                 phone: item.phone,
//                 email: item.email,
//                 name: item.name,
//                 hashkey: item.hashkey,
//                 password: item.password,
//                 role: item.role,
//                 isActive: true,
//             }
//             console.log(todecline);
//             const apiUrl = "https://localhost:7290/api/Users/DeleteAgent";
//             fetch(apiUrl, {
//                 method: 'Delete',
//                 headers: {
//                     accept: 'text/plain',
//                     'Content-Type': 'application/json',
//                 },
//                 body: JSON.stringify({ ...todecline }),
//             })
//                 .then(async (data) => {
//                     if (data.status === 200) {
//                         var myData = await data.json();
//                         console.log(myData);
//                     } else {
//                         alert('Invalid username or password');
//                     }
//                 })
//                 .catch((err) => {
//                     console.log(err.error);
//                 });
//             window.location.reload();

//         }



//         return (
//             <>
//             <p>jhjyhvjhvjhvjhvhv</p>
//                 {/* <div>
//                     <button onClick={() => setModalIsOpen(true)}>Open Popup</button>
//                     <Modal
//                         isOpen={modalIsOpen}
//                         onRequestClose={() => setModalIsOpen(false)}
//                         style={{
//                             overlay: {
//                                 backgroundColor: 'rgba(0, 0, 0, 0.6)',
//                             },
//                             content: {
//                                 position: 'absolute',
//                                 top: '50%',
//                                 left: '50%',
//                                 transform: 'translate(-50%, -50%)',
//                                 maxWidth: '80%',
//                                 maxHeight: '80%',
//                                 padding: '20px',
//                                 border: '1px solid #ccc',
//                                 borderRadius: '4px',
//                                 background: '#fff',
//                             },
//                         }}
//                     >
//                         <button
//                             style={{ position: 'absolute', top: '10px', right: '10px' }}
//                             onClick={() => setModalIsOpen(false)}
//                         >
//                             Close
//                         </button>
//                         <label htmlFor="packageImg">
//                             Image
//                             <input
//                                 type="file"
//                                 id="packageImg"
//                                 name="packageImg"
//                                 onChange={handleFileChange}
//                             />
//                         </label>
//                         <br />
//                         <label htmlFor="role">Role:</label>
//                         <select
//                             id="role"
//                             name="role"
//                             onChange={handleInputChange}
//                             required
//                         >
//                             <option value="User">User</option>
//                             <option value="Agent">Agent</option>
//                         </select>
//                         <br />
//                         <button className="addimage" type="button" onClick={() => postToDb()}>
//                             Add
//                         </button>
//                     </Modal>
//                 </div> */}


//                 <div className="table-container">
//                     <table className="responsive-table">
//                         <thead>
//                             <tr>
//                                 <th>Username</th>
//                                 <th>Phone</th>
//                                 <th>Email</th>
//                                 <th>Name</th>
//                                 <th>Role</th>
//                                 <th>Action</th>
//                             </tr>
//                         </thead>
//                         <tbody>
//                             {data.map((item, index) => (
//                                 <tr key={index}>
//                                     <td>{item.username}</td>
//                                     <td>{item.phone}</td>
//                                     <td>{item.email}</td>
//                                     <td>{item.name}</td>
//                                     <td>{item.role}</td>
//                                     <td>
//                                         <button className='Approvebutton' type="button" onClick={() => handleApprove(item)}>Approve</button>
//                                         <button className='Declinebutton' type="button" onClick={() => handleDecline(item)}>Decline</button>

//                                     </td>
//                                 </tr>
//                             ))}
//                         </tbody>
//                     </table>
//                 </div>
//             </>

//         )
//     }
// // }



// export default Admin;


import React, { useState,useEffect } from 'react';
import Modal from 'react-modal';
import "./Admin.css";

const Popup = ({ modalIsOpen, setModalIsOpen, handleFileChange, handleInputChange, postToDb }) => {
  return (
    <Modal
      isOpen={modalIsOpen}
      onRequestClose={() => setModalIsOpen(false)}
      style={{
        overlay: {
          backgroundColor: 'rgba(0, 0, 0, 0.6)',
        },
        content: {
          position: 'absolute',
          top: '50%',
          left: '50%',
          transform: 'translate(-50%, -50%)',
          maxWidth: '30%',
          maxHeight: '40%',
          padding: '20px',
          border: '1px solid #ccc',
          borderRadius: '4px',
          background: '#fff',
        },
      }}
    >
      <button
        style={{ position: 'absolute', top: '10px', right: '10px' }}
        onClick={() => setModalIsOpen(false)}
      >
        Close
      </button>
      <label htmlFor="packageImg">
        Image
        <input
          type="file"
          id="packageImg"
          name="packageImg"
          onChange={handleFileChange}
        />
      </label>
      <br />
      <label htmlFor="imagetype">Imagetype:</label>
      <select
        id="imagetype"
        name="imagetype"
        onChange={handleInputChange}
        required
      >
        <option value="imageSlider">imageSlider</option>
        <option value="gallery">gallery</option>
      </select>
      <br />
      <button className="addimage" type="button" style={{marginTop:'300px',left:'10px'}} onClick={() => postToDb()}>
        Add
      </button>
    </Modal>
  );
};

const Admin = () => {
  // Rest of the Admin component code...
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [data, setData] = useState([
    {
      id: 0,
      username: '',
      phone: '',
      email: '',
      name: '',
      hashkey: '',
      password: '',
      role: '',
      isActive: true,
    },
    // Add more data objects as needed
  ]);

  const [myObject, setMyObject] = useState({
    Id: 0,
    AdminId: 1,
    Adminimage: "a",
    ImageType: "imageSlider",
    FormFile: null,
  });

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setMyObject({
      ...myObject,
      FormFile: file,
    });
  };

  const handleInputChange = (event) => {
    const type = event.target.value;
    setMyObject({
      ...myObject,
      ImageType: type,
    });
  };

  const handleData = () => {
    fetch('https://localhost:7290/api/Users/GetUnApprovedAgent', {
      method: 'GET',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
      },
    })
      .then(async (data) => {
        var myData = await data.json();
        console.log(myData);
        setData(myData);
      })
      .catch((error) => {
        console.error(error);
      });
  };
  const postToDb = () => {
            const formData = new FormData();
              formData.append('Id', myObject.Id);
              formData.append('AdminId', myObject.AdminId);
               formData.append('Adminimage', myObject.Adminimage);
               formData.append('ImageType', myObject.ImageType);
                formData.append('FormFile', myObject.FormFile);
    
                console.log(myObject);
    
    
               const apiUrl = "https://localhost:7290/api/Gallery/PostGalleryImage";
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
    

  useEffect(() => {
    handleData();
  }, []);

  var handleApprove = (item) => {
    const toapprove = {
      id: item.id,
      username: item.username,
      phone: item.phone,
      email: item.email,
      name: item.name,
      hashkey: item.hashkey,
      password: item.password,
      role: item.role,
      isActive: true,
    };

    console.log(toapprove);
    const apiUrl = "https://localhost:7290/api/Users/ApproveAgent";
    fetch(apiUrl, {
      method: 'PUT',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ ...toapprove }),
    })
      .then(async (data) => {
        if (data.status === 200) {
          var myData = await data.json();
          console.log(myData);
        } else {
          alert('Invalid username or password');
        }
      })
      .catch((err) => {
        console.log(err.error);
      });

    window.location.reload();
  };

  const handleDecline = (item) => {
    const todecline = {
      id: item.id,
      username: item.username,
      phone: item.phone,
      email: item.email,
      name: item.name,
      hashkey: item.hashkey,
      password: item.password,
      role: item.role,
      isActive: true,
    };

    console.log(todecline);
    const apiUrl = "https://localhost:7290/api/Users/DeleteAgent";
    fetch(apiUrl, {
      method: 'Delete',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({ ...todecline }),
    })
      .then(async (data) => {
        if (data.status === 200) {
          var myData = await data.json();
          console.log(myData);
        } else {
          alert('Invalid username or password');
        }
      })
      .catch((err) => {
        console.log(err.error);
      });

    window.location.reload();
  };

  return (
    <>
      <div>
        <button onClick={() => setModalIsOpen(true)}>Open Popup</button>
        <Popup
          modalIsOpen={modalIsOpen}
          setModalIsOpen={setModalIsOpen}
          handleFileChange={handleFileChange}
          handleInputChange={handleInputChange}
          postToDb={postToDb}
        />
      </div>
      <div className="table-container">
        <table className="responsive-table">
          <thead>
            <tr>
              <th>Username</th>
              <th>Phone</th>
              <th>Email</th>
              <th>Name</th>
              <th>Role</th>
              <th>Action</th>
            </tr>
          </thead>
          <tbody>
          {data.map((item, index) => {
  if (item.username !== '') {
    return (
      <tr key={index}>
        <td>{item.username}</td>
        <td>{item.phone}</td>
        <td>{item.email}</td>
        <td>{item.name}</td>
        <td>{item.role}</td>
        <td>
          <button className='Approvebutton' type="button" onClick={() => handleApprove(item)}>Approve</button>
          <button className='Declinebutton' type="button" onClick={() => handleDecline(item)}>Decline</button>
        </td>
      </tr>
    );
  } else {
    return null; // Return null if item.username is empty to skip rendering the row
  }
})}
          </tbody>
        </table>
      </div>
    </>
  );
};

export default Admin;