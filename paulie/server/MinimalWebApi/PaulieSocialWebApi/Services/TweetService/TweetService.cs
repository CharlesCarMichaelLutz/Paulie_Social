using Newtonsoft.Json;
using PaulieSocialWebApi.Models.TweetModel;
using PaulieSocialWebApi.Models.UserIdModel;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PaulieSocialWebApi.Repositories.TweetRepository
{
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

            var parameters = $"{endpoint}&tweet.fields=author_id,public_metrics&media.fields=public_metrics&expansions=attachments.media_keys&max_results=25";

            HttpResponseMessage response = await _httpClient.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                var model = JsonConvert.DeserializeObject<TweetModel>(jsonString);

                if (model != null)
                {
                    tweets.Add(model);
                }
            }
            return tweets;
        }

        public async Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username)
        {
            //add using to http calls & error handling for bad requests

            List<TweetModel> populatedList = new List<TweetModel>();

            var trimUsername = username.Replace(" ","");

            var endpointUserId = $"users/by/username/{trimUsername}";

            HttpResponseMessage userIdRequest = await _httpClient.GetAsync(endpointUserId).ConfigureAwait(false);

                var idJson = await userIdRequest.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);
            
                var endpointListTweets = $"users/{user.data.id}/tweets";

                var parameters = $"{endpointListTweets}?tweet.fields=author_id,public_metrics&media.fields=public_metrics&expansions=attachments.media_keys&max_results=25";
            
            HttpResponseMessage userListRequest = await _httpClient.GetAsync(parameters).ConfigureAwait(false);

            if (userListRequest.IsSuccessStatusCode)
            {
                string listJson = await userListRequest.Content.ReadAsStringAsync();

                Console.WriteLine(listJson);

                var tweetList = JsonConvert.DeserializeObject<TweetModel>(listJson);

                if (tweetList != null)
                {
                    populatedList.Add(tweetList);
                }
            }
            else
            {
                Console.WriteLine("could not retrieve list of user tweets");
            }
            return populatedList;
        }
    }
}
