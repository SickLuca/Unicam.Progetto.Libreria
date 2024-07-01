using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Unicam.Progetto.Libreria.Application.Factories;

namespace Unicam.Progetto.Libreria.Web.Extensions
{

    /// <summary>
    /// Classe statica che fornisce metodi di estensione per configurare i middleware dell'applicazione web.
    /// </summary>
    public static class MiddlewareExtension
    {

        /// <summary>
        /// Metodo di estensione per configurare i middleware dell'applicazione web.
        /// </summary>
        /// <param name="app">L'istanza dell'applicazione web su cui configurare i middleware.</param>
        /// <returns>L'istanza dell'applicazione web con i middleware configurati.</returns>
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            // Configura la pipeline delle richieste HTTP.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            // Redirect HTTP to HTTPS per garantire una connessione sicura.
            app.UseHttpsRedirection();

            // Abilita l'autenticazione per gestire l'accesso agli endpoint protetti.
            app.UseAuthentication();

            // Abilita l'autorizzazione per gestire i permessi agli endpoint.
            app.UseAuthorization();

            // Middleware per gestire le eccezioni globali nell'applicazione.
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    // Imposta lo status code della risposta a InternalServerError (500).
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    // Ottieni il contesto dell'eccezione gestita.
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        // Crea una risposta di errore usando ResponseFactory con l'eccezione ottenuta.
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(res);
                    }
                });
            });

            // Mappa i controller MVC nell'applicazione.
            app.MapControllers();
            return app;
        }

    }
}
