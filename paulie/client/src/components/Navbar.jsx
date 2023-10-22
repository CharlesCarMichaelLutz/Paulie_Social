import { Link } from "react-router-dom";
//import parrot1 from "./static/parrot1.jpg";
import parrot1 from "../static/parrot1.jpg";

const Navbar = () => {
  return (
    <>
      <nav className="nav">
        <img className="navbar--avatar" src={parrot1} alt="avatar image" />
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
