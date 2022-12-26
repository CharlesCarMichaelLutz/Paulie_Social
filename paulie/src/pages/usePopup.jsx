import React from 'react'

const usePopup = ({content, handleClose}) => {

  return (
    <div className='popup--box'>
      <div className='box'>
        <span className='close--icon' onClick={handleClose}>X</span>
        {content}
      </div>
    </div>
  )
}

export default usePopup