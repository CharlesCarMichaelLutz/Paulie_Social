import React from "react";
import { Link } from "react-router-dom";
import parrot1 from "../static/parrot1.jpg";
const Navbar = () => {
  return (
    <>
      <nav>
        <ul className="navbar--list">
          <img src={parrot1} alt="navbar logo" className="navbar--logo" />
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/Explore">Explore</Link>
          </li>
          <li>
            <Link to="/Random">VIP</Link>
          </li>
        </ul>
      </nav>
    </>
  );
};

export default Navbar;
