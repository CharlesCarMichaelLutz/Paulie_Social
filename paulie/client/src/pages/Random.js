import React, { useState, useEffect } from "react";
import axios from "axios";
import Errors from "../components/Errors";
import VipCardData from "../static/userCard.json";
import VIPCard from "../components/VIPCard";
import { Helmet } from "react-helmet-async";
import PopupModal from "../components/PopupModal";

const Random = () => {
  const [randomTweet, setRandomTweet] = useState([]);
  const [userId, setUserId] = useState(null);
  const [isOpen, setIsOpen] = useState(false);
  const [error, setError] = useState(null);

  useEffect(() => {
    if (userId) {
      getRandomTweet(userId);
    }
  }, [userId]);

  const getRandomTweet = async (id) => {
    //const vip = endpoints.BASE_URI + `randomVip/${id}`
    const vip = `/api/randomVip/${id}`;

    try {
      const response = await axios.get(vip);
      if (response.length === 0) {
        setError(`could not retrieve the data, try again`);
      }
      setRandomTweet(response.data);
      setIsOpen(true);
      console.log("Random Tweet:", response.data);
    } catch (error) {
      setError(error.message);
      console.log(error);
    } finally {
      setUserId(null);
    }
  };

  function handleClick(id) {
    setUserId(id);
  }

  // const cards = VipCardData.map((vipIndex) => {
  //   return (
  //     <VIPCard
  //       key={vipIndex.userId}
  //       user={vipIndex}
  //       eventHandler={() => handleClick(vipIndex.userId)}
  //     />
  //   );
  // });

  const cards = error ? (
    <Errors message={error} />
  ) : (
    VipCardData.map((vipIndex) => {
      return (
        <VIPCard
          key={vipIndex.userId}
          user={vipIndex}
          eventHandler={() => handleClick(vipIndex.userId)}
        />
      );
    })
  );

  return (
    <>
      <Helmet>
        <title>Paulie Social - VIP</title>
      </Helmet>
      <header className="random--header">
        <h1>Get random tweet from favorites below</h1>
      </header>

      <div className="user--card">{cards}</div>

      <PopupModal
        open={isOpen}
        onClose={() => setIsOpen(false)}
        vipTweetData={randomTweet}
      />
    </>
  );
};

export default Random;
