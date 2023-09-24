import React from "react";

const Media = ({ mediaData }) => {
  const { type, url, variants } = mediaData;

  return (
    <div>
      {type === "photo" && <img src={url} alt="image" />}

      {(type === "animated_gif" || type === "video") && (
        <div>
          {variants && typeof variants === "object" && (
            <>
              {Object.keys(variants).map((variantKey, varIndex) => {
                const variant = variants[variantKey];
                return (
                  <div key={varIndex}>
                    {console.log(
                      type === "animated_gif" ? "gifUrl:" : "videoUrl",
                      variant.url
                    )}
                    {type === "animated_gif" ? (
                      <img src={variant.url} alt="gif" />
                    ) : (
                      <video controls>
                        <source src={variant.url} type="video/mp4" />
                      </video>
                    )}
                  </div>
                );
              })}
            </>
          )}
        </div>
      )}
    </div>
  );
};

export default Media;
