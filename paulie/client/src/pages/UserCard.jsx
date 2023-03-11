import React from 'react';

const UserCard = ({user}) => {

  let {username, userhandle, userImage} = user
  return (
    <div class="card text-white bg-success mb-3">
        <div class='card-body' style={{width: '325px'}}>
            <img  class="card-img-top"align="center" rounded src={userImage} width={275} height={275} />
            <br></br>
            <h5 class="card-title">{username}</h5>
            <h6 class="card-title">{userhandle}</h6>
        </div>    
    </div>
  )
}

export default UserCard

/*

import tags needed

import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CImage } from '@coreui/react';

Syntax for card creation

  <div>
        <CCard style={{width: '325px'}}>
          <CCardBody>
            <CImage align="center" rounded src={userImage} width={275} height={275} />
            <br></br>
            <CCardTitle>{username}</CCardTitle>
            <CCardSubtitle>{userhandle}</CCardSubtitle>
          </CCardBody>
        </CCard>    
    </div>

*/