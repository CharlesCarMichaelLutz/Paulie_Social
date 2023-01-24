using System;
using System.Net.Http;
using System.Net.Http.Headers;
using theOfficialServer.Data_Source;
using theOfficialServer.Models;

namespace theOfficialServer
{
    public class TwitterEndpoints
    {
        public static async Task<Tweets> SearchTweets()
        {
            //string url = "tweets/search/recent?query=boston";

            //string url = "tweets/search/{id:}";

            string url = "tweets/search/recent?query=boston";

            using (HttpResponseMessage response = await TwitterApi.TwitterClient.GetAsync(url))
            {
                // return await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success");
                    Tweets aTweet = await response.Content.ReadAsAsync<Tweets>();
                    return aTweet;
                }
                else
                {
                    //Console.WriteLine("it didn't happen this time best wishes");
                    throw new Exception(response.ReasonPhrase);
                }
            }
            //response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
            //string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);              
            //return json;
        }
    }
}
