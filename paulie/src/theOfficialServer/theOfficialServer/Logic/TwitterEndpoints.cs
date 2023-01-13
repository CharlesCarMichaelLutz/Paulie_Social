using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace theOfficialServer
{
    public class TwitterEndpoints
    {
        public static async Task<string> searchTweets(string authorizeToken)
        {
            //string twitterObject = string.Empty;

            using (var twitterClient = new HttpClient())
            {
                string authorization = authorizeToken;

                twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=music");
                twitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = new HttpResponseMessage();
                response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("success");

                }
                else
                {
                    Console.WriteLine("fail");
                }
                return json;
            }

        }
    }
}
