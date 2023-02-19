using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using theOfficialServer;
using theOfficialServer.Authentication;
using theOfficialServer.Controllers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddAuthentication().AddTwitter(twitterOptions =>
{
    twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerAPIKey"];
    twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
});

builder.Services.AddHttpClient<ITwitterService, TwitterService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

//builder.Services.AddTransient<ITwitterService, TwitterService>();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Paulie Social",
        Description = "See the chirps of the world",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paulie Social v1");
    });

app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapGet("/intro", () => "What's up?");

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

//app.MapGet("/search/{content}", async (string tweetContent) => await TwitterService.SearchTweets(tweetContent);

//app.MapGet("/search/{id}", async (string username) => await TwitterService.SearchUsers(username);

//app.MapGet("/randomVIP", async (string random) => await TwitterService.GetVipTweet(random);

//https://api.twitter.com/2/tweets/search/recent?query=ethereum

app.Run();