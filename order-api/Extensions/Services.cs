using order_api.Extensions.Middleware;
using order_api.Models.Settings;
using order_api.Services;

namespace order_api.Extensions
{
    public static class ServiceInjectionExtenstions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            Console.WriteLine("Adding Services.......");
            var transientServiceType = typeof(IServerService);
            var scopedServiceType = typeof(IScopedService);
            var transientServices = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(s => s.GetTypes())
           .Where(p => transientServiceType.IsAssignableFrom(p))
           .Where(t => t.IsClass && !t.IsAbstract)
           .Select(t => new
           {
               Service = t.GetInterfaces().FirstOrDefault(),
               Implementation = t
           })
           .Where(t => t.Service != null);

            foreach (var transientService in transientServices)
            {
                if (transientServiceType.IsAssignableFrom(transientService.Service))
                {
                    services.AddTransient(transientService.Service, transientService.Implementation);
                }
            }

            var scopedServices = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(s => s.GetTypes())
           .Where(p => scopedServiceType.IsAssignableFrom(p))
           .Where(t => t.IsClass && !t.IsAbstract)
           .Select(t => new
           {
               Service = t.GetInterfaces().FirstOrDefault(),
               Implementation = t
           })
           .Where(t => t.Service != null);

            foreach (var scopedService in scopedServices)
            {
                if (scopedServiceType.IsAssignableFrom(scopedService.Service))
                {
                    services.AddScoped(scopedService.Service, scopedService.Implementation);
                }
            }

            return services;
        }
        public static IServiceCollection AddScoppedServices(this IServiceCollection services)
        {
            services.AddScoped<ExceptionMiddleWare>();
            services.AddScoped<AdmnMiddleware>();
            return services;
        }
        
        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpLogin>(configuration.GetSection("SmtpLogin"));
            return services;
        }
        

    }
}
