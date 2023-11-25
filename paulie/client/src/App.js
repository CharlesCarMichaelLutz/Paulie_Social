import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import "./styles.css";
import Layout from "./components/Layout";
import Home from "./pages/Home";
import Explore from "./pages/Explore";
import Random from "./pages/Random";

function App() {
  return (
    <>
      <Router>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="Explore" element={<Explore />} />
            <Route path="Random" element={<Random />} />
          </Route>
        </Routes>
      </Router>
    </>
  );
}

export default App;
