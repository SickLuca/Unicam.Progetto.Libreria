using FluentValidation;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Services;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    /// <summary>
    /// Classe statica che contiene metodi di estensione per la configurazione dei servizi dell'applicazione.
    /// </summary>
    public static class ServiceExtension
    {

        /// <summary>
        /// Metodo di estensione per aggiungere e configurare i servizi dell'applicazione, inclusi i validatori e i servizi specifici dell'applicazione.
        /// </summary>
        /// <param name="services">La collezione di servizi dell'applicazione.</param>
        /// <param name="configuration">L'oggetto di configurazione dell'applicazione.</param>
        /// <returns>La collezione di servizi aggiornata.</returns>
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration configuration)
        {
            // Aggiunge tutti i validatori dal progetto "Unicam.Progetto.Libreria.Application" all'insieme dei servizi
            services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
        SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Progetto.Libreria.Application")
        );

            // Registra le interfacce dei servizi e le loro implementazioni, con ciclo di vita Scoped
            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUtenteService, UtenteService>();
            
            return services;
        }
    }
}
