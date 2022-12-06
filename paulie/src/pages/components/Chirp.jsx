import React from 'react';
//import { BrowserRouter, Route, Link} from 'react-router-dom';
import { ButtonGroup } from 'react-bootstrap';
//import { Alert } from '@coreui/react';
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CCardText } from '@coreui/react';
import { CCardLink } from '@coreui/react';
import { CButton } from '@coreui/react';
import { CCardImage } from '@coreui/react';
//import { useState, createContext, useContext } from "react";

const Chirp = (props) => {

  return (
    <div>
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
    </div>
  )
}

export default Chirp

/*
<CCardImage orientation="top" src="/images/reac.jpg"/>

<CCardImage orientation="bottom" src="/images/reac.jpg"/>

*/