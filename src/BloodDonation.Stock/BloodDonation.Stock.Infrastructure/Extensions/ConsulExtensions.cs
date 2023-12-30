using BloodDonation.Stock.Core.Services.HttpRequest;
using BloodDonation.Stock.Core.Services.ServiceDiscovery;
using BloodDonation.Stock.Infrastructure.Services.HttpRequest;
using BloodDonation.Stock.Infrastructure.Services.ServiceDiscovery;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BloodDonation.Stock.Infrastructure.Extensions
{
    public static class ConsulExtensions
    {
        public static IServiceCollection AddConsulSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p =>
           new ConsulClient(consulConfig =>
           {
               var host = configuration.GetSection("Settings:ServiceDiscovery:Url");
               consulConfig.Address = new Uri(host.Value!);
           }));

            services.AddSingleton<IServiceDiscoveryService, ConsulService>();
            services.AddSingleton<IHttpRequestService, HttpRequestService>();
            services.AddSingleton<IStockRequestService, StockRequestService>();
            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = configuration.GetSection("Settings:ApiSettings:ID").Value,
                Name = configuration.GetSection("Settings:ApiSettings:Name").Value,
                Address = configuration.GetSection("Settings:ApiSettings:Address").Value,
                Port = int.Parse(configuration.GetSection("Settings:ApiSettings:Port").Value!),
                Tags = new[] { configuration.GetSection("Settings:ApiSettings:Tags").Value }
            };
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Unregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            });

            return app;
        }
    }
}
