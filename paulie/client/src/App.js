import React, {useState} from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import axios from 'axios';
//import 'bootstrap/dist/css/bootstrap.min.css';
import { endpoints } from './Endpoints';
import './App.css';
import userImage from './bigparrot.jpg';
import chirpImage from './parrot1.jpg';
import Layout from './pages/Layout';
import Home from './pages/Home';
import Explore from './pages/Explore';
import Random from './pages/Random';
import NoPage from './pages/NoPage';

function App() {

  const [searchTerm, setSearchTerm] = useState('')
  const [tweets, setTweets] = useState([])
  const [radioButtonValue, setRadioButtonValue] = useState('username')

  const onInputChange = (e) => {
    setSearchTerm(e.target.value)
  }

  const onRadioButtonChange = (e) => {
    setRadioButtonValue(e.target.value)
  }

  const getTweets = (e) => {
    e.preventDefault()

    if(searchTerm) {
      const apiEndpoint = radioButtonValue === 'username' 
        ? `explore/${searchTerm}` 
        : `explore/content/${searchTerm}`

      axios
        .get(endpoints.BASE_URI + apiEndpoint)
        .then((res) => {
          setTweets(res.data)
          console.log('search query: ', res.data)
        })
        .catch((error) => {
          console.log(error)
        })
      }
    }

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>
          <Route index element={ <Home /> } />
          <Route path="Explore" element={ 
            <Explore 
            tweets={tweets}
            radioButtonValue={radioButtonValue}
            onInputChange={onInputChange}
            onRadioButtonChange={onRadioButtonChange}
            getTweets={getTweets}
            //searchTerm={searchTerm}
             />} />
          <Route path="Random" element={ <Random />} />
          <Route path="*" element={ <NoPage /> } />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
