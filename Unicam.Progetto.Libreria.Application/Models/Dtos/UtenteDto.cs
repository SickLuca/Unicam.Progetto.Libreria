using Microsoft.AspNetCore.Components.Forms;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Dtos
{
    public class UtenteDto
    {

        public int UtenteId { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;


        public string Cognome { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


        public UtenteDto(Utente utente)
        {

            UtenteId = utente.UtenteId;
            Nome = utente.Nome;
            Cognome = utente.Cognome;
            Email = utente.Email;
            Password = utente.Password;
        }

    }
}
