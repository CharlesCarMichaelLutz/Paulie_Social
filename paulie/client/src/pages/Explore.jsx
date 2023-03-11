import React,{useState} from 'react'
import ChirpCard from './ChirpCard';

const Explore = ({chirps}) => {

  const [searchTerm, setSearchTerm] = useState('')

  const onToggleButton = e => {
    setSearchTerm(e.target.value)
  }

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

  const filteredTerms =
  chirps.filter((chirp) => {
    if(searchTerm == ''){
      return chirp
    }else if (chirp.username.toLowerCase().includes(searchTerm.toLowerCase())){
      return chirp 
    }else if(chirp.chirpcontent.toLowerCase().includes(searchTerm.toLowerCase())){
      return chirp
    }
  })

  const displayedTerm =
  filteredTerms.map((chirp) => {
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
      </main>

    </div>
  )
}

export default Explore;
