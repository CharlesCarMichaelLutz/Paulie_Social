import React from 'react'
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CCardText } from '@coreui/react';
import { CCardLink } from '@coreui/react';
import { CButtonGroup } from '@coreui/react';
import { CButton } from '@coreui/react';


const ChirpCard = ({chirp}) => {

  let {username, userhandle, chirpcontent, chirpLink, likes, retweets, donations} = chirp
  return (
  <div>
  <CCard style={{width: '18rem'}}>
      <CCardBody>
        <CCardTitle>{username}</CCardTitle>
        <CCardSubtitle>{userhandle}</CCardSubtitle>
        <CCardText>
          {chirpcontent}
        </CCardText>
    <CCardLink>{chirpLink}</CCardLink>
      </CCardBody>
      <CButtonGroup>
        <CButton>{likes}</CButton>
        <CButton>{retweets}</CButton>
        <CButton>{donations}</CButton>
      </CButtonGroup>
  </CCard>
  </div>
  )
}

/*
implement images later 

  <CCard style={{width: '18rem'}}>
    <CCardImage>{props.userImage}</CCardImage>
      <CCardBody>
        <CCardTitle>{props.username}</CCardTitle>
        <CCardSubtitle>{props.userhandle}</CCardSubtitle>
        <CCardText>
          {props.chirp}
        </CCardText>
    <CCardImage>{props.chirpImage}</CCardImage>    
    <CCardLink>{props.chirpLink}</CCardLink>
      </CCardBody>
      <ButtonGroup>
        <CButton>Hearts</CButton>
        <CButton>Re:chirps</CButton>
        <CButton>Donations</CButton>
      </ButtonGroup>
  </CCard>

*/

export default ChirpCard