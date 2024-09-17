namespace API_Task.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsExtensionsCustom(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("https://localhost:44331")
                       .AllowAnyMethod()
                       .AllowAnyHeader();

            }));

            return services;
        }
    }
}
