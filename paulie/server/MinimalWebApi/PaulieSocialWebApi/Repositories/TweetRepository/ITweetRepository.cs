namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public interface ITweetRepository
    {
        IEnumerable<Twitter> GetAllTweets();

        IEnumerable<Twitter> GetTweetsByContent(string searchTerm);

        IEnumerable<Twitter> GetTweetsByUsername(string username);

        Twitter GetRandomTweet(int id);
    }
}
