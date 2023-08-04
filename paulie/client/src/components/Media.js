import React from 'react'
//import { extractUrl } from './TweetCard'

const Media = ({mediaData}) => {

  //const mediaUrl = extractUrl(tweet.url)

  return (
    <div>
      {mediaData.map(tweet, index => {
        switch(tweet.type) {
          case 'animated_gif':
            return  <img key={index} src={tweet.url} alt="gif"/>
          case 'photo':
            return <img key={index} src={tweet.url} alt="image"/>
          case 'video':
            return <video controls>
                      <source key={index} src={tweet.url} type="video/mp4"/>
                   </video>
          default:
            return null
        }
       })}
    </div>
  )
}

export default Media