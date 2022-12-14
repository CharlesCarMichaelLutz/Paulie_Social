import React from 'react'
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CCardImage } from '@coreui/react';
import { CContainer } from '@coreui/react';

const UserCard = ({user}) => {

  let {username, userhandle, userImage} = user
  return (
    <div>
        <CCard>
          <CCardBody>
            <CCardImage orientation="top" src={userImage} />
            <CCardTitle>{username}</CCardTitle>
            <CCardSubtitle>{userhandle}</CCardSubtitle>
          </CCardBody>
        </CCard>    
    </div>
  )
}

export default UserCard