import React from "react";

const Media = ({ mediaData }) => {
  const { type, url, variants } = mediaData;

  return (
    <>
      <div>
        {type === "photo" && url && url.length > 0 && (
          <img src={url} alt="tweet image" />
        )}

        {(type === "animated_gif" || type === "video") &&
          variants &&
          Object.keys(variants).length > 0 && (
            <div>
              {type === "animated_gif" ? (
                <video controls>
                  <source
                    src={variants[Object.keys(variants)[0]].url}
                    type="video/mp4"
                    alt="tweet gif"
                  />
                </video>
              ) : (
                <video controls>
                  <source
                    src={variants[Object.keys(variants)[0]].url}
                    type="video/mp4"
                    alt="tweet video"
                  />
                </video>
              )}
            </div>
          )}
      </div>
    </>
  );
};

export default Media;
