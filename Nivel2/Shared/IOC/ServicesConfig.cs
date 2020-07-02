using Microsoft.Extensions.DependencyInjection;
using Nivel2.AppServices;
using Nivel2.AppServices.Interfaces;
using Nivel2.Data.Repositories;
using Nivel2.Data.Repositories.Interfaces;
using Nivel2.Domain.Services;
using Nivel2.Domain.Services.Interfaces;

namespace Nivel2.Shared.IOC
{
    public static class ServicesConfig
    {
        public static void Configure(IServiceCollection services)
        {
            #region AppServices

            services.AddTransient<ICartAppService, CartAppService>();

            #endregion

            #region Services

            services.AddTransient<ICartService, CartService>();

            #endregion


            #region Repositories

            services.AddTransient<ICartRepository, CartRepository>();

            #endregion
        }
    }
}