import React,{useState} from 'react'
import axios from 'axios';
import { endpoints } from '../Endpoints';
//import ChirpCard from '../components/ChirpCard';
//import TweetCard from '../components/TweetCard';

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
        ? `explore/${searchTerm}` 
        : `explore/content/${searchTerm}`

      axios
        .get(endpoints.BASE_URI + apiEndpoint)
        .then((res) => {
          setTweets(res.data)
          console.log('search query: ', res.data)
        })
        .catch((error) => {
          console.log(error)
        })
      }
    }

  const displayedTerm = tweets.flatMap((tweetObject) => (
   
    tweetObject.data.map((tweet, index) => (
          <li key={index}>
            <h5 className="card-title">{tweet.id}</h5>
            <h6 className="card-title">{tweet.author_id}</h6>
            <p className="card-text">{tweet.text}</p>
            <p>{tweet.public_metrics.like_count}</p>
            <p>{tweet.public_metrics.retweet_count}</p>
          </li>
    ))
  )) 
   
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
          {displayedTerm}
        </ul>
      </div>
        
    </div>
  )
}

export default Explore;


/* 
 
<ChirpCard passing={tweet} />

does not work as expected

     const displayedTerm = tweets.map((tweetObject) => {
    const dataArray = tweetObject.data
      return (
        <li key={tweetObject.id}>
          {dataArray.map((tweet, index) => (
              <li key={index}>
                <h5 className="card-title">{tweet.id}</h5>
                <h6 className="card-title">{tweet.author_id}</h6>
                <p className="card-text">{tweet.text}</p>
                <p>{tweet.public_metrics.like_count}</p>
                <p>{tweet.public_metrics.retweet_count}</p>
              </li>
          ))}
        </li>
      )
  })


   <div className='list--tweets'>
        <ul>
          {displayedTerm}
        </ul>
      </div>

*/