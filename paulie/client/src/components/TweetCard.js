import React from 'react'
import Media from './Media'

const TweetCard = ({ tweetList: { text, public_metrics }, user: { profile_image_url, username }, mediaData}) => {

  return (
        <div className="card-container">
            <div className="user-info">
                <img src={profile_image_url} alt="userImage"/>
                <h6 className="card-title">{username}</h6>
            </div>
            <p className="card-text">{text}</p>
            <p>{public_metrics.like_count} likes</p>
            <p>{public_metrics.retweet_count} retweets</p>
            {mediaData && <Media mediaData={mediaData}/>}
        </div>
  )
}

export default TweetCard;
