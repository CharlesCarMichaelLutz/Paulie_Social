import React from 'react';

const VIPCard = ({user}) => {

  //static pictures will be passed in here
  //rename to VIPuser
  let {username, userhandle, userImage} = user
  return (
    <div class="card text-white bg-success mb-3">
        <div class='card-body' style={{width: '325px'}}>
            <img  class="card-img-top"
                  align="center"  
                  rounded src={userImage} 
                  width={275} 
                  height={275} />
            <br></br>
            <h5 class="card-title">{username}</h5>
            <h6 class="card-title">{userhandle}</h6>
        </div>    
    </div>
  )
}

export default VIPCard
