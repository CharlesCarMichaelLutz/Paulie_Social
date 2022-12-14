import React from 'react'
import ChirpCard from './ChirpCard'

const usePopup = (cards) => {

  const cards = userCards.map(user => {
    return(
      <ChirpCard key={user.username} user={user}/>
    )
  })
  return (
    <div>
      {user}
    </div>
  )
}

export default usePopup