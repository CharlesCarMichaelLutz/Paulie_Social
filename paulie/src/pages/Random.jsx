import React, { useState } from 'react';
import UserCard from './UserCard';
import Popup from './usePopup';

const Random = ({userCards}) => {

  const [isOpen, setIsOpen] = useState(false);

  const togglePopup = () => {
    setIsOpen(!isOpen)
  }

  const cards = userCards.map(user => {
    return(
      <UserCard key={user.username} user={user} />
    )
  })

  const content = userCards.filter(user => {
    return(
      <UserCard key={user.username} user={user} />
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
        content={ <>
          <h3>This is a random tweet</h3>
          <br></br>
          <p><bold>SlimJim</bold></p>
          <p>@slimjim99</p>
          <br></br>
          <p>
            It is a beautiful day in the neigborhood
          </p>
          </>
        }
        handleClose={togglePopup}
      />}
      
    </div>
  )

}

export default Random;
