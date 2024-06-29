
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Context;
using Microsoft.Extensions.Configuration;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();

            return services;
        }

    }
}
