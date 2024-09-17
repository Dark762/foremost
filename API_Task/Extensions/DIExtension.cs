using System.Reflection;

namespace API_Task.Extensions
{
    public static class DIExtension
    {

        public static void AddDIExtension(this IServiceCollection services, Assembly assembly) {

            foreach (var type in assembly.GetTypes())
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    var interfaces = type.GetInterfaces();
                    foreach (var @interface in interfaces)
                    {
                        services.AddTransient(@interface, type);
                    }
                }
            }
        }
    }
}
