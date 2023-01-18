//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;

//namespace myServer
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            string bear = "AAAAAAAAAAAAAAAAAAAAAOt%2FkwEAAAAAI%2B5mBcPilusrbdYW2mG4mjo6hao%3DfvnnDXKiBGfJEdGEC5iF8pHyeB8TnqkqT6TRbQLscifnvSprl3";
//            string oAuth = GetAuthorizeToken().Result;
//            Console.WriteLine(oAuth);

//            string getTweets = searchTweets(bear).Result;
//            Console.WriteLine(getTweets);

//            string getUsers = searchUsers(bear).Result;
//            Console.WriteLine(getUsers);
//        }

//        public static async Task<string> GetAuthorizeToken()
//        {
//            string responseObject = string.Empty;

//            using (var baseClient = new HttpClient())
//            {
//                baseClient.BaseAddress = new Uri("http://localhost:5102");
//                baseClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                HttpResponseMessage response = new HttpResponseMessage();
//                List<KeyValuePair<string, string>> allInputs = new List<KeyValuePair<string, string>>();
//                allInputs.Add(new KeyValuePair<string, string>("PazcZEjVNGgmklIupB7Qezz9i", "Q87xhbbnjiVtVfrvdFPdgWD1me9L5g2WXqOhpGeJfupWmFiplz"));

//                HttpContent requestParams = new FormUrlEncodedContent(allInputs);
//                response = await baseClient.PostAsync("Token", requestParams).ConfigureAwait(false);
//                //responseObject = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                //string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
//                if (response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("success");
//                    Console.WriteLine(response);
//                }
//                else
//                {
//                    Console.WriteLine("fail");
//                }
//                return responseObject;
//            }
//        }

//        public static async Task<string> searchTweets(string authorizeToken)
//        {
//            //string twitterObject = string.Empty;

//            using (var twitterClient = new HttpClient())
//            {
//                string authorization = authorizeToken;

//                twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
//                var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=music");
//                twitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                HttpResponseMessage response = new HttpResponseMessage();
//                response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
//                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

//                if (response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("success");

//                }
//                else
//                {
//                    Console.WriteLine("fail");
//                }
//                return json;
//            }

//        }
//        public static async Task<string> searchUsers(string authorizeToken)
//        {
//            using (var twitterClient = new HttpClient())
//            {
//                string authorization = authorizeToken;

//                twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
//                var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=nationalparks");
//                twitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                HttpResponseMessage response = new HttpResponseMessage();
//                response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
//                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

//                if (response.IsSuccessStatusCode)
//                {
//                    Console.WriteLine("success");

//                }
//                else
//                {
//                    Console.WriteLine("fail");
//                }
//                return json;
//            }

//        }
//    }
//}

using System.Text.Json;
using theOfficialServer;
using theOfficialServer.Data_Source;
using theOfficialServer.Models;

var builder = WebApplication.CreateBuilder(args);

/// <summary>
/// Setup Services
/// </summary>

//builder.Services.AddSingleton<TwitterEndpoints>();
//builder.Services.AddScoped<TwitterEndpoints>();
string bearer = "AAAAAAAAAAAAAAAAAAAAAOt%2FkwEAAAAAI%2B5mBcPilusrbdYW2mG4mjo6hao%3DfvnnDXKiBGfJEdGEC5iF8pHyeB8TnqkqT6TRbQLscifnvSprl3";

TwitterApi.InitializeClient(bearer);
builder.Services.AddTransient<TwitterEndpoints>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Add Middleware
/// </summary>

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.MapGet("/api/data", () => "enter content to query from Twitter");

//app.MapGet("/api/user", searchTweetss(string bear) =>
//{
//    return Results.Ok(app);
//});

app.MapGet("/api/user", (context) =>
{
    var tweets = app.Services.GetService<TwitterEndpoints>().searchTweets(bear);
    var json = JsonSerializer.Serialize<IEnumerable<Tweets>>(tweets);
    return context.Response.WriteAsync(json);
});

app.MapGet("/api/randomTweetVIP", () => "it's a beautiful day in the neighborhood");

//app.MapPost("/api/{string:me}", () => "it's a beautiful day in the neighborhood");

/// <summary>
/// Start the Server 
/// </summary>
app.Run();