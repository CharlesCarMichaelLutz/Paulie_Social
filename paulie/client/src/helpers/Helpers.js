export const findMediaForTweet = (tweet, mediaArray) => {
  if (!tweet.attachments || !tweet.attachments.media_keys) {
    return null;
  }
  const dataMediaKey = tweet.attachments.media_keys[0];
  return mediaArray.find((media) => media.media_key === dataMediaKey);
};

export const matchUserWithTweet = (tweets, users) => {
  const matchedData = [];

  tweets.forEach((tweet) => {
    const authorId = tweet.author_id;
    const matchingUser = users.find((user) => user.id === authorId);

    if (matchingUser) {
      matchedData.push({ tweet, user: matchingUser });
    }
  });
  return matchedData;
};
