import React from 'react'

const TweetCard = ({passing}) => {

  let {id, author_id, text, public_metrics, attachments} = passing

  return (
        <ul
          key={id} className="card-container"
        >
          <p>
            <strong>{author_id}</strong>
          </p>
          <p>{id}</p>
          <p>{text}</p>
          {/*<h5>{public_metrics.retweet_count}</h5>
          <h5>{public_metrics.like_count}</h5>
          <p>{attachments.media_keys}</p>*/}
        </ul>
  )
}

export default TweetCard
