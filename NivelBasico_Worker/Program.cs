using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NivelBasico.Domain.Services;
using NivelBasico.Domain.Services.Interfaces;
using NivelBasico_Worker.Services;
using NivelBasico_Worker.Services.Interfaces;

namespace NivelBasico_Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddScoped<IScopedProcessingUserService, ScopedProcessingUserService>();
                    services.AddScoped<IUserService, UserService>();
                });
    }
}
