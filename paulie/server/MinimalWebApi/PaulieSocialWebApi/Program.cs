using Microsoft.OpenApi.Models;
using System.Net.Http.Headers;
using PaulieSocialWebApi.Services;
using PaulieSocialWebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var twitterApiKey = builder.Configuration["Twitter:bearerToken"];
var services = builder.Services;

services.AddAuthentication();

services.AddHttpClient("TwitterClient", client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", twitterApiKey);
});

services.AddScoped<ITweetService, TweetService>();
services.AddScoped<IRandomTweetService, RandomTweetService>();

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
            return Results.Ok(new List<TweetModel> { result });
        });

    endpoints.MapGet("/api/explore/{username}",
        async (ITweetService tweetService, string username) =>
        {
            var result = await tweetService.GetTweetsByUsername(username);
            return Results.Ok(new List<TweetModel> { result });
        });

    endpoints.MapGet("/api/randomVip/{id}",
        async (IRandomTweetService randomTweetService, string id) =>
        {
            var result = await randomTweetService.GetRandomVipTweet(id);
            return Results.Ok(result);
        });

    endpoints.MapFallback(async context =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"));
    });
});

app.Run();




