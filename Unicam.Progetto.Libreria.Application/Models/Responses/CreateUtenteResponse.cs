using Unicam.Progetto.Libreria.Application.Models.Dtos;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta la risposta per la creazione di un nuovo utente.
    /// </summary>
    public class CreateUtenteResponse
    {
        public UtenteDto Utente { get; set; } = null!;

    }
}
