import React from 'react';

const ChirpCard = ({passing}) => {

  let {id, author_id, text, public_metrics, attachments} = passing

  return (
    <div class="card-"key={id}>
        <h5 className="card-title">{id}</h5>
        <h6 className="card-title">{author_id}</h6>
        <p className="card-text">{text}</p>
    </div>
  )
}

export default ChirpCard

