import React from 'react'

const Media = ({mediaData}) => {
  return (
    <div>
      {mediaData.map(tweet, index => {
        switch(tweet.type) {
          case 'animated_gif':
            return  <img key={index} src={tweet.media_key} alt="gif"/>
          case 'photo':
            return <img key={index} src={tweet.media_key} alt="image"/>
          case 'video':
            return <video controls>
                      <source key={index} src={tweet.media_key} type="video/mp4"/>
                   </video>
          default:
            return null
        }
       })}
    </div>
  )
}

export default Media