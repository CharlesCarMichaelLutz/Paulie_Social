import React, {useState} from 'react'
//import { Alert} from '@coreui/react';
//import { useState, createContext, useContext } from "react";
//import Chirp from './components/Chirp';
import ChirpCard from './ChirpCard';

const Explore = (props) => {

  const [chirps] = useState([
      {
        username: 'Philharmonic',
        userhandle: '@philharmonic',
        chirpcontent: 'This is a really cool group!',
        chirpLink: 'www.classicalmusic.com',
      },
      {
        username: 'Jammin',
        userhandle: '@jamminCA',
        chirpcontent: 'I like this tune',
        chirpLink: 'www.espn.com',
      },
      {
        username: 'DeFiGravity',
        userhandle: '@78defigravity',
        chirpcontent: 'This is a really awesome platform!',
        chirpLink: 'www.coingecko.com',
      },
      {
        username: 'Beauty',
        userhandle: '@beautiful',
        chirpcontent: 'This is a real beauty',
        chirpLink: 'www.beauty.com',
      },
      {
        username: 'swimfest',
        userhandle: '@swimfest11',
        chirpcontent: 'This is a really sweet event',
        chirpLink: 'www.radixdlt.com',
      }
    ])

  let chirpCards = chirps.map(chirp => {
    return(
      
        <ChirpCard key={chirp.username} chirp={chirp}/>
    
    )
  })

  return (
    <>
      <h2>Explore Chirps of Users from Paulie Social</h2>

        
         {chirpCards}
  
    </>
  )
}

export default Explore;
