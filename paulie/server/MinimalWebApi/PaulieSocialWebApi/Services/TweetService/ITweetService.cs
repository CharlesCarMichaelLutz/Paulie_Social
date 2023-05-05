using PaulieSocialWebApi.Models.TweetModel;

namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public interface ITweetService
    {
        Task<IEnumerable<TweetModel>> GetTweetsByContent(string searchTerm);
        Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username);
        Task<TweetModel> GetRandomVipTweet(string id);
    }
}
