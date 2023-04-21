import React from 'react'

const usePopup = ({content, handleClose}) => {

  let {userImage, username, userhandle, chirpcontent, chirpLink, chirpImage, likes, retweets, donations} = content
  return (

    <div className='popup--box'>
      <div className='box'>
      <span className='close--icon' onClick={handleClose}>X</span>
        <h1>{username}</h1>
        <p>{userhandle}</p>
        <p>{chirpcontent}</p>
        <p>{userImage}</p>
      </div>
    </div>
  )
}

export default usePopup
