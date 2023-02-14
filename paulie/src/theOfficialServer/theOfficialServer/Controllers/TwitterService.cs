using theOfficialServer.Models;
using theOfficialServer.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace theOfficialServer
{
    public class TwitterService : ITwitterService
    {
        // pass in the api keys here

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        //var apiKey = _configuration.GetValue<string>()
        public TwitterService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<IEnumerable<Tweets>> SearchTweets([FromRoute]string searchTerm)
        {
            List<Tweets> aList = new List<Tweets>();
            var paramaters = $"users/by?usernames={searchTerm}";
            //var paramaters = $"users/by?usernames={searchTerm}&apiKey={}&";
            string json = await _httpClient.GetStringAsync(paramaters);
            //HttpResponseMessage response = await _httpClient.GetAsync(paramaters).ConfigureAwait(false);

            //Deserialize here
            return aList;
        }
        public async Task<IEnumerable<Tweets>> SearchUsers([FromRoute]string searchTerm)
        {
            List<Tweets> bList = new List<Tweets>();
            var parameters = $"users/by?usernames={searchTerm}";
            string json = await _httpClient.GetStringAsync(parameters);

            //Deserialize here
            return bList;
        }

        public async Task<IEnumerable<Tweets>> GetVipTweet([FromRoute]string searchTerm)
        {
            List<Tweets> cList = new List<Tweets>();
            var parameters = $"users/by?usernames={searchTerm}";
            string json = await _httpClient.GetStringAsync(parameters);

            //Deserialize here
            return cList;
        }
    }  
}

///
/// if (customer is null)
/// {
///     return NotFound();
/// }
/// logic here
/// return Ok(updatedCustomer);
