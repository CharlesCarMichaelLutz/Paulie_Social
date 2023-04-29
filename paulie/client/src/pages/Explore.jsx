import React,{useState, useEffect} from 'react'
import ChirpCard from './ChirpCard';
import { endpoints } from '../Endpoints';
import axios from 'axios';
import { Button } from 'bootstrap';

//const Explore = ({chirps}) => {
const Explore = () => {

  const [searchTerm, setSearchTerm] = useState('')
  const [tweets, setTweets] = useState([])

  useEffect(() => {

  }, [])

  const handleChange = e => {
    setSearchTerm(e.target.value)
  }

  const getTweets = (e) => {
    e.preventDefault()

    axios.get(endpoints.BASE_URI+`explore/content/${searchTerm}`)
      .then((res) => {
        setTweets(res.data)
        console.log('search query: ',res.data)
      })

  // dual buttons
    // onToggleButton ?
    //   axios.get(BASE_URI+`explore/${searchTerm}`)
    //     .then((res) => {
    //       setTweets(res.data)
    //       console.log('search by content query: ',res.data)
    //   }) :
    //   axios.get(BASE_URI+`/api/explore/${username}`)
    //     .then((res) => {
    //       setTweets(res.data)
    //       console.log('search by username query: ',res.data)
    //   })
    }

 /* ------------------------------------------------------------------- */

 //B
  //const [searchTerm, setSearchTerm] = useState('')

  // const onToggleButton = e => {
  //   setSearchTerm(e.target.value)
  // }/

  // const tweets = chirps.map(chirp => {
  //   return(    
  //     <ChirpCard key={chirp.username}  chirp={chirp} /> 
  //   )
  // })

  // const filteredTerms =
  // chirps.filter((chirp) => {
  //   if(searchTerm == '') {
  //     return chirp
  //   }else if (chirp.username.toLowerCase().includes(searchTerm.toLowerCase())){
  //     return chirp 
  //   }
  // })

  // const filteredTerms =
  // chirps.filter((chirp) => {
  //   if(searchTerm == ''){
  //     return chirp
  //   }else if (chirp.username.toLowerCase().includes(searchTerm.toLowerCase())){
  //     return chirp 
  //   }else if(chirp.chirpcontent.toLowerCase().includes(searchTerm.toLowerCase())){
  //     return chirp
  //   }
  // })

  // const displayedTerm =
  // filteredTerms.map((chirp) => {
  //   return(
  //     <ChirpCard key={chirp.username}  chirp={chirp} /> 
  //   )
  //})


  return (
    <div class="container">

      <form className="search--area" onSubmit={getTweets}>  
        <input 
          placeholder=".....explore"
          type="text"
          className='form--control'
          onChange={handleChange}
          />
          <button 
          type="submit"
          className="btn2 btn-elegant btn-rounded btn-sm my-0"
          >
          Get Tweets
          </button>
      </form>

      {/* <header className='explore--header'>
        <h2>Explore Chirps from Paulie Social</h2>   
      </header>

      <section className="search--area">
        <section class="btn-group" className='group--radio' >

          <input
            type="radio"
            name="btnradio"
            class='btn-check' 
            id='btn1' 
            checked
            onChange={onToggleButton}
            />
          <label class="btn btn-outline-success" for="btn1">Username</label>

          <input 
            type="radio"
            name="btnradio"
            class='btn-check'
            id='btn2' 
            checked
            onChange={onToggleButton}
            />
          <label class="btn btn-outline-success" for="btn2">Content</label>
        </section>    

        <input 
          placeholder=".....explore"
          type="text"
          className='form--control'
          onChange={(e) => setSearchTerm(e.target.value)}
          />

      </section>
  
      <main className='main--explore'>
        <div class='container' className='chirp--card'>   
          {displayedTerm}
        </div>
      </main> */}

<table className="table table-striped">
      <thead>
        <tr>
          <th>Id</th>
          <th>Text</th>
        </tr>
      </thead>  
      <tbody>
        {tweets.map(tweet =>
          <tr key={tweet.id}>
            <td>{tweet.id}</td>
            <td>{tweet.text}</td>
          </tr>
          )}
      </tbody>
      </table>  

    </div>
  )
}

export default Explore;
