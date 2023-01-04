using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace myServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string bear = "AAAAAAAAAAAAAAAAAAAAAOt%2FkwEAAAAAI%2B5mBcPilusrbdYW2mG4mjo6hao%3DfvnnDXKiBGfJEdGEC5iF8pHyeB8TnqkqT6TRbQLscifnvSprl3";
            //string oAuth = GetAuthorizeToken().Result;
            //Console.WriteLine(oAuth);

            string getTweets = searchTweets(bear).Result;
            Console.WriteLine(getTweets);

            string getUsers = searchUsers(bear).Result;
            Console.WriteLine(getUsers);
        }

            //public static async Task<string> GetAuthorizeToken()
            //{
            //    string responseObject = string.Empty;

            //    using (var baseClient = new HttpClient())
            //    {
            //        baseClient.BaseAddress = new Uri("http://localhost:5102");
            //        baseClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //        HttpResponseMessage response = new HttpResponseMessage();
            //        List<KeyValuePair<string, string>> allInputs = new List<KeyValuePair<string, string>>();
            //        allInputs.Add(new KeyValuePair<string, string>("PazcZEjVNGgmklIupB7Qezz9i", "Q87xhbbnjiVtVfrvdFPdgWD1me9L5g2WXqOhpGeJfupWmFiplz"));

            //        HttpContent requestParams = new FormUrlEncodedContent(allInputs);
            //        response = await baseClient.PostAsync("Token", requestParams).ConfigureAwait(false);
            //        //responseObject = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //        //string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            Console.WriteLine("success");
            //            Console.WriteLine(response);
            //        }
            //        else
            //        {
            //            Console.WriteLine("fail");
            //        }
            //        return responseObject;
            //    }
            //}

            public static async Task<string> searchTweets(string authorizeToken)
            {
                //string twitterObject = string.Empty;

                using (var twitterClient = new HttpClient())
                {
                    string authorization = authorizeToken;

                    twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                    var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=cannabisstocks");
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
            public static async Task<string> searchUsers(string authorizeToken)
            {
                using (var twitterClient = new HttpClient())
                {
                    string authorization = authorizeToken;

                    twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                    var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=roseparade");
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
