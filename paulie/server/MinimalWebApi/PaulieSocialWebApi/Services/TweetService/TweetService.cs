using Newtonsoft.Json;
using PaulieSocialWebApi.Models.TweetModel;
using PaulieSocialWebApi.Models.UserIdModel;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
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

            var extensionApi = $"tweets/search/recent?query={searchTerm}";

            //var parameters = $"max_results=25&expansions=author_id&media.fields=&user.fields=description&tweet.fields=public_metrics&?query={username}";

            //var extensionApi = $"tweets/search/recent{parameters}";

            HttpResponseMessage response = await _httpClient.GetAsync(extensionApi).ConfigureAwait(false);

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
            var trimUsername = username.Replace(" ","");

            var usernameIdEndpoint = $"users/by/username/{trimUsername}";

            List<TweetModel> populatedList = new List<TweetModel>();

            HttpResponseMessage userIdRequest = await _httpClient.GetAsync(usernameIdEndpoint).ConfigureAwait(false);

            var idJson = await userIdRequest.Content.ReadAsStringAsync();

            var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);

            var usernameListEndpoint = $"users/{user.data.id}/tweets";

            HttpResponseMessage userListRequest = await _httpClient.GetAsync(usernameListEndpoint).ConfigureAwait(false);

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
