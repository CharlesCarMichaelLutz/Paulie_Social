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

        public TwitterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Tweets>> SearchTweets(string searchTerm)
        {
            List<Tweets> tweetsList = new List<Tweets>();

            //set the endpoint to search for tweets by content
            var endpoint = $"tweets/search/recent?query={searchTerm}";
            //var paramters = $"users/by?usernames={searchTerm}";

            //Make a GET req to the Twitter API
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

            //HttpResponseMessage response = await _httpClient.GetAsync(json).ConfigureAwait(false);

            // Read the response content as a JSON string
            string json = await response.Content.ReadAsStringAsync();

            //Deserialize JSON into a list of Tweet objects
            tweetsList = JsonConvert.DeserializeObject<List<Tweets>>(json);

            return tweetsList;
        }
        public async Task<List<Tweets>> SearchUsers(string searchTerm)
        {
            List<Tweets> tweetsList = new List<Tweets>();

            //set the endpoint to search for tweets by content
            //var parameters = $"users/by?usernames={searchTerm}";
            var endpoint = $"users/by/username/{searchTerm}/tweets";

            //Make a GET req to the Twitter API
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);

            // Read the response content as a JSON string
            //string json = await _httpClient.GetStringAsync(parameters);
            string json = await response.Content.ReadAsStringAsync();


            //Deserialize here
            tweetsList = JsonConvert.DeserializeObject<List<Tweets>>(json);

            return tweetsList;
        }

        //public async Task<IEnumerable<Tweets>> GetVipTweet([FromRoute]string searchTerm)
        //{
        //    List<Tweets> cList = new List<Tweets>();
        //    var parameters = $"users/by?usernames={searchTerm}";
        //    string json = await _httpClient.GetStringAsync(parameters);

        //    //Deserialize here
        //    return cList;
        //}

        public async Task<List<Tweets>> GetVipTweet(string searchTerm)
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

