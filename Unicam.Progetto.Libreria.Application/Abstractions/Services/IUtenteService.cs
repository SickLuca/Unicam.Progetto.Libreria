using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    public interface IUtenteService
    {
        bool AddUtente(Utente utente);
        string Login(string mail, string password);

    }
}
