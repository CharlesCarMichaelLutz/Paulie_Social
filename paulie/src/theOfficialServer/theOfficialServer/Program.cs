using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
//using System.Net.Http;
using System.Net.Http.Headers;
using theOfficialServer;
using theOfficialServer.Controllers;
//using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddScoped<ITwitterService, TwitterService>();

services.AddHttpClient<ITwitterService, TwitterService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    var credentials = Environment.GetEnvironmentVariable("MY_BEARER_TOKEN");
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", credentials);
});

services.AddRazorPages();
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
app.UseSwaggerUI();

app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paulie Social v1");
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/search/{content}", async ([FromServices] ITwitterService getByText, [FromQuery]string searchByText) =>
{
    await getByText.SearchTweets(searchByText);

});

app.MapGet("/search/username/{id}", async ([FromServices] ITwitterService getByUsername, [FromQuery] string searchByUsername) =>
{
     await getByUsername.SearchUsers(searchByUsername);
});

app.MapGet("/search/randomVIP", async ([FromServices] ITwitterService createRandomTweet, [FromQuery] string getRandomTweet) =>
{
    await createRandomTweet.GetVipTweet(getRandomTweet);
});

app.Run();