import React from 'react'
//import Media from './Media'

const TweetCard = ({tweetList, user}) => {

  const {text, public_metrics} = tweetList
  const {profile_image_url ,username} = user

  return (
        <div className="card-container">
            <div className="user-info">
                {console.log('user image:', profile_image_url)}
                <img src={profile_image_url} alt="userImage"/>
                <h6 className="card-title">{username}</h6>
            </div>
            <p className="card-text">{text}</p>
            <p>{public_metrics.like_count} likes</p>
            <p>{public_metrics.retweet_count} retweets</p>
            {/* media && <Media mediaData={media}/> */}
        </div>
  )
}

export default TweetCard

/*
  const extractUrl = (urlString) => {
    return urlString.substring(1, urlString.length -1)
  }
  
  const imageUrl = extractUrl(profile_image_url)

  //const username = user.username

  //const profile_image_url = user.profile_image_url.replace(/"/g, '')

  //const shavedUrl = profile_image_url.replace(/"/g, '')

*/