import React from "react";

const VIPCard = ({ user, eventHandler }) => {
  let { userhandle, userImage } = user;
  return (
    <>
      <div className="container">
        <div className="vip--card">
          <img
            className="card-img-top"
            align="center"
            src={userImage}
            width={275}
            height={275}
            alt="vipImage"
          />
          <hr className="card-line" />
          <div className="card-body">
            {/*<h3 className="card-title">{username}</h3>*/}
            <h4 className="card-subtitle">@{userhandle}</h4>
            <button
              className="btn btn-primary"
              data-bs-toggle="modal"
              data-bs-target="#modal"
              onClick={eventHandler}
            >
              Get Tweet
            </button>
          </div>
        </div>
      </div>
    </>
  );
};

export default VIPCard;
