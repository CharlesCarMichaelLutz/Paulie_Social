using System.Net.Http.Headers;
using theOfficialServer.Models;

namespace theOfficialServer.Data_Source
{
    public static class TwitterApi
    {
        public static HttpClient TwitterClient { get; set; }

        public static void InitializeClient(string authorize)
        {
            
            using(TwitterClient = new HttpClient())
            {
                TwitterClient.DefaultRequestHeaders.Accept.Clear();
                TwitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorize);
                TwitterClient.BaseAddress = new Uri("https://api.twitter.com/2/");
                TwitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}
