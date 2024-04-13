import React from "react";

const Media = ({ mediaData }) => {
  const { type, url, variants } = mediaData;

  return (
    <>
      <div>
        {type === "photo" && url && url.length > 0 && (
          <img src={url} className="media-element" alt="media" />
        )}

        {(type === "animated_gif" || type === "video") &&
          variants &&
          Object.keys(variants).length > 0 && (
            <div>
              {type === "animated_gif" ? (
                <video controls className="media-element">
                  <source
                    src={variants[Object.keys(variants)[0]].url}
                    type="video/mp4"
                  />
                </video>
              ) : (
                <video controls className="media-element">
                  <source
                    src={variants[Object.keys(variants)[0]].url}
                    type="video/mp4"
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
