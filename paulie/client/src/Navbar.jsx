import React from 'react';
import { BrowserRouter, Route, Link} from 'react-router-dom';
import parrot1 from './parrot1.jpg';
const Navbar = () => {
  return (
    <nav>
      <ul className='my--list'>
        <img src={parrot1} alt={"chirping"} className="navbar--logo" />
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/Explore">Explore</Link>
        </li>
        <li>
          <Link to="/Random">Random</Link>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;