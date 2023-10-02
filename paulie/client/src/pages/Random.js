import React, { useState, useEffect } from "react";
import VIPCard from "../components/VIPCard";
import PopupModal from "../components/PopupModal";
import axios from "axios";
import VipCardData from "../static/userCard.json";
import TweetCard from "../components/TweetCard";

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
    const vip = process.env.REACT_APP_WEBAPI_URL + `/api/randomVip/${id}`;

    try {
      const response = await axios.get(vip);
      setRandomTweet(response.data);
      console.log("Random Tweet:", response.data);
    } catch (error) {
      console.log(error);
    } finally {
      setRandomTweet([]);
      setUserId(null);
    }
  };

  function handleClickVIPCard(id) {
    setUserId(id);
  }

  const cards = VipCardData.map((vipIndex) => {
    return (
      <VIPCard
        key={vipIndex.userId}
        user={vipIndex}
        eventHandler={() => handleClickVIPCard(vipIndex.userId)}
      />
    );
  });

  return (
    <>
      <header className="random--header">
        <h3>Get Random Chirps from your favorite users below</h3>
      </header>

      <div className="user--card">{cards}</div>

      <PopupModal open={isOpen} onClose={() => setIsOpen(false)}>
        {randomTweet && <TweetCard {...randomTweet} />}
      </PopupModal>
    </>
  );
};

export default Random;
