using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using theOfficialServer;
using theOfficialServer.Authentication;
using theOfficialServer.Controllers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

/// <summary>
/// Setup Services
/// </summary>
services.AddAuthentication().AddTwitter(twitterOptions =>
{
    twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerAPIKey"];
    twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
});

builder.Services.AddControllers();
builder.Services.AddSingleton<ITwitterService, TwitterService>();
Console.WriteLine(configuration);
builder.Services.AddHttpClient<ITwitterService, TwitterService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddRazorPages();
//builder.Services.AddTransient<TwitterService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Add Middleware
/// </summary>
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseMiddleware<ApiKeyAuthMiddleware>();

//app.UseAuthorization();

//app.MapControllers();

app.MapGet("/search/{content}", async (string tweetContent, TwitterService getByText) =>
{
    await getByText.SearchTweets(tweetContent);
});

app.MapGet("/search/{id}", async (string username, TwitterService getByUsername) =>
{
    await getByUsername.SearchUsers(username);
});

app.MapGet("/randomVIP", async (string random, TwitterService RandomVIP) =>
{
    await RandomVIP.GetVipTweet(random);
});

//https://api.twitter.com/2/tweets/search/recent?query=ethereum

    /// <summary>
    /// Start the Server 
    /// </summary>
    app.Run();