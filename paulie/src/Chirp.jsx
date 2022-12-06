import React from 'react'
import { ButtonGroup } from 'react-bootstrap';
import { Alert } from '@coreui/react';
import { CCard } from '@coreui/react';
import { CCardBody } from '@coreui/react';
import { CCardTitle } from '@coreui/react';
import { CCardSubtitle } from '@coreui/react';
import { CCardText } from '@coreui/react';
import { CCardLink } from '@coreui/react';
import { CButton } from '@coreui/react';
import { BrowserRouter, Route, Link} from 'react-router-dom';
//import { CCardImage } from '@coreui/react';

const Chirp = () => {
  return (
    <div>
      <CCard style={{width: '18rem'}}>
        <CCardBody>
          <CCardTitle>Username</CCardTitle>
          <CCardSubtitle>@user_handle</CCardSubtitle>
          <CCardText>
            "The full chirp goes here y'all"
          </CCardText>
          <CCardTitle>Username</CCardTitle>          
        </CCardBody>
        <CCardLink>Link</CCardLink>
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

download the rest of the npms and try

CButton 
*/