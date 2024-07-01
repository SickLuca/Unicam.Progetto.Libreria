
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

    /// <summary>
    /// Classe statica che contiene metodi di estensione per la configurazione dei servizi dell'applicazione.
    /// </summary>
    public static class ServiceExtension
    {

        /// <summary>
        /// Metodo di estensione per aggiungere e configurare i servizi del modello, inclusi il contesto del database e i repository.
        /// </summary>
        /// <param name="services">La collezione di servizi dell'applicazione.</param>
        /// <param name="configuration">L'oggetto di configurazione dell'applicazione.</param>
        /// <returns>La collezione di servizi aggiornata.</returns>
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {

            // Configura il contesto del database MyDbContext utilizzando SQL Server e la stringa di connessione dalla configurazione
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            // Registra le repositories con un ciclo di vita Scoped
            services.AddScoped<LibroRepository>();
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<UtenteRepository>();

            return services;
        }

    }
}
