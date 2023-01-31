//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using theOfficialServer.Data_Source;

//namespace theOfficialServer
{
    //public class Program
    //{
    // static void Main(string[] args)
    // {
    //string bearerToken = "AAAAAAAAAAAAAAAAAAAAAOt%2FkwEAAAAAI%2B5mBcPilusrbdYW2mG4mjo6hao%3DfvnnDXKiBGfJEdGEC5iF8pHyeB8TnqkqT6TRbQLscifnvSprl3";
    //TwitterApi.InitializeClient(bearerToken);

    //var result = TwitterEndpoints.SearchTweets();

    //Console.WriteLine(result);

    //string getTweets = searchTweets(bear).Result;
    //Console.WriteLine(getTweets);

    //string getUsers = searchUsers(bear).Result;
    //Console.WriteLine(getUsers);
    //}
    //public static async Task<string> searchTweets(string authorizeToken)
    //{
    //    //string twitterObject = string.Empty;

    //    using (var twitterClient = new HttpClient())
    //    {
    //        string authorization = authorizeToken;

    //        twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
    //        var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=music");
    //        twitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //        HttpResponseMessage response = new HttpResponseMessage();
    //        response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
    //        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            Console.WriteLine("success");
    //        }
    //        else
    //        {
    //            Console.WriteLine("fail");
    //        }
    //        return json;
    //    }
    //}
    //public static async Task<string> searchUsers(string authorizeToken)
    //{
    //    using (var twitterClient = new HttpClient())
    //    {
    //        string authorization = authorizeToken;

    //        twitterClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
    //        var myApi = twitterClient.BaseAddress = new Uri("https://api.twitter.com/2/tweets/search/recent?query=nationalparks");
    //        twitterClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    //        HttpResponseMessage response = new HttpResponseMessage();
    //        response = await twitterClient.GetAsync(myApi).ConfigureAwait(false);
    //        string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            Console.WriteLine("success");

    //        }
    //        else
    //        {
    //            Console.WriteLine("fail");
    //        }
    //        return json;
    //    }
    //}
    //    }
    //}
    using theOfficialServer.Logic;
    using theOfficialServer.Data_Source;
    using theOfficialServer.Models;

    var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

/// <summary>
/// Setup Services
/// </summary>

//builder.Services.AddScoped<TwitterEndpoints>();

builder.Services.AddControllers();
builder.Services.AddSingleton<ITwitterEndpoints, TwitterEndpoints>();

builder.Services.AddHttpClient<ITwitterEndpoints, TwitterEndpoints>(client =>
{
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
});

// endpoint users/by/username

//TwitterApi.InitializeClient(bearer);

builder.Services.AddRazorPages();
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

app.MapGet("/search/{id}", async (string username, TwitterEndpoints getByUsername) =>
{
    await
    getByUsername.SearchTweetsbyUser(username).ToListAsync();
});

//app.MapGet("/api/user", searchTweetss(string bear) =>
//{
//    return Results.Ok(app);
//});

app.MapGet("/search/{content}", async (string tweetContext, TwitterEndpoints getByContent) =>
{
    await 
    getByContent.SearchTweetsByContent(tweetContext).ToListAsync();
    //return Results.Ok(app);
});

app.MapGet("/randomVIP", searchTweetss (string bear) =>
{
    return Results.Ok(app);
});

//Mock Examples
app.MapGet("/api/randomTweetVIP", () => "it's a beautiful day in the neighborhood");

/// <summary>
/// Start the Server 
/// </summary>
app.Run();