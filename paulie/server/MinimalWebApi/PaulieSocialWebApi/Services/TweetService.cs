using Newtonsoft.Json;
using PaulieSocialWebApi.Models;
using System.Net.Mail;
using System.Web;

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
            var builder = new UriBuilder($"{_httpClient.BaseAddress}tweets/search/recent");
            builder.Port = -1;
            var queryStrings = HttpUtility.ParseQueryString(builder.Query);
            queryStrings["query"] = searchTerm;
            queryStrings["tweet.fields"] = "attachments,author_id,public_metrics,source";
            queryStrings["expansions"] = "attachments.media_keys,author_id";
            queryStrings["media.fields"] = "url,variants,media_key,type";
            queryStrings["user.fields"] = "profile_image_url";
            queryStrings["max_results"] = "15";
            builder.Query = queryStrings.ToString();
            var url = builder.ToString();

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var json = await response.Content.ReadAsStringAsync();

            var model = JsonConvert.DeserializeObject<TweetModel>(json);

            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new List<TweetModel>
            {
                model
            };
        }
        public async Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username)
        {
            var userIdRequest = await _httpClient.GetAsync($"users/by/username/{username.Trim()}").ConfigureAwait(false);

            var idJson = await userIdRequest.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);

            //TODO - create query string for GetTweetsByUsername method request

            var builder = new UriBuilder($"{_httpClient.BaseAddress}users/{user.data.id}/tweets");
            builder.Port = -1;
            var queryStrings = HttpUtility.ParseQueryString(builder.Query);
            queryStrings["tweet.fields"] = "attachments,author_id,public_metrics,source";
            queryStrings["expansions"] = "attachments.media_keys,author_id";
            queryStrings["media.fields"] = "url,variants,media_key,type";
            queryStrings["user.fields"] = "profile_image_url";
            queryStrings["max_results"] = "15";
            builder.Query = queryStrings.ToString();
            var url = builder.ToString();

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            var json = await response.Content.ReadAsStringAsync();

            var tweetList = JsonConvert.DeserializeObject<TweetModel>(json);

            if (tweetList is null)
            {
                throw new NullReferenceException();
            }

            return new List<TweetModel>
            { 
                tweetList
            };
        }
    }
}
