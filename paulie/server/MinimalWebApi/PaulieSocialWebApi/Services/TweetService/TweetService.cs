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
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            return tweets;
        }
        public async Task<IEnumerable<TweetModel>> GetTweetsByUsername(string username)
        {
            List<TweetModel> populatedList = new List<TweetModel>();

            var trimUsername = username.Replace(" ","");

            var endpointUserId = $"users/by/username/{trimUsername}";

            HttpResponseMessage userIdRequest = await _httpClient.GetAsync(endpointUserId).ConfigureAwait(false);

                var idJson = await userIdRequest.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<UserIdModel>(idJson);
            
                var endpointListTweets = $"users/{user.data.id}/tweets";

                var parameters = $"{endpointListTweets}?tweet.fields=author_id,public_metrics&media.fields=public_metrics&expansions=attachments.media_keys&max_results=25";
            
            HttpResponseMessage response = await _httpClient.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                string listJson = await response.Content.ReadAsStringAsync();

                Console.WriteLine(listJson);

                var tweetList = JsonConvert.DeserializeObject<TweetModel>(listJson);

                if (tweetList != null)
                {
                    populatedList.Add(tweetList);
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            return populatedList;
        }
       
        public async Task<TweetModel> GetRandomVipTweet(string id)
        {
            //string id gets passed in from frontend as argument

            //string User Id array will be the same in the frontend
            //so it will map correctly with User Id list below

            TweetModel populatedTweet = new TweetModel();

            List<string> VipUsersId = new List<string>()
            {
                "850333483339730945",
                "4398626122",
                "1512200244",
                "302666251",
                "953748782394499072"
            };

            var random = new Random();

            //that gets mapped to VipUsersId

            /// If Id get passed in as an int
            /// do the following:
            /// 
            ///  var convertIndex = Convert.ToString(id);
            ///  int index = VipUsersId.IndexOf(convertIndex);
            ///  

            int index = VipUsersId.IndexOf(id);

            if (index >= 0)
            {
                //User Id gets selected
                string vipUserId = VipUsersId[index];

                //API call for list of Tweets
                var endpointListTweets = $"users/{vipUserId}/tweets?max_results=30&exclude=retweets,replies";

                HttpResponseMessage response = await _httpClient.GetAsync(endpointListTweets).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    //randomize and select a tweet
                    //var getIndexOfRandomTweet = random.Next(0, jsonString.Length);

                    //var randomTweet = jsonString.data[getIndexOfRandomTweet];

                    //Console.WriteLine(getIndexOfRandomTweet);

                    populatedTweet = JsonConvert.DeserializeObject<TweetModel>(jsonString);

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            return populatedTweet;
        }
    }
}
