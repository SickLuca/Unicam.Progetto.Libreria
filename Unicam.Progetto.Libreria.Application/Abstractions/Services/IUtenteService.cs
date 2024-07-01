using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    /// <summary>
    /// Interfaccia implementata dall'entità Utente al fine di esporre i servizi necessari alle web api.
    /// </summary>
    public interface IUtenteService
    {
        /// <summary>
        /// Metodo che permette il caricamento di un nuovo utente sul database
        /// </summary>
        /// <param name="utente">L'oggetto Utente che vogliamo caricare</param>
        /// <returns>True se il caricamento è andato a buon fine, false altrimenti</returns>
        bool AddUtente(Utente utente);

        /// <summary>
        /// Metodo utilizzato per effettuare il login di un utente già esistente nel database. Si serve della 
        /// generazione di un token Jwt
        /// </summary>
        /// <param name="mail">La mail dell'utente</param>
        /// <param name="password">La password dell'utente</param>
        /// <returns>Il token jwt che viene generato se la combinazione utente/password è accettata</returns>
        string Login(string mail, string password);

    }
}
