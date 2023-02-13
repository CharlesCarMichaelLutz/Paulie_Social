using theOfficialServer.Logic;
using theOfficialServer.Data_Source;
using theOfficialServer.Models;
using theOfficialServer;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

/// <summary>
/// Setup Services
/// </summary>

builder.Services.AddControllers();
builder.Services.AddSingleton<ITwitterEndpoints, TwitterEndpoints>();

builder.Services.AddHttpClient<ITwitterEndpoints, TwitterEndpoints>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorize);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddRazorPages();
//builder.Services.AddTransient<TwitterEndpoints>();
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

//app.MapGet("/search/{content}", async (string tweetContent, TwitterEndpoints getByContent) =>
//{
//    await 
//    getByContent.SearchTweetsByContent(tweetContent).ToListAsync();
//    //return Results.Ok(app);
//});

app.MapGet("/search/{content}", (string tweetContent, TwitterEndpoints getByContent) =>
{
    getByContent.Search(tweetContent);
});

app.MapGet("/randomVIP", async (string random, TwitterEndpoints getRandomVIP) =>
{
    await 
    getRandomVIP.SearchTweetsByContent(random).ToListAsync();
    //return ? Results.Ok(app) : ;
});

//Mock Examples
//app.MapGet("/api/randomTweetVIP", () => "it's a beautiful day in the neighborhood");

//Recent Tweets 
//https://api.twitter.com/2/tweets/search/recent?query=ethereum

    /// <summary>
    /// Start the Server 
    /// </summary>
    app.Run();