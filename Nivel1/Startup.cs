using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nivel1.Data.Context;
using Nivel1.Data.UnitOfWork;
using Nivel1.Data.UnitOfWork.Interfaces;
using Nivel1.Domain.Services;
using Nivel1.Domain.Services.Interfaces;
using Nivel1.Shared.Mappers;

namespace Nivel1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("db");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddAutoMapper(c => c.AddProfile<ProfileMapper>(), typeof(Startup));

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Trilha .Net Nivel 1 - Web API",
                        Version = "v1",
                        Description = "Exemplo de um Web Api"
                    });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trilha .Net");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
