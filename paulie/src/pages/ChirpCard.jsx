import React from 'react';

const ChirpCard = ({chirp}) => {

  let {userImage, username, userhandle, chirpcontent, chirpLink, chirpImage, likes, retweets, donations} = chirp

  return (
  <div class="card text-white bg-success mb-3">
    <div class="card-body">
        <div style={{width:"15%"}} class="bg-info rounded-circle">
          {userImage}
        </div>
        <span>
          <h5 class="card-title">{username}</h5>
          <h6 class="card-title">{userhandle}</h6>
        </span>
        <p class="card-text">{chirpcontent}</p>
        <img class="card-img-top" align="center" height={420} width={420} rounded src={chirpImage} />
        <a href='#' class="card-link">{chirpLink}</a>   
        <div class="btn-group" role="group" aria-label="Basic example">
          <button type="button" class="btn btn-danger">{likes}</button>
          <button type="button" class="btn btn-success">{retweets}</button>
          <button type="button" class="btn btn-warning">{donations}</button>
        </div>
    </div>
  </div>
  )
}

export default ChirpCard

/*

import tags needed

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

Syntax for card creation

 <CCard class="card text-white bg-success mb-3">
    <CCardBody>
        <CAvatar src={userImage}/>
        <CCardTitle>{username}</CCardTitle>
        <CCardSubtitle>{userhandle}</CCardSubtitle>
        <CCardText>
          <p>{chirpcontent}</p>
        </CCardText>
        <CImage align="center" height={420} width={420} rounded src={chirpImage} />
    </CCardBody>
        <CCardLink>{chirpLink}</CCardLink>   
        <CButtonGroup>
          <CButton>{likes}</CButton>
          <CButton>{retweets}</CButton>
          <CButton>{donations}</CButton> 
        </CButtonGroup>     
  </CCard>
*/