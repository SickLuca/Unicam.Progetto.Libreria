using FluentValidation;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Services;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    /// <summary>
    /// Classe d'estenzione volta al refactoring del codice che risiedeva prima nel program.cs; Contiene tutti i
    /// servizi che vogliamo utilizzare nella nostra applicazione.
    /// </summary>
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
        SingleOrDefault(assembly => assembly.GetName().Name == "Unicam.Progetto.Libreria.Application")
        );

            services.AddScoped<ILibroService, LibroService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IUtenteService, UtenteService>();
            
            return services;
        }
    }
}
