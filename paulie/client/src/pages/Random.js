import React, { useState, useEffect } from "react";
import VIPCard from "../components/VIPCard";
import PopupModal from "../components/PopupModal";
import axios from "axios";
import VipCardData from "../static/userCard.json";

const Random = () => {
  const [randomTweet, setRandomTweet] = useState([]);
  const [userId, setUserId] = useState(null);
  const [isOpen, setIsOpen] = useState(false);

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
      setRandomTweet(response.data);
      setIsOpen(true);
      console.log("Random Tweet:", response.data);
    } catch (error) {
      console.log(error);
    } finally {
      //setRandomTweet([])
      setUserId(null);
    }
  };

  function handleClick(id) {
    setUserId(id);
  }

  const cards = VipCardData.map((vipIndex) => {
    return (
      <VIPCard
        key={vipIndex.userId}
        user={vipIndex}
        eventHandler={() => handleClick(vipIndex.userId)}
      />
    );
  });

  return (
    <>
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
