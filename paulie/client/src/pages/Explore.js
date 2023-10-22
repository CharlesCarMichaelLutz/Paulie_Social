import React, { useState, useEffect } from "react";
import axios from "axios";
import TweetCard from "../components/TweetCard";

const Explore = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [radioButtonValue, setRadioButtonValue] = useState("username");

  useEffect(
    (tweets) => {
      if (tweets) {
        setTweets(tweets);
      }
    },
    [tweets]
  );

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
          ? `/api/explore/${searchTerm}`
          : `/api/explore/content/${searchTerm}`;

      try {
        const response = await axios.get(apiEndpoint);
        setTweets(response.data);
        console.log("search query: ", response.data);
      } catch (error) {
        console.log(error);
        setTweets([]);
      } finally {
        setSearchTerm("");
        //setRadioButtonValue(null)
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
    tweets.length === 0
      ? ""
      : tweets.map((tweetObject) =>
          tweetObject.data.map((tweetData, dataIndex) => {
            const mediaData = findMediaForTweet(
              tweetData,
              tweetObject.includes.media
            );

            const userData =
              radioButtonValue === "username"
                ? tweetObject.includes.users[0]
                : tweetObject.includes.users[dataIndex];

            return (
              <div className="render--explore">
                <TweetCard
                  key={dataIndex}
                  tweetList={tweetData}
                  mediaData={mediaData}
                  users={userData}
                />
              </div>
            );
          })
        );

  return (
    <>
      <div className="container">
        <header className="explore--header">
          <h1>Explore Tweets with Paulie Social</h1>
        </header>

        <form onSubmit={getTweets}>
          <section className="group--radio">
            <div className="radio">
              <div className="btn-group btn-group-toggle" data-toggle="buttons">
                <label
                  className={`btn btn-primary ${
                    radioButtonValue === "username" ? "active" : ""
                  } green-button`}
                  htmlFor="button1"
                >
                  <input
                    type="radio"
                    value="username"
                    id="button1"
                    className="hidden-radio"
                    checked={radioButtonValue === "username"}
                    onChange={onRadioButtonChange}
                  />
                  Username
                </label>
                <label
                  className={`btn btn-primary ${
                    radioButtonValue === "content" ? "active" : ""
                  } green-button`}
                  htmlFor="button2"
                >
                  <input
                    type="radio"
                    value="content"
                    id="button2"
                    className="hidden-radio"
                    checked={radioButtonValue === "content"}
                    onChange={onRadioButtonChange}
                  />
                  Content
                </label>
              </div>
            </div>
          </section>

          <input
            placeholder="search...."
            type="text"
            className="search--bar"
            value={searchTerm}
            onChange={onInputChange}
          />
          <button type="submit" className="submit--button">
            Get Tweets
          </button>
        </form>

        <div className="list-container">
          <div className="row justify-content-center">
            <div className="col-md-6">
              <ul>{renderTweets}</ul>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export default Explore;
