import React, {useState} from 'react'
import ChirpCard from './ChirpCard';
import userImage from '../parrot1.jpg';
import chirpImage from '../bigparrot.jpg';

const Explore = () => {

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
      chirpcontent: 'This is a really awesome platform!',
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

  const chirpCards = chirps.map(chirp => {
    return(    
        <ChirpCard key={chirp.username} chirp={chirp}/> 
    )
  })

  return (
    <>
      <h3>Explore Chirps of Users from Paulie Social</h3>   
       {chirpCards}
    </>
  )
}

export default Explore;
