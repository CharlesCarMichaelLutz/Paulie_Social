import React from 'react'

const Media = ({mediaData}) => {

  return (
    <div>
      {mediaData.map((tweet, index) => {

        switch(tweet.type) {
          case 'photo':
              return <img key={index} src={tweet.url} alt="image"/>
          case 'animated_gif':
            if(Array.isArray(tweet.variants)) {
              return (
                tweet.variants.map((variant, varIndex) => (
                  <div key={varIndex}>
                  {console.log('gifUrl:', variant.url)}
                      <img src={variant.url} alt="gif"/>
                  </div>
                ))
              ) 
            }
            return null
          case 'video':
            if(Array.isArray(tweet.variants)) {
              return (
                tweet.variants.map((variant, varIndex) => (
                  <div key={varIndex}>
                    <video controls>
                    {console.log('videoUrl:', variant.url)}
                        <source src={variant.url}type="video/mp4"/>
                     </video>
                  </div>
                ))
              ) 
            }
            return null
          default:
            return null
        }
       })}
    </div>
  )
}

export default Media