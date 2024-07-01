using Unicam.Progetto.Libreria.Application.Middlewares;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    /// <summary>
    /// Classe d'estenzione volta al refactoring del codice che risiedeva prima nel program.cs; Contiene la pipeline dei
    /// middleware che vogliamo utilizzare nella nostra applicazione.
    /// </summary>
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewareExample>();
            return app;
        }

    }
}
