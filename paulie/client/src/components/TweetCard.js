import React from 'react'
import Media from './Media'

const TweetCard = ({tweetList}) => {

  let {id, author_id, text, public_metrics,media} = tweetList

  return (
        <div key={id} className="card-container">
            <h5 className="card-title">{id}</h5> {/* profile_image_url */}
            <h6 className="card-title">{author_id}</h6> {/* username */}
            <p className="card-text">{text}</p>
            <p>{public_metrics.like_count}</p>
            <p>{public_metrics.retweet_count}</p>
            {media && <Media mediaData={media}/>} {/* media.url*/}
        </div>
  )
}

export default TweetCard
