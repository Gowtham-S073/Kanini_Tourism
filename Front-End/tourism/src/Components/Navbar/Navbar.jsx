import React, { useState } from "react";
import logo from "../../Assests/logo.png";
import { GiHamburgerMenu } from "react-icons/gi";
import { VscChromeClose } from "react-icons/vsc";
import { Nav, ResponsiveNav } from "./NavbarStyles";
import { BsFillArrowRightCircleFill } from "react-icons/bs";
import { BsHouseFill } from "react-icons/bs"

export default function Navbar() {
  const [navbarState, setNavbarState] = useState(false);
  return (
    <>
      <Nav>
        <div className="brand">
          <div className="container">
            <img src={logo} style={{width:'250px', borderRadius:'30px', marginLeft:'20px'}} alt="" />

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
            <a href="#home"><BsHouseFill></BsHouseFill> Home </a>
          </li>
          <li>
            <a href="#services">About </a>
          </li>
          <li>
            <a href="#recommend">Places</a>
          </li>
          <li>
            <a href="#testimonials">Testimonials</a>
          </li>
        </ul>
        <button> <BsFillArrowRightCircleFill /> Connect</button>
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
          <li>
            <a href="#testimonials" onClick={() => setNavbarState(false)}>
              Testimonials
            </a>
          </li>
        </ul>
      </ResponsiveNav>
    </>
  );
}
