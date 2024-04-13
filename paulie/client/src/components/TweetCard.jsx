import React from "react";
import Media from "./Media";
import "bootstrap-icons/font/bootstrap-icons.css";

const TweetCard = ({
  tweetList: { text, public_metrics },
  users: { profile_image_url, username },
  mediaData,
}) => {
  return (
    <>
      <div className="card card-custom">
        <div className="card-header">
          <img
            src={profile_image_url}
            className="avatar"
            alt="avatar for user"
          />
          <h4 className="card-title">{username}</h4>
        </div>
        <hr className="card-line" />
        <div className="card-body">
          <div className="card-text">{text}</div>
        </div>
        {mediaData && <Media mediaData={mediaData} />}
        <hr className="card-line" />
        <div className="card-footer">
          <span className="likes">
            <i className="bi bi-heart">
              {""} {public_metrics.like_count}
            </i>
          </span>
          <span className="spacer"></span>
          <span className="retweets">
            <i className="bi bi-repeat">
              {""} {public_metrics.retweet_count}
            </i>
          </span>
        </div>
      </div>
    </>
  );
};

export default TweetCard;
