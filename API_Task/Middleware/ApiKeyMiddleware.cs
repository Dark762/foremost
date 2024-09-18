using CrossCutting.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace API_Task.Middleware
{
    public class ApiKeyMiddleware
    {
        private const string ApiKeyHeaderName = "ApiKey"; 
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
     
            if (context.Request.Path.Value.Contains("swagger"))
            {
                await _next(context);
                return;
            }

            var expectedApiKey = _configuration["ApiKey"];

            if (string.IsNullOrWhiteSpace(expectedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("API key is not configured.");
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await WriteJsonResponse(context, "Unauthorized: Missing API key.");
                return;
            }

            if (!providedApiKey.Equals(expectedApiKey)) {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await WriteJsonResponse(context, "Unauthorized: API key Invalid.");
                return;
            }

        


            await _next(context);
        }

      
        private async Task WriteJsonResponse(HttpContext context, string message)
        {
            context.Response.ContentType = "application/json";
            var errorResponse = new StatusResponse()
            {
                Success = false,
                Message = message
            }; 
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}
