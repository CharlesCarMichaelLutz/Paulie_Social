using Microsoft.AspNetCore.Mvc;
using theOfficialServer.Models;

namespace theOfficialServer.Controllers
{
    public interface ITwitterService
    {
        //Task<IEnumerable<Tweets>> SearchUsers(string searchTerm);
        Task<List<Tweets>> SearchTweets([FromRoute] string searchTerm);

        Task<List<Tweets>> SearchUsers([FromRoute] string searchTerm);

        //Task<IEnumerable<Tweets>> SearchTweets(string searchTerm);
        //Task<IEnumerable<Tweets>> GetVipTweet(string searchTerm);
        Task<List<Tweets>> GetVipTweet([FromRoute] string searchTerm);

    }
}
