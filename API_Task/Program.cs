using API_Task.Extensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using API_Task.Middleware;
using API_Task.DbContextTask.Impl;
using System.Net;
using Microsoft.OpenApi.Models;
using System.Web;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

// Add services to the container.

builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

}).AddNewtonsoftJson(options =>
{
    options.UseMemberCasing();
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.None;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var apiKeyValue = builder.Configuration.GetSection("ApiKey").Value;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "API Key necesita para acceder a los endpoints el es ApiKey: abc123456",
        Name = "ApiKey",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "ApiKey"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            new List<string>()
        }
    });
});

//configure CORS
builder.Services.AddCorsExtensionsCustom(builder.Configuration);



builder.Services.AddHttpContextAccessor();

//configure DI
builder.Services.AddDIExtension(Assembly.GetExecutingAssembly());

var app = builder.Build();



app.UseCors("MyPolicy");

app.Use(async (context, next) =>
{
    if (context.Request.Method == "OPTIONS")
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, ApiKey");
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        await context.Response.CompleteAsync();
    }
    else
    {
        await next();
    }
});

if (app.Environment.IsDevelopment())
{

    //validate API Key
    app.UseMiddleware<ApiKeyMiddleware>();

    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();

    // Enable middleware to serve Swagger UI, specifying the Swagger JSON endpoint.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        var escapedApiKeyValue = HttpUtility.JavaScriptStringEncode(apiKeyValue);

        
        c.ConfigObject.AdditionalItems["requestInterceptor"] = $"function (request) {{ request.headers['ApiKey'] = '{escapedApiKeyValue}'; return request; }}";
       
    });
}


// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();  // This applies any pending migrations
}
app.UseHttpsRedirection();



app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
