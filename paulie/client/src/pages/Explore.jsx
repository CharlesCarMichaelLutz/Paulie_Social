import React,{useState, useEffect} from 'react'
import ChirpCard from '../components/ChirpCard';
//import TweetCard from '../components/TweetCard';

const Explore = ({tweets, radioButtonValue, onInputChange, onRadioButtonChange, getTweets}) => {

    const displayedTerm = tweets.map((tweet) => {
      return(
        <ChirpCard key={tweet.id}  passing={tweet} />
      )
    }) 

  return (
    <div className="container">

      <header className='explore--header'>
        <h2>Explore Chirps from Paulie Social</h2>   
      </header>

      <form onSubmit={getTweets}>
        <section class="btn-group" className='group--radio' >

          <label class="btn btn-outline-success" for='btn-1'>Username</label>
            <input
              type="radio"
              name="btnradio"
              class='btn-check' 
              value='username' 
              id="btn-1"
              checked={radioButtonValue === 'username'}
              onChange={onRadioButtonChange}
              />

          <label class="btn btn-outline-success" for='btn-2'>Content</label>
            <input 
              type="radio"
              name="btnradio"
              class='btn-check'
              value='content' 
              id="btn-2"
              checked={radioButtonValue === 'content'}
              onChange={onRadioButtonChange}
              />
        </section>    

            <input 
              placeholder="explore...."
              type="text"
              className='search--bar'
              //value={searchTerm}
              onChange={onInputChange}
              />
          <button type="submit" className="submit--button">
            Get Tweets
          </button>
      </form>

      <main className='list--tweets'>
          {displayedTerm}
      </main>
        
    </div>
  )
}

export default Explore;
