import React from "react";
import ReactDom from "react-dom";

const PopupModal = ({ open, randomTweet, onClose }) => {
  if (!open) return null;

  return ReactDom.createPortal(
    <>
      <div className="popup--box">
        <div className="box">
          <span className="close--icon" onClick={onClose}>
            X
          </span>

          {randomTweet}
        </div>
      </div>
    </>,
    document.getElementById("portal")
  );
};

export default PopupModal;
