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

//Routing 
app.MapGet("/twitter", (ITweetRepository allTweets) =>  allTweets.GetAllTweets());

app.MapGet("/twitter/search/content/{searchTerm}", (ITweetRepository content, string searchTerm) => content.GetTweetsByContent(searchTerm));

app.MapGet("/twitter/search/username/{username}", (ITweetRepository getUser, string username) => getUser.GetTweetsByUsername(username));

app.MapGet("/twitter/vips/random", (ITweetRepository vip, int id) => vip.GetRandomTweet(id));


app.Run();
