namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public interface ITweetRepository
    {
        //Twitter Service Method Signatures
        Task<IEnumerable<TweetModel>> GetTweetsByContent(string username);

        //Mock Service Method Signatures

        //IEnumerable<TweetModel> GetAllTweets();

        //IEnumerable<TweetModel> GetTweetsByContent(string searchTerm);

        //IEnumerable<TweetModel> GetTweetsByUsername(string username);

        //TweetModel GetRandomTweet(int id);
    }
}
