import React, { useState } from "react";
import axios from "axios";
import TweetCard from "../components/TweetCard";

const Explore = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [radioButtonValue, setRadioButtonValue] = useState("username");

  const onInputChange = (e) => {
    setSearchTerm(e.target.value);
  };

  const onRadioButtonChange = (e) => {
    setRadioButtonValue(e.target.value);
    setTweets([]);
  };

  const getTweets = async (e) => {
    e.preventDefault();

    if (searchTerm) {
      const apiEndpoint =
        radioButtonValue === "username"
          ? process.env.REACT_APP_WEBAPI_URL + `/api/explore/${searchTerm}`
          : process.env.REACT_APP_WEBAPI_URL +
            `/api/explore/content/${searchTerm}`;

      try {
        const response = await axios.get(apiEndpoint);
        setTweets(response.data);
        console.log("search query: ", response.data);
      } catch (error) {
        console.log(error);
        setTweets([]);
      } finally {
        setSearchTerm("");
      }
    }
  };

  const findMediaForTweet = (tweet, mediaArray) => {
    if (!tweet.attachments || !tweet.attachments.media_keys) {
      return null;
    }
    const dataMediaKey = tweet.attachments.media_keys[0];

    return mediaArray.find((media) => media.media_key === dataMediaKey);
  };

  // const userWithMultipleTweets = (tweet, usersArray) => {
  //   if(tweet.author_id.count() === 1) {
  //     return tweet.author_id
  //   }
  //   const dataAuthorId = tweet.author_id
  //   return usersArray.find((author) => author.id === dataAuthorId)
  // }

  const renderTweets =
    tweets.length === 0 ? (
      <p>No Tweets found</p>
    ) : (
      tweets.map((tweetObject, tweetIndex) =>
        tweetObject.data.map((tweet, dataIndex) => {
          // const mediaData =
          //   tweetObject.includes &&
          //   tweetObject.includes.media &&
          //   tweetObject.includes.media[index]

          const mediaData = findMediaForTweet(
            tweet,
            tweetObject.includes.media
          );

          const userData =
            radioButtonValue === "username"
              ? tweetObject.includes.users[0]
              : tweetObject.includes.users.id[dataIndex];

          return (
            <div className="col-md-6 mb-4">
              <TweetCard
                key={dataIndex}
                tweetList={tweet}
                mediaData={mediaData}
                users={userData}
              />
            </div>
          );
        })
      )
    );

  return (
    <>
      <div className="container">
        <header className="explore--header">
          <h2>Explore Chirps from Paulie Social</h2>
        </header>

        <form onSubmit={getTweets}>
          <section className="group--radio">
            <label className="btn btn-outline-success">Username</label>

            <input
              type="radio"
              className="btn-check"
              value="username"
              id="btn-1"
              checked={radioButtonValue === "username"}
              onChange={onRadioButtonChange}
            />

            <label className="btn btn-outline-success">Content</label>

            <input
              type="radio"
              className="btn-check"
              value="content"
              id="btn-2"
              checked={radioButtonValue === "content"}
              onChange={onRadioButtonChange}
            />
          </section>

          <input
            placeholder="explore...."
            type="text"
            className="search--bar"
            value={searchTerm}
            onChange={onInputChange}
          />

          <button type="submit" className="submit--button">
            Get Tweets
          </button>
        </form>

        <div className="list--tweets">
          <ul>{renderTweets}</ul>
        </div>
      </div>
    </>
  );
};

export default Explore;
