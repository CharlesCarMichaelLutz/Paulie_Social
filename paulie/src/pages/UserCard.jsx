import React from 'react'
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CImage } from '@coreui/react';

const UserCard = ({user}) => {

  let {username, userhandle, userImage} = user
  return (
    <div>
        <CCard style={{width: '325px'}}>
          <CCardBody>
            <CImage align="center" rounded src={userImage} width={275} height={275} />
            <CCardTitle>{username}</CCardTitle>
            <CCardSubtitle>{userhandle}</CCardSubtitle>
          </CCardBody>
        </CCard>    
    </div>
  )
}

export default UserCard