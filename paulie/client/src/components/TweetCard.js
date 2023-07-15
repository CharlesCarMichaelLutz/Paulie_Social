import React from 'react'

const TweetCard = ({tweetList}) => {

  let {id, author_id, text, public_metrics} = tweetList

  return (
        <div key={id} className="card-container">
            <h5 className="card-title">{id}</h5>
            <h6 className="card-title">{author_id}</h6>
            <p className="card-text">{text}</p>
            <p>{public_metrics.like_count}</p>
            <p>{public_metrics.retweet_count}</p>
        </div>
  )
}

export default TweetCard
