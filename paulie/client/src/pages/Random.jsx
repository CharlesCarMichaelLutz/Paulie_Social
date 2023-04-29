import React, { useState } from 'react';
import UserCard from './UserCard';
import ChirpCard from './ChirpCard';
import Popup from './usePopup';
import { endpoints } from '../Endpoints';
import axios from 'axios';


const Random = ({userCards, chirps}) => {

  // const [VIPTweet, getVIPTweet] = useState([])
  // const [VIPUser, getVIPUser] = useState([])

  axios.get(endpoints.BASE_URI+`randomVip`)

  const [isOpen, setIsOpen] = useState(false);

  const togglePopup = () => {
    setIsOpen(!isOpen)
  }

  const cards = userCards.map(user => {
    return(
      <UserCard key={user.username} user={user} />
    )
  })

  const content = chirps.map(user => {
    const random = Math.floor(Math.random() * chirps.length)
    const item = chirps[random]
    console.log("Item:", item)
    return(
      <ChirpCard key={item.username} user={user} />
    )
  })

  return (
    <div>
      <header className='random--header'>
        <h3>Get Random Chirps from your favorite users below</h3>  
      </header>

      <div class="container" className='user--card' onClick={togglePopup} >
        {cards}
      </div>
 
      {isOpen && <Popup       
        content={content}
        handleClose={togglePopup}
      />}
    </div>
  )

}

export default Random;

/*
<>
          <h3>This is a random tweet</h3>
          <br></br>
          <p><bold>SlimJim</bold></p>
          <p>@slimjim99</p>
          <br></br>
          <p>
            It is a beautiful day in the neigborhood
          </p>
          </>

*/