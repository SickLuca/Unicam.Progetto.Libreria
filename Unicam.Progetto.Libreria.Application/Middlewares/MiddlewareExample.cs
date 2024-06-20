using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Services;

namespace Unicam.Progetto.Libreria.Application.Middlewares
{
    public class MiddlewareExample
    {
        //Le uniche cose che deve fare un middleware sono quelle di: avere un costruttore con ingresso un istanza di RequestDelegate (scrivere .web in SDK), dopodichè implementiamo metodo asincrono Invoke
        
        private RequestDelegate _next;

        public MiddlewareExample (RequestDelegate next)
        {
            _next = next;
        }


        //Di norma sul middleware non si usa il costruttore con la dependency Injection, si mette sulla invoke, ma comunque il mid è l'unico caso e l'invoke fatta ad ogni esecuzione
        //Dipende da che servizio tu esponi, se fai un servizio con una sola istanza in memoria, allora lo metti nel costruttore (singleton), altrimenti lo metti nella invoke
        public async Task Invoke(HttpContext context
            , ILibroService libroService
            , IConfiguration configuration)
        {
            //implementiamo codice effettivo del mid


            //Per andare al mid successivo dobbiamo chiamare next.Invoke()

            await _next.Invoke(context);
        }
    }
}
