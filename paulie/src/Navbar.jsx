import React from 'react';
import { BrowserRouter, Route, Link} from 'react-router-dom';

const Navbar = () => {
  return (
    <nav>
      <ul>
        <li>
          <Link to="/">Home</Link>
        </li>
        <li>
          <Link to="/Explore">Contact</Link>
        </li>
        <li>
          <Link to="/Random">Random</Link>
        </li>
      </ul>
    </nav>
  );
}

export default Navbar;