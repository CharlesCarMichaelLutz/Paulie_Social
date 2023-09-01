// import React from 'react'
// import Media from './Media'

// const TweetCard = ({ tweetList: { text, public_metrics }, user: { profile_image_url, username }, mediaData}) => {

//   return (
//         <div className="card-container">
//             <div className="user-info">
//                 <img src={profile_image_url} alt="userImage"/>
//                 <h6 className="card-title">{username}</h6>
//             </div>
//             <p className="card-text">{text}</p>
//             <p>{public_metrics.like_count} likes</p>
//             <p>{public_metrics.retweet_count} retweets</p>
//             {mediaData && <Media mediaData={mediaData}/>}
//         </div>
//   )
// }

// export default TweetCard;

import React from 'react'
import Media from './Media'

const TweetCard = ({ tweetList: { text, public_metrics }, user: { profile_image_url, username }, mediaData}) => {

  return (
        <div className="card card-container">
            <div className="card-body user-info">
                <img src={profile_image_url} alt="userImage" className="profile-image"/>
                <h6 className="card-title">{username}</h6>
            </div>
            <p className="card-text tweet-text">{text}</p>
              {mediaData && <Media mediaData={mediaData}/>}
            <div className="card-footer">
              <p className="card-text likes-count">{public_metrics.like_count} likes</p>
              <p className="card-text retweets-count">{public_metrics.retweet_count} retweets</p>
            </div>
        </div>
  )
}

export default TweetCard;
