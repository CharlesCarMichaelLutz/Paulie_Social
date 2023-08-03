using Newtonsoft.Json;
using PaulieSocialWebApi.Models.TweetModel;
using PaulieSocialWebApi.Models.UserIdModel;
using System;
using System.Collections.Immutable;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PaulieSocialWebApi.Repositories.TweetRepository
{
    public class TweetService : ITweetService
    {
        private readonly HttpClient _httpClient;
        //private readonly FieldsAndExpansions _fieldsAndExpansions;
        public TweetService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_fieldsAndExpansions = fieldsAndExpansions;
        }
        public async Task<IEnumerable<TweetModel>> GetTweetsByContent(string searchTerm)
        {
            List<TweetModel> tweets = new List<TweetModel>();

            var endpoint = $"tweets/search/recent?query={searchTerm}";
            //var parameters = $"{endpoint}&{_extras}";
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

            var trimUsername = username.Replace(" ","");
            var endpointUserId = $"users/by/username/{trimUsername}";

            HttpResponseMessage userIdRequest = await _httpClient.GetAsync(endpointUserId).ConfigureAwait(false);

            //implement error handling for username input that can't be found 

            var idJson = await userIdRequest.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);
            var endpointListTweets = $"users/{user.data.username}/tweets";
            //var parameters = $"{endpointListTweets}?{_fieldAndExpansions}";

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
            //var endpointListTweets = $"users/{vipUserId}/tweets?{_fieldsAndExpansions}";
            var endpointListTweets = $"users/{vipUserId}/tweets?tweet.fields=author_id,public_metrics&media.fields=url,git variants,public_metrics,media_key,type&expansions=attachments.media_keys,author_id&max_results=15&exclude=retweets,replies&user.fields=profile_image_url";

            HttpResponseMessage response = await _httpClient.GetAsync(endpointListTweets).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(response.ReasonPhrase);
            }

            string jsonString = await response.Content.ReadAsStringAsync();
            var tweetResponse = JsonConvert.DeserializeObject<TweetModel>(jsonString);

            int getIndexOfRandomTweet = random.Next(0, tweetResponse.Data.Length);
            TweetData selectedTweetData = tweetResponse.Data[getIndexOfRandomTweet];
            TweetModel selectedTweet = new TweetModel { Data = new[] {selectedTweetData} };
                   
            return selectedTweet;
        }
    }
}
