using PaulieSocialWebApi.Models.TweetModel;

namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public interface ITweetService
    {
        //Twitter Service Method Signatures
        Task<IEnumerable<TweetModel>> GetTweetsByContent(string searchTerm);
        Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username);
    }
}
