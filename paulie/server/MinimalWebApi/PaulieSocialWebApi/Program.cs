using PaulieSocialWebApi.Repositories.TweetRepository;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

//Dependency Injection

services.AddScoped<ITweetRepository, TweetRepository>();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
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
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paulie Social API V1");
});

app.MapGet("/twitter", (ITweetRepository allTweets) =>  allTweets.GetAllTweets());

//TODO - create route for searching by content
app.MapGet("/twitter/search/content/{searchTerm}", (string searchTerm, ITweetRepository content) => content.GetTweetsByContent(searchTerm));

//TODO - create route for searching by username
app.MapGet("/twitter/search/username/{username}", (string username, ITweetRepository getUser) => getUser.GetTweetsByUsername(username));

//TODO - create route for getting random VIP tweets
app.MapGet("/twitter/vips/random", (ITweetRepository vip) => vip.GetRandomTweet());


app.Run();
