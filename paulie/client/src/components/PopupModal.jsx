import React from "react";
import ReactDom from "react-dom";
import TweetCard from "./TweetCard";

const PopupModal = ({ open, vipTweetData, onClose }) => {
  if (!open || !vipTweetData) {
    return null;
  }

  const findMediaForTweet = (tweet, mediaArray) => {
    if (!tweet.attachments || !tweet.attachments.media_keys) {
      return null;
    }
    const dataMediaKey = tweet.attachments.media_keys[0];
    return mediaArray.find((media) => media.media_key === dataMediaKey);
  };

  const randomTweet = vipTweetData.data.map((tweet, tweetIndex) => {
    const userData = vipTweetData.includes.users[0];
    const mediaData = findMediaForTweet(tweet, vipTweetData.includes.media);

    return (
      <>
        <TweetCard
          key={tweetIndex}
          tweetList={tweet}
          mediaData={mediaData}
          users={userData}
        />
      </>
    );
  });

  return ReactDom.createPortal(
    <>
      <div class="container" className="modal--overlay">
        <div class="modal fade" className="modal--center">
          <div class="modal-dialog">
            <div class="modal-content">
              <button class="btn btn-primary" onClick={onClose}>
                X
              </button>
              {randomTweet}
            </div>
          </div>
        </div>
      </div>
    </>,
    document.getElementById("portal")
  );
};

export default PopupModal;
