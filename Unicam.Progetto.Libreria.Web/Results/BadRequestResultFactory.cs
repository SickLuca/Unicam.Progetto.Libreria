using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Models.Responses;

namespace Unicam.Progetto.Libreria.Web.Results
{

    /// <summary>
    /// Classe che rappresenta un oggetto BadRequest con dettagli degli errori di validazione del modello.
    /// Estende BadRequestObjectResult per fornire un'implementazione personalizzata.
    /// </summary>
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        /// <summary>
        /// Costruttore della classe BadRequestResultFactory.
        /// </summary>
        /// <param name="context">Contesto di azione che contiene lo stato del modello non valido.</param>
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
            var retErrors = new List<string>();
            // Itera su ogni chiave del modello per recuperare gli errori di validazione.
            foreach (var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                for (var i = 0; i < errors.Count(); i++)
                {
                    retErrors.Add(errors[0].ErrorMessage); // Aggiunge l'errore alla lista degli errori ritornati.
                }
            }

            // Ottiene l'oggetto BadResponse dall'oggetto Value di BadRequestObjectResult.
            var response = (BadResponse)Value;
            // Imposta gli errori nella proprietà Errors di BadResponse.
            response.Errors = retErrors;
        }

    }
}
