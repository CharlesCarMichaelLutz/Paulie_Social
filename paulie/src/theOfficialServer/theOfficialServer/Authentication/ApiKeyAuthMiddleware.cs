namespace theOfficialServer.Authentication
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        //secrets manager injected here
        private readonly IConfiguration _configuration;

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out 
                var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key is missing");
                return;
            }
            var apiKey = _configuration.GetValue<string>(AuthConstants.ApiKeyHeaderName);
            if (apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Invalid API Key");
            }

            await _next(context);
        }
    }
}
