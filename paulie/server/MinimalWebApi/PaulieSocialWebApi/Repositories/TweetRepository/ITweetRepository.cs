namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public interface ITweetRepository
    {
        List<Twitter> GetAllTweets();

        List<Twitter> GetTweetsBySearchTerm(string searchTerm);

        List<Twitter> GetTweetsByUsername(string username);

        Twitter GetRandomTweet();
    }
}
