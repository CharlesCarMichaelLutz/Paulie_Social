using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using theOfficialServer;
using theOfficialServer.Authentication;
using theOfficialServer.Controllers;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

//services.AddAuthentication().AddTwitter(twitterOptions =>
//{
//    twitterOptions.ConsumerKey = configuration["Authentication:Twitter:ConsumerAPIKey"];
//    twitterOptions.ConsumerSecret = configuration["Authentication:Twitter:ConsumerSecret"];
//});

builder.Services.AddHttpClient<ITwitterService, TwitterService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    var credentials = Environment.GetEnvironmentVariable("MY_BEARER_TOKEN");
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentials);
});

builder.Services.AddTransient<ITwitterService, TwitterService>();
//builder.Services.AddScoped<ITwitterService, TwitterService>();
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

//app.UseAuthentication();
//app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseAuthorization();

app.MapGet("/search/{content}", async ([FromServices] TwitterService getByText, [FromQuery]string tweetContent) =>
{
    await getByText.SearchTweets(tweetContent);
});

app.MapGet("/search/username/{id}", async ([FromServices] TwitterService getByUsername, [FromQuery] string username) =>
{
     await getByUsername.SearchUsers(username);
});

app.MapGet("/search/randomVIP", async ([FromServices] TwitterService RandomVIP, [FromQuery] string random) =>
{
    await RandomVIP.GetVipTweet(random);
});

//https://api.twitter.com/2/tweets/search/recent?query=ethereum

app.Run();