import React, { useState } from 'react';
import UserCard from './UserCard';
import userImage from '../parrot1.jpg';

const Random = () => {

  const [userCards] = useState([
    {
      userImage: userImage,
      username: 'yeah123',
      userhandle: '@yeah123',
    },
    {
      userImage: userImage,
      username: '$$$Jammin',
      userhandle: '@jammin$$$AK',
    },
    {
      userImage: userImage,
      username: 'surfsUpBrah*',
      userhandle: '@surfsupbrah',
    },
    {
      userImage: userImage,
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

      <div class="container" className='user--card' onClick={alert}>
        {cards}
      </div>
    </div>
  )

}

export default Random;


/*
conditionally render 5 cards 

or

random chirp generated 

*/

/*

coolnes

   {
      userImage: userImage,
      username: 'yeah123',
      userhandle: '@yeah123',
    },
    {
      username: '$$$Jammin',
      userhandle: '@jammin$$$AK',
    },
    {
      username: 'surfsUpBrah*',
      userhandle: '@surfsupbrah',
    },
    {
      username: 'Barstool',
      userhandle: '@sportsbarstool',
    },
    {
      username: 'swimfest',
      userhandle: '@swimfest11',
    },
    {
      username: 'Philharmonic',
      userhandle: '@philharmonic',
    },
    {
      username: 'smoothmoves',
      userhandle: '@smoothmoves',
    },
    {
      username: 'DeFiGravity',
      userhandle: '@78defigravity',
    },
    {
      username: 'tortilla_Machine',
      userhandle: '@tortillamachine',
    },
    {
      username: 'PhanaticsNL',
      userhandle: '@PhanaticsNL',
    }

*/