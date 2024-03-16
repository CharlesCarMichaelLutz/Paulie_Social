using Newtonsoft.Json;
using PaulieSocialWebApi.Models;
using System.Net.Http;

namespace PaulieSocialWebApi.Services
{
    public interface IRandomTweetService
    {
        Task<TweetModel> GetRandomVipTweet(string id);
    }

    public class RandomTweetService : IRandomTweetService
    {
        private readonly HttpClient _httpClient;
        public RandomTweetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TweetModel> GetRandomVipTweet(string id)
        {
            List<string> VipUsersId = new List<string>()
            {
                "850333483339730945",
                "4398626122",
                "1512200244",
                "302666251",
                "953748782394499072"
            };

            var random = new Random();

            int index = VipUsersId.IndexOf(id);

            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            string vipUserId = VipUsersId[index];
            var endpointListTweets = $"users/{vipUserId}/tweets?tweet.fields=attachments,author_id,public_metrics,source&media.fields=url,variants,media_key,type&expansions=attachments.media_keys,author_id&user.fields=profile_image_url&max_results=15&exclude=retweets,replies";

            HttpResponseMessage response = await _httpClient.GetAsync(endpointListTweets).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string jsonString = await response.Content.ReadAsStringAsync();
            var tweetResponse = JsonConvert.DeserializeObject<TweetModel>(jsonString);

            int getIndexOfRandomTweet = random.Next(0, tweetResponse.Data.Length);

            TweetData selectedTweetData = tweetResponse.Data[getIndexOfRandomTweet];

            Includes select = tweetResponse.Includes;


            TweetModel selectedTweet = new TweetModel
            {
                Data = new[] { selectedTweetData },
                Includes = select
            };

            return selectedTweet;
        }
    }
}
