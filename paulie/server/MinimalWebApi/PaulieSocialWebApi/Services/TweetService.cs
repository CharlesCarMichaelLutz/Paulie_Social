using Newtonsoft.Json;
using PaulieSocialWebApi.Extensions;
using PaulieSocialWebApi.Models;
using System.Web;

namespace PaulieSocialWebApi.Services
{
    public interface ITweetService
    {
        Task<TweetModel> GetTweetsByContent(string searchTerm);
        Task<TweetModel> GetTweetsByUsername(string username);
    }

    public class TweetService : ITweetService
    {
        private readonly HttpClient _httpClient;
        public TweetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<TweetModel> GetTweetsByContent(string searchTerm)
        {
            var builder = new UriBuilder($"{_httpClient.BaseAddress}tweets/search/recent");
            builder.Port = -1;
            var queryStrings = HttpUtility.ParseQueryString(builder.Query);
            queryStrings["query"] = searchTerm;
            queryStrings.AddStandardTwitterQueryStrings();
            builder.Query = queryStrings.ToString();
            var url = builder.ToString();

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            return await response.DeserializeOrThrow();
        }
        public async Task<TweetModel> GetTweetsByUsername(string username)
        {
            var userIdRequest = await _httpClient.GetAsync($"users/by/username/{username.Trim()}").ConfigureAwait(false);

            var idJson = await userIdRequest.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);

            var builder = new UriBuilder($"{_httpClient.BaseAddress}users/{user.data.id}/tweets");
            builder.Port = -1;
            var queryStrings = HttpUtility.ParseQueryString(builder.Query);
            queryStrings.AddStandardTwitterQueryStrings();
            queryStrings["exclude"] = "retweets,replies";
            builder.Query = queryStrings.ToString();
            var url = builder.ToString();

            var response = await _httpClient.GetAsync(url).ConfigureAwait(false);

            return await response.DeserializeOrThrow();
        }
    }
}
