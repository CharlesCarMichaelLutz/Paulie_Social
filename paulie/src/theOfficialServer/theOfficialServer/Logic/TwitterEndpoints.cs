using System;
using System.Net.Http;
using System.Net.Http.Headers;
using theOfficialServer.Data_Source;
using theOfficialServer.Models;

namespace theOfficialServer
{
    public class TwitterEndpoints
    {
        public async Task<string> searchTweets()
        {
            //string url = "tweets/search/recent?query=boston";

            string url = "tweets/search/recent?query=boston";

            using (HttpResponseMessage response = await TwitterApi.TwitterClient.GetAsync(url))
            {
                // return await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success");
                }
                else
                {
                    Console.WriteLine("it didn't happen this time best wishes");
                }
            }
                //response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
                //string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);              
                return json;
        }
    }
}
