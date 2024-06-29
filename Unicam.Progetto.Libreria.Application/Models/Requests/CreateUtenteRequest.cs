using Microsoft.AspNetCore.Components.Forms;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class CreateUtenteRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;


        public string Cognome { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public Utente ToEntity()
        {
            //trasformiamo in libro usando il mapping

            Utente utente = new Utente();
            utente.Nome = Nome;
            utente.Cognome = Cognome;
            utente.Email = Email;
            utente.Password = Password;
            
            //librerie come automapper lo fanno in modo automatico
            return utente;

        }
    }
}
