import React from 'react'
import { ButtonGroup } from 'react-bootstrap';
import { Alert, CCardTitle } from '@coreui/react';
import Chirp from '../Chirp';
import { Outlet } from 'react-router-dom';

const Explore = () => {
  return (
    <>
      <h2>Explore Chirps of Users from Paulie</h2>
      <Chirp cardTitle={CCardTitle}/>
      <Outlet />
    </>
  )
}

export default Explore;
