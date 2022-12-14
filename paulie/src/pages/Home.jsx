import React from 'react';
import image from '../bigparrot.jpg';
const Home = () => {

  return (
    <div class="container">

      <header className='home--header'>
        <h1>Welcome to Paulie Social!</h1>
      </header>

      <main class="container" className='main--home'>

        <p>
         Inspired by the movie Paulie(1998), and 
         creating my birdlike social application the 
         name "Paulie Social" fits just right. On this site you can navigate to the Explore page, and find tweets from whoever you like either by entering content or username. Also clicking on the Random page will allow you to select a user and view a random tweet of theirs. Enjoy the experience of Paulie Social.         
        </p>

        <img src={image} height={400} width={400} />  
      </main>

    </div>
  )
}

export default Home

//add link to Paulie in paragraph

//https://www.imdb.com/title/tt0125454/?ref_=nv_sr_srsg_0