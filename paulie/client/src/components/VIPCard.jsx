import React from "react";

const VIPCard = ({ user, eventHandler }) => {
  let { username, userhandle, userImage } = user;

  return (
    <>
      <div class="card text-white bg-success mb-3">
        <div class="card-body" style={{ width: "325px" }}>
          <img
            class="card-img-top"
            align="center"
            src={userImage}
            width={275}
            height={275}
            alt="vipImage"
          />
          <h3 class="card-title">{username}</h3>
          <h4 class="card-title">@{userhandle}</h4>
          <button onClick={eventHandler}>Get Tweet</button>
        </div>
      </div>
    </>
  );
};

export default VIPCard;
