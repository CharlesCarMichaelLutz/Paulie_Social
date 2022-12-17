import { BrowserRouter, Routes, Route } from 'react-router-dom';
import React, {useState} from 'react';
import '@coreui/coreui/dist/css/coreui.min.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import userImage from './bigparrot.jpg';
import chirpImage from './parrot1.jpg';
import Layout from './pages/Layout';
import Home from './pages/Home';
import Explore from './pages/Explore';
import Random from './pages/Random';
import NoPage from './pages/NoPage';

function App() {

  const [chirps] = useState([
    {
      userImage: userImage,
      username: 'Philharmonic',
      userhandle: '@philharmonic',
      chirpcontent: 'This is a really cool group!',
      chirpLink: 'www.classicalmusic.com',
      chirpImage: chirpImage,
      likes: "<3",
      retweets: "Re:",
      donations: "$$"
    },
    {
      userImage: userImage,
      username: 'Jammin',
      userhandle: '@jamminCA',
      chirpcontent: 'I like this tune',
      chirpLink: 'www.espn.com',
      chirpImage: chirpImage,
      likes: "<3",
      retweets: "Re:",
      donations: "$$"
    },
    {
      userImage: userImage,
      username: 'DeFiGravity',
      userhandle: '@78defigravity',
      chirpcontent: 'Bibendum neque egestas congue quisque. Quis lectus nulla at volutpat diam. Amet tellus cras adipiscing enim. Imperdiet massa tincidunt nunc pulvinar sapien. Ac tortor vitae purus faucibus ornare suspendisse sed nisi lacus. Sit amet justo donec enim. ',
      chirpLink: 'www.coingecko.com',
      chirpImage: chirpImage,
      likes: "<3",
      retweets: "Re:",
      donations: "$$"
    },
    {
      userImage: userImage,
      username: 'Beauty',
      userhandle: '@beautiful',
      chirpcontent: 'This is a real beauty',
      chirpLink: 'www.beauty.com',
      chirpImage: chirpImage,
      likes: "<3",
      retweets: "Re:",
      donations: "$$"
    },
    {
      userImage: userImage,
      username: 'swimfest',
      userhandle: '@swimfest11',
      chirpcontent: 'This is a really sweet event',
      chirpLink: 'www.radixdlt.com',
      chirpImage: chirpImage,
      likes: "<3",
      retweets: "Re:",
      donations: "$$"
    }
  ])

  const [userCards] = useState([
    {
      userImage: userImage,
      username: 'yeah123',
      userhandle: '@yeah123',
    },
    {
      userImage: chirpImage,
      username: '$$$Jammin',
      userhandle: '@jammin$$$AK',
    },
    {
      userImage: userImage,
      username: 'surfsUpBrah*',
      userhandle: '@surfsupbrah',
    },
    {
      userImage: chirpImage,
      username: 'Barstool',
      userhandle: '@sportsbarstool',
    },
    {
      userImage: userImage,
      username: 'swimfest',
      userhandle: '@swimfest11',
    }
  ])

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout/>}>  
          <Route index element={
            <Home />
          } />
          <Route path="Explore" element={
            <Explore chirps={chirps}/>
          } />
          <Route path="Random" element={
            <Random  userCards={userCards} chirps={chirps} />
          } />
          <Route path="*" element={
            <NoPage />
          } />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;

/*
pieces of state

Explore

1 chirps
   change based on searchTerm:
   * username * content

Random

2 featured users
   query for random tweet with onlick event 

*/