import React, { useState, useEffect } from "react";
import logo from "../../Assests/logo.png";
import { GiHamburgerMenu } from "react-icons/gi";
import { VscChromeClose } from "react-icons/vsc";
import { Nav, ResponsiveNav } from "./NavbarStyles";
import { BsFillArrowRightCircleFill } from "react-icons/bs";
import { BsHouseFill } from "react-icons/bs"
import { Link } from 'react-router-dom';
import { BrowserRouter, Route, Routes } from 'react-router-dom';


export default function Navbar() {
  const [selectedOption, setSelectedOption] = useState('user') // Default value is 'user'
  const [role, setRole] = useState(null)
  const [admin, setAdmin] = useState(false)
  const [userIn, setUser] = useState(false)
  const [agent, setAgent] = useState(false)
  const [nouser, setNoUser] = useState(false)

  useEffect(() => {
    // Retrieve the 'role' from sessionStorage
    const storedRole = sessionStorage.getItem('role')
    setRole(storedRole)
    if (storedRole === null) {
      setNoUser(true)
    } else if (storedRole === 'Admin') {
      setAdmin(true)
    } else if (storedRole === 'Agent') {
      setAgent(true)
    } else if (storedRole === 'User') {
      setUser(true)
    }
  }, [])
  const logoutFn = () => {
    // Remove all the stored data from sessionStorage
    sessionStorage.removeItem('token')
    sessionStorage.removeItem('id')
    sessionStorage.removeItem('name')
    sessionStorage.removeItem('email')
    sessionStorage.removeItem('role')

    // Navigate to the home page ("/")
    window.location.href = '/'
  }

  const handleSubmit = (event) => {
    event.preventDefault()
    // Handle form submission based on selectedOption value
    if (selectedOption === 'user') {
      // User signup logic
      console.log('User Signup')
    } else if (selectedOption === 'agent') {
      // Agent signup logic
      console.log('Agent Signup')
    }
  }

  const [navbarState, setNavbarState] = useState(false);
  return (
    <>
      <Nav>
        <div className="brand">
          <div className="container">
            <Link to="/">
              <img src={logo} style={{width:'250px', borderRadius:'30px', marginLeft:'20px'}} alt="" />
            </Link>
          </div>
          <div className="toggle">
            {navbarState ? (
              <VscChromeClose onClick={() => setNavbarState(false)} />
            ) : (
              <GiHamburgerMenu onClick={() => setNavbarState(true)} />
            )}
          </div>
        </div>

        <ul style={{fontSize:'25px', paddingTop:'20px'}}>
          <li>
          <Link to="/">
            <p href="#home"><BsHouseFill></BsHouseFill>Home</p>
          </Link>
          </li>
          <li>
            <Link to ="Admin">
            <p>Approve Agent</p>
            </Link>
          </li>
          <li>
            <Link to ="Login">
              <p>Login</p>
            </Link>
          </li>
          <li>
            <Link to="Agent">
            <p>Add Place</p>
            </Link>
          </li>
          <li>
            <Link to="Register">
            <p>Register</p>
            </Link>
          </li>
          <li>
            <Link to="Package">
            <p href="#testimonials">Packages</p>
            </Link>
          </li>
          <li>
            <Link to="ProductCard">
            <p href="#testimonials">Package Details</p>
            </Link>
          </li>
          <li>
            <Link to='Gallery'>
              <p>Gallery</p>
            </Link>
          </li>
          <li>
            <p href="#testimonials">Logout</p>
          </li>
        </ul>
        <button> <BsFillArrowRightCircleFill />Connect</button>
      </Nav>
      <ResponsiveNav state={navbarState}>
        <ul>
          <li>
            <a href="#home" onClick={() => setNavbarState(false)}>
              Home
            </a>
          </li>
          <li>
            <a href="#services" onClick={() => setNavbarState(false)}>
              About
            </a>
          </li>
          <li>
            <a href="#recommend" onClick={() => setNavbarState(false)}>
              Places
            </a>
          </li>
        
        </ul>
      </ResponsiveNav>
    </>
  );
}
