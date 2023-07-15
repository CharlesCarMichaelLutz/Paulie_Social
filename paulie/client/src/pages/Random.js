// import React, { useState } from 'react';
// import VIPCard from '../components/VIPCard';
// //import ChirpCard from '../components/ChirpCard';
// import TweetCard from '../components/TweetCard';
// import Popup from '../components/usePopup';
// import { endpoints } from '../Endpoints';
// import axios from 'axios';


// const Random = ({userCards}) => {

//    const [randomTweet, setRandomTweet] = useState([])
//   // const [VIPUser, getVIPUser] = useState([])

//   axios
//     .get(endpoints.BASE_URI+`randomVip`)
//     .then((res) => {
//       setRandomTweet(res.data)
//       console.log('VIP search query: ', res.data)
//     })
//     .catch((error) => {
//       console.log(error)
//     })

//   const [isOpen, setIsOpen] = useState(false);

//   const togglePopup = () => {
//     setIsOpen(!isOpen)
//   }

//   const cards = userCards.map(user => {
//     return(
//       <VIPCard key={user.id} user={user} />
//     )
//   })

//   const content = chirps.map(user => {
//     const random = Math.floor(Math.random() * chirps.length)
//     const item = chirps[random]
//     console.log("Item:", item)
//     return(
//       <TweetCard key={item.username} user={user} />
//     )
//   })

//   return (
//     <div>
//       <header className='random--header'>
//         <h3>Get Random Chirps from your favorite users below</h3>  
//       </header>

//       <div class="container" className='user--card' onClick={togglePopup} >
//         {cards}
//       </div>
 
//       {isOpen && <Popup       
//         content={content}
//         handleClose={togglePopup}
//       />}
//     </div>
//   )

// }

// export default Random;
