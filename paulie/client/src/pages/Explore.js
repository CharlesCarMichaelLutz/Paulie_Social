import React, { useState, useEffect } from "react";
import axios from "axios";
import Errors from "../components/Errors";
import { findMediaForTweet, matchUserWithTweet } from "../helpers/Helpers";
import TweetCard from "../components/TweetCard";
import ExploreForm from "../components/ExploreForm";
import { Helmet } from "react-helmet-async";

const Explore = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [tweets, setTweets] = useState([]);
  const [radioButtonValue, setRadioButtonValue] = useState("username");
  const [error, setError] = useState(null);

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
    setError(null);
  };

  const getTweets = async (e) => {
    e.preventDefault();
    setTweets([]);
    setError(null);

    if (searchTerm) {
      const apiEndpoint =
        radioButtonValue === "username"
          ? `/api/explore/${searchTerm}`
          : `/api/explore/content/${searchTerm}`;

      try {
        const response = await axios.get(apiEndpoint);
        console.log("search query: ", response.data);
        if (response.data.length === 0) {
          setError(
            `${radioButtonValue} entered may be incorrect, please try again`
          );
        }
        setTweets(response.data);
        setError(null);
      } catch (error) {
        setError(error.message);
      } finally {
        setSearchTerm("");
      }
    }
  };

  const renderTweets = error ? (
    <Errors message={error} />
  ) : (
    tweets.map((tweetObject) => {
      const tweetData = tweetObject.data;
      const userData = tweetObject.includes.users;

      const matchedData = matchUserWithTweet(tweetData, userData);

      return matchedData.map(({ tweet, user }, dataIndex) => {
        const mediaData = findMediaForTweet(tweet, tweetObject.includes.media);

        return (
          <div className="render--explore" key={dataIndex}>
            <TweetCard
              key={dataIndex}
              tweetList={tweet}
              mediaData={mediaData}
              users={user}
            />
          </div>
        );
      });
    })
  );

  return (
    <>
      <div className="container">
        <Helmet>
          <title>Paulie Social - Explore</title>
        </Helmet>
        <header className="explore--header">
          <h1>Explore Tweets with Paulie Social</h1>
        </header>

        <ExploreForm
          getTweets={getTweets}
          radioButtonValue={radioButtonValue}
          onRadioButtonChange={onRadioButtonChange}
          searchTerm={searchTerm}
          onInputChange={onInputChange}
        />

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
