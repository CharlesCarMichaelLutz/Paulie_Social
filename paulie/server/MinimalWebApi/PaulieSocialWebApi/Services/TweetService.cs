using Newtonsoft.Json;
using PaulieSocialWebApi.Models;

namespace PaulieSocialWebApi.Services
{
    public interface ITweetService
    {
        Task<IEnumerable<TweetModel>> GetTweetsByContent(string searchTerm);
        Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username);
    }
    public class TweetService : ITweetService
    {
        private readonly HttpClient _httpClient;
        public TweetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<TweetModel>> GetTweetsByContent(string searchTerm)
        {
            List<TweetModel> tweets = new List<TweetModel>();

            var endpoint = $"tweets/search/recent?query={searchTerm}";
            var parameters = $"{endpoint}&tweet.fields=attachments,author_id,public_metrics,source&expansions=attachments.media_keys,author_id&media.fields=url,variants,media_key,type&user.fields=profile_image_url&max_results=15";

            HttpResponseMessage response = await _httpClient.GetAsync(parameters).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string jsonString = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<TweetModel>(jsonString);

            if (model is null)
            {
                throw new NullReferenceException();
            }

            tweets.Add(model);

            return tweets;
        }
        public async Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username)
        {
            List<TweetModel> populatedList = new List<TweetModel>();

            var trimUsername = username.Replace(" ", "");
            var endpointUserId = $"users/by/username/{trimUsername}";

            HttpResponseMessage userIdRequest = await _httpClient.GetAsync(endpointUserId).ConfigureAwait(false);

            //implement error handling for username input that can't be found 

            var idJson = await userIdRequest.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);
            var endpointListTweets = $"users/{user.data.id}/tweets";

            var parameters = $"{endpointListTweets}?tweet.fields=attachments,author_id,public_metrics,source&media.fields=url,variants,media_key,type&expansions=attachments.media_keys,author_id&user.fields=profile_image_url&max_results=15";

            HttpResponseMessage response = await _httpClient.GetAsync(parameters).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string listJson = await response.Content.ReadAsStringAsync();
            var tweetList = JsonConvert.DeserializeObject<TweetModel>(listJson);

            if (tweetList is null)
            {
                throw new NullReferenceException();
            }

            populatedList.Add(tweetList);

            return populatedList;
        }
    }
}
