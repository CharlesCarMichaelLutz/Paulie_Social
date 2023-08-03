import React,{useState} from 'react'
import axios from 'axios';
//import { endpoints } from '../Endpoints';
import TweetCard from '../components/TweetCard';

const Explore = () => {

  const [searchTerm, setSearchTerm] = useState('')
  const [tweets, setTweets] = useState([])
  const [radioButtonValue, setRadioButtonValue] = useState('username')

  const onInputChange = (e) => {
    setSearchTerm(e.target.value)
  }

  const onRadioButtonChange = (e) => {
    setRadioButtonValue(e.target.value)
  }

  const getTweets = (e) => {
    e.preventDefault()

    if(searchTerm) {
      const apiEndpoint = radioButtonValue === 'username' 
        ? `/api/explore/${searchTerm}` 
        : `/api/explore/content/${searchTerm}`

        axios
        .get(apiEndpoint)
        .then((res) => {
          setTweets(res.data)
          console.log('search query: ', res.data)
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }

  const renderTweets = tweets.length === 0 ? 
    <p>No tweets found</p> :
      tweets.map((tweetObject) => 
          tweetObject.data.map((tweet, index) => (
                <TweetCard 
                  key={index} 
                  tweetList={tweet} 
                  //media={tweetObject.includes.media}
                  user={tweetObject.includes.users}
                />
          ))
    ) 
   
  return (
    <div className="container">
      <header className='explore--header'>
        <h2>Explore Chirps from Paulie Social</h2> 
      </header>

      <form onSubmit={getTweets}>
        <section className='group--radio'>
          <label className="btn btn-outline-success">Username</label>
            <input
              type="radio"
              className='btn-check' 
              value='username' 
              id="btn-1"
              checked={radioButtonValue === 'username'}
              onChange={onRadioButtonChange}
            />
          <label class="btn btn-outline-success">Content</label>
            <input 
              type="radio"
              className='btn-check'
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

      <div className='list--tweets'>
        <ul>
          {renderTweets}
        </ul>
      </div>
    </div>
  )
}

export default Explore;
