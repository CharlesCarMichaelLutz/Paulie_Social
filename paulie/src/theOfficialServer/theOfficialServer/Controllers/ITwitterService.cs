using theOfficialServer.Models;

namespace theOfficialServer.Controllers
{
    public interface ITwitterService
    {
        Task<IEnumerable<Tweets>> SearchUsers(string searchTerm);
        Task<IEnumerable<Tweets>> SearchTweets(string searchTerm);
        Task<IEnumerable<Tweets>> GetVipTweet(string searchTerm);
    }
}
