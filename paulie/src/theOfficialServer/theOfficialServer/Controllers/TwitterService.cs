using theOfficialServer.Models;
using theOfficialServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.HttpLogging;
using theOfficialServer.Authentication;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace theOfficialServer
{
    public class TwitterService : ITwitterService
    {
        // pass in the api keys here

        private readonly HttpClient _httpClient;

        public TwitterService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Tweets>> SearchTweets([FromRoute] string searchTerm)
        {
            List<Tweets> aList = new List<Tweets>();
            var paramaters = $"users/by?usernames={searchTerm}";
            string json = await _httpClient.GetStringAsync(paramaters);
            HttpResponseMessage response = await _httpClient.GetAsync(json).ConfigureAwait(false);

            //Deserialize here
            return aList;
        }
        public async Task<List<Tweets>> SearchUsers([FromRoute] string searchTerm)
        {
            List<Tweets> bList = new List<Tweets>();
            var parameters = $"users/by?usernames={searchTerm}";
            string json = await _httpClient.GetStringAsync(parameters);

            //Deserialize here
            return bList;
        }

        //public async Task<IEnumerable<Tweets>> GetVipTweet([FromRoute]string searchTerm)
        //{
        //    List<Tweets> cList = new List<Tweets>();
        //    var parameters = $"users/by?usernames={searchTerm}";
        //    string json = await _httpClient.GetStringAsync(parameters);

        //    //Deserialize here
        //    return cList;
        //}

        public async Task<List<Tweets>> GetVipTweet([FromRoute] string searchTerm)
        {
            List<Tweets> cList = new List<Tweets>();

            var parameters = $"users/by?usernames={searchTerm}";
            HttpResponseMessage response = await _httpClient.GetAsync(parameters);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var tweetList = JsonConvert.DeserializeObject<Tweets>(jsonString);
            }
            else
            {
                return cList.ToList();

            }
            return cList;
        }
    }  
}

