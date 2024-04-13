import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <>
      <nav className="nav">
        <img src="/parrot1.jpg" className="navbar--avatar" alt="paulie logo" />
        <h1>Paulie Social</h1>
        <ul>
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
