import { BrowserRouter, Routes, Route } from 'react-router-dom';
import '@coreui/coreui/dist/css/coreui.min.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Layout from './pages/Layout';
import Home from './pages/Home';
import Explore from './pages/Explore';
import Random from './pages/Random';
import NoPage from './pages/NoPage';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>  
          <Route 
          index element={
          <Home />
          } />
          <Route 
          path="Explore" 
          element={
          <Explore />
          } />
          <Route 
          path="Random" 
          element={
          <Random />
          } />
          <Route 
          path="*" 
          element={
          <NoPage />
          } />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
