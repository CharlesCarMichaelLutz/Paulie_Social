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
var issuer = builder.Configuration["Jwt:Issuer"];
var audience = builder.Configuration["Jwt:Audience"];
var jwtSigningKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Guid"]);

var authUsername = builder.Configuration["Login:username"];
var authPassword = builder.Configuration["Login:password"];

var services = builder.Services;

//Dependency Injection
services.AddScoped<ITweetRepository, TweetRepository>();

//Authentication 
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(jwtSigningKey),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false, //In any other application other then demo this needs to be true 
        ValidateIssuerSigningKey = true
    };
});

//services.AddAuthentication();
services.AddAuthorization();

services.AddHttpClient<ITweetRepository, TweetRepository>(client =>
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.BaseAddress = new Uri("https://api.twitter.com/2/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", twitterApiKey);
});

var securityScheme = new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "JSON Web Token based security",
};

var securityReq = new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] {}
    }
};

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Paulie Social",
        Description = "See the chirps of the world",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(securityReq);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Paulie Social API V1");
});

app.UseAuthorization();
app.UseAuthentication();

//JWT Route
app.MapPost("/api/login", [AllowAnonymous] (UserDto user) =>
{
    if (user.username == authUsername && user.password == authPassword)
    {
        var securityKey = new SymmetricSecurityKey(jwtSigningKey);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", "1"),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            Audience = audience,
            Issuer = issuer,
            SigningCredentials = credentials
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);
        return Results.Ok(jwtToken);
    }
    return Results.Unauthorized();
});

//Routing

//get tweets by searchTerm
app.MapGet("/api/explore/content/{searchTerm}",
    async (ITweetRepository tweetRepository, string searchTerm) =>
    {
        var result = await tweetRepository.GetTweetsByContent(searchTerm);
        return Results.Ok(result);
    });

//app.MapGet("/twitter/search/username/{username}",
//    [Authorize] (ITweetRepository getUser, string username) =>
//    {
//        var result = getUser.GetTweetsByUsername(username);
//        return Results.Ok(result);
//    });

//app.MapGet("/twitter/vips/random",
//    [Authorize] (ITweetRepository vip, int id) =>
//    {
//        var result = vip.GetRandomTweet(id);
//        return Results.Ok(result);
//    });

//Mock Service Routing

//app.MapGet("/twitter",
//     [Authorize] (ITweetRepository allTweets) =>
//    {
//        var result = allTweets.GetAllTweets();
//        return Results.Ok(result);
//    });

//app.MapGet("/twitter/search/content/{searchTerm}",
//    [Authorize] (ITweetRepository content, string searchTerm) =>
//    {
//        var result = content.GetTweetsByContent(searchTerm);
//        return Results.Ok(result);
//    });

app.Run();

//user login
record UserDto(string username, string password);

