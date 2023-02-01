using System;
using System.Net.Http;
using System.Net.Http.Headers;
using theOfficialServer.Data_Source;
using theOfficialServer.Models;

namespace theOfficialServer
{
    public class TwitterEndpoints : ITwitterEndpoints
    {
        // pass in the api keys here
        public string auth = "xcnjcbdskj";

        private readonly HttpClient _httpClient;

        //constructor
        public TwitterEndpoints(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //prototype

        //public static async Task<Tweets> SearchTweets()
        //{
              // query and paramaters
        //    //string query = "tweets/search/recent?query=boston";

        //    //string url = "tweets/search/{id:}";

        //    string url = "tweets/search/recent?query=boston";

        //    using (HttpResponseMessage response = await TwitterApi.TwitterClient.GetAsync(url))
        //    {
        //        // return await response.Content.ReadAsStringAsync();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("success");
        //            Tweets aTweet = await response.Content.ReadAsAsync<Tweets>();
        //            return aTweet;
        //        }
        //        else
        //        {
        //            //Console.WriteLine("it didn't happen this time best wishes");
        //            throw new Exception(response.ReasonPhrase);
        //        }
        //    }
        //    //response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
        //    //string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);              
        //    //return json;
        //}

        //next example

        //public async Task<Tweets?> SearchTweetsbyUser(string username)
        //{
        //    return
        //        await _httpClient.GetFromJsonAsync<Tweets>(
        //            //modified url path goes here
        //            //query sring with fields and expansions
        //            )
        //        //endpoint "users/by?usernames={user}"
        //}

        //current

        public async Task<IEnumerable<Tweets>> Search(string query)
        {
            List<Tweets> list = new List<Tweets>();

            var urlPath = $"users/by?usernames={query}";
        }




        public async Task<IActionResult> GetBirds(string query)
        {
            var tweets = await _httpClient.GetCurrentWeatherForCity();
            return tweets is not null ? Ok(tweets) : NotFound();
        }
        public interface ITwitterEndpoints
        {
           Task<Tweets> SearchTweetsAsync();
        }
    }
}
