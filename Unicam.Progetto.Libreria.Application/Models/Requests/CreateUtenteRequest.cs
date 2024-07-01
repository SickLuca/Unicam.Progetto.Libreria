using Microsoft.AspNetCore.Components.Forms;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la creazione di una nuovo utente.
    /// </summary>
    public class CreateUtenteRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;


        public string Cognome { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        /// <summary>
        /// Converte l'istanza di <see cref="CreateUtenteRequest"/> in un'istanza di <see cref="Utente"/>.
        /// </summary>
        /// <returns>Un'istanza di <see cref="Utente"/> con i dati della richiesta.</returns>
        public Utente ToEntity()
        {
            //mapping

            Utente utente = new Utente();
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Email = Email;
            utente.Password = Password;
            
            return utente;

        }
    }
}
