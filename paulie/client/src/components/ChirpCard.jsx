import React from 'react';

const ChirpCard = ({passing}) => {

  const {id, author_id, text} = passing

  return (
    <li key={id}>
      <div class="card">
          <h5 className="card-title">{id}</h5>
          <h6 className="card-title">{author_id}</h6>
          <p className="card-text">{text}</p>
      </div>
    </li>

  )
}

export default ChirpCard

