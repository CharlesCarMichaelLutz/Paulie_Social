using PaulieSocialWebApi.Repositories.TweetRepository;
using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var twitterApiKey = builder.Configuration["Twitter:bearerToken"];
var services = builder.Services;

services.AddScoped<ITweetService, TweetService>();

services.AddAuthentication();
services.AddAuthorization();

services.AddHttpClient<ITweetService, TweetService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", twitterApiKey);
});

//Add Cors policy
services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//services.AddCors();

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

app.UseAuthorization();
app.UseAuthentication();

//Use Cors policy
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

//app.UseCors();

//Routing

//get tweets by searchTerm
app.MapGet("/api/explore/content/{searchTerm}",
    async (ITweetService tweetRepository, string searchTerm) =>
    {
        var result = await tweetRepository.GetTweetsByContent(searchTerm);
        return Results.Ok(result);
    });

app.MapGet("/api/explore/{username}",
    async (ITweetService getUser, string username) =>
    {
        var result = await getUser.GetTweetsByUsername(username);
        return Results.Ok(result);
    });

//app.MapGet("/api/randomVip",
//    [Authorize] (ITweetRepository vip, int id) =>
//    {
//        var result = vip.GetRandomTweet(id);
//        return Results.Ok(result);
//    });

app.Run();


