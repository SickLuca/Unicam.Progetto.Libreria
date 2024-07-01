using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Services;

namespace Unicam.Progetto.Libreria.Application.Middlewares
{
    /// <summary>
    /// Middleware di esempio per la pipeline di elaborazione delle richieste.
    /// </summary>
    public class MiddlewareExample
    {
       
        private RequestDelegate _next;


        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="MiddlewareExample"/>.
        /// </summary>
        /// <param name="next">Il delegato che rappresenta il prossimo middleware nella pipeline.</param>

        public MiddlewareExample (RequestDelegate next)
        {
            _next = next;
        }



        /// <summary>
        /// Metodo invocato per elaborare la richiesta HTTP.
        /// </summary>
        /// <param name="context">Il contesto della richiesta HTTP.</param>
        /// <param name="libroService">Il servizio libro iniettato.</param>
        /// <param name="configuration">L'oggetto di configurazione iniettato.</param>
        /// <returns>Un <see cref="Task"/> che rappresenta l'operazione asincrona.</returns>
        public async Task Invoke(HttpContext context
            , ILibroService libroService
            , IConfiguration configuration)
        {
            await _next.Invoke(context);
        }
    }
}
