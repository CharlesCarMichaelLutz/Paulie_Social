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
//services.AddAuthorization();

services.AddHttpClient<ITweetService, TweetService>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", twitterApiKey);
});

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


services.AddCors(options =>
{
    options.AddPolicy("ReactAppPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowCredentials()
          .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paulie Social API V1");
    });
}

//app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();

app.UseCors("ReactAppPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/api/explore/content/{searchTerm}",
        async (ITweetService tweetService, string searchTerm) =>
        {
            var result = await tweetService.GetTweetsByContent(searchTerm);
            return Results.Ok(result);
        });

    endpoints.MapGet("/api/explore/{username}",
        async (ITweetService tweetService, string username) =>
        {
            var result = await tweetService.GetTweetsByUsername(username);
            return Results.Ok(result);
        });

    endpoints.MapGet("/api/randomVip/{id}",
        async (ITweetService tweetService, string id) =>
        {
            var result = await tweetService.GetRandomVipTweet(id);
            return Results.Ok(result);
        });

    endpoints.MapFallback(async context =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
    });
});

app.Run();




