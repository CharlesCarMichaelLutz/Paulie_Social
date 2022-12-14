import React, { useState } from 'react';
import UserCard from './UserCard';
import userImage from '../parrot1.jpg';
import chirpImage from '../bigparrot.jpg';


const Random = () => {

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

  const cards = userCards.map(user => {
    return(
      <UserCard key={user.username} user={user}/>
    )
  })
  
  return (
    <div>

      <header className='random--header'>
        <h3>Get Random Chirps from your favorite users below</h3>  
      </header>

      <div class="container" className='user--card' onClick={alert} >
        {cards}
      </div>
    </div>
  )

}

export default Random;

/*

() => usePopup(chirp)

state

featuredUsers

randomChirps

*/