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
    <div class="container">

      <header className='explore--header'>
        <h2>Explore Chirps from Paulie Social</h2>   
      </header>

      <section className="search--area">
        <section class="btn-group">
          <input type="checkbox" class='btn-check' id='btn1' />
          <label class="btn btn-outline-success" for="btn1">Username</label>
          <input type="checkbox" class='btn-check' id='btn2' />
          <label class="btn btn-outline-success" for="btn2">Content</label>
        </section>
      
        <input placeholder=".....explore" type="text" className='form--control'/>
      </section>

      <main className='main--explore'>
        <div class='container' className='chirp--card'>   
          {chirpCards}
        </div>
      </main>

    </div>
  )
}

export default Explore;
