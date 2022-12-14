import React, {useState} from 'react'
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CCardText } from '@coreui/react';
import { CCardLink } from '@coreui/react';
import { CButtonGroup } from '@coreui/react';
import { CImage } from '@coreui/react';
import { CButton } from '@coreui/react';
import { CAvatar } from '@coreui/react';

const ChirpCard = ({chirp}) => {

  let {userImage, username, userhandle, chirpcontent, chirpLink, chirpImage, likes, retweets, donations} = chirp
  return (
  <div>
  <CCard>
    <CCardBody>
        <CAvatar src={userImage}/>
        <CCardTitle>{username}</CCardTitle>
        <CCardSubtitle>{userhandle}</CCardSubtitle>
        <CCardText>
          {chirpcontent}
        </CCardText>
        <CImage rounded src={chirpImage} align="center" height={420} width={420} />
    </CCardBody>
        <CCardLink>{chirpLink}</CCardLink>     
          <CButton>{likes}</CButton>
          <CButton>{retweets}</CButton>
          <CButton>{donations}</CButton>      
  </CCard>
  </div>
  )
}

export default ChirpCard
