import React,{useSate} from 'react'
import ChirpCard from './ChirpCard';

const Explore = ({chirps}) => {

  const [toggle, setToggle] = useState(false)
  //lookup searchTerm from SWAPI 

  const tweets = chirps.map(chirp => {
    return(    
      <ChirpCard key={chirp.username}  chirp={chirp} /> 
    )
  })

  return (
    <div class="container">
  
      <header className='explore--header'>
        <h2>Explore Chirps from Paulie Social</h2>   
      </header>

      <section className="search--area">
        <section class="btn-group" className='group--radio' >
          <input type="radio" name="btnradio" class='btn-check' id='btn1' checked/>
          <label class="btn btn-outline-success" for="btn1">Username</label>
          <input type="radio" name="btnradio" class='btn-check' id='btn2' checked/>
          <label class="btn btn-outline-success" for="btn2">Content</label>
        </section>
      
        <input placeholder=".....explore" type="text" className='form--control'/>
      </section>
  
      <main className='main--explore'>
        <div class='container' className='chirp--card'>   
          {tweets}
        </div>
      </main>

    </div>
  )
}

export default Explore;
