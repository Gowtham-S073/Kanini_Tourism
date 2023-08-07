import styled from "styled-components";

export const Nav = styled.nav`
display: flex;
justify-content: space-between;
align-items: center;
padding-top: 18px;
padding-bottom: 18px;
.brand {
  .container {
    cursor: pointer;
    display: flex;
    justify-content: center;
    align-items: center;
    gap: 0.4rem;
    font-size: 1.2rem;
    font-weight: 900;
    text-transform: uppercase;
  }
  .toggle {
    display: none;
  }
}
ul {
  display: flex;
  gap: 1rem;
  list-style-type: none;
  li {
    p {
      text-decoration: none;
      padding-top:10px;
      color: #0077b6;
      font-weight:bolder;
      padding:12px;
      border-radius: 30px;
      transition: 0.1s ease-in-out;
      &:hover {
        color: #ffff;
        background-color: #007bff;
      }
    }
    &:first-of-type {
      p {
        color: #023e8a;
        font-weight:bolder;
        &:hover{
            color: #ffff;
            background-color:#007bff;
            text-decoration:none;
        }
      }
    }
  }
}
button {
  padding: 0.5rem 1rem;
  cursor: pointer;
  border-radius: 1rem;
  border: none;
  color: white;
  background-color: #023e8a;
  font-size: 1.1rem;
  letter-spacing: 0.1rem;
  text-transform: uppercase;
  transition: 0.3s ease-in-out;
  &:hover {
    background-color: #48cae4;
  }
}
@media screen and (min-width: 280px) and (max-width: 1080px) {
  .brand {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    .toggle {
      display: block;
    }
  }
  ul {
    display: none;
  }
  button {
    display: none;
  }
}`;

export const ResponsiveNav = styled.div`
display: flex;
position: fixed;
z-index: 1;
top: ${({ state }) => (state ? "50px" : "-400px")};
background-color: white;
height: 30vh;
width: 100%;
align-items: center;
transition: 0.3s ease-in-out;
ul {
  list-style-type: none;
  width: 100%;
  li {
    width: 100%;
    margin: 1rem 0;
    margin-left: 2rem;
    text-decoration: none;
    p {
      text-decoration: none;
      color: #0077b6;
      font-size: 1.2rem;
      transition: 0.1s ease-in-out;
      &:hover {
        color: #023e8a;
      }
    }
    &:first-of-type {
      p {
        color: #023e8a;
        font-weight: 900;
      }
    }
  }
}`;
