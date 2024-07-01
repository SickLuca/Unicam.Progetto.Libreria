using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;

namespace Unicam.Progetto.Libreria.Models.Repositories
{

    /// <summary>
    /// Classe repository per gestire le operazioni specifiche degli utenti nel contesto del database.
    /// Eredita da GenericRepository per fornire operazioni di base.
    /// </summary>
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {
        }


        /// <summary>
        /// Recupera un utente dal database utilizzando l'email dell'utente.
        /// </summary>
        /// <param name="email">L'email dell'utente da recuperare.</param>
        /// <returns>L'utente corrispondente all'email fornita, oppure null se non trovato.</returns>
        public Utente GetByEmail(string email)
        {
            return _ctx.Set<Utente>().Where(x => x.Email.Equals(email)).FirstOrDefault();
        }


        /// <summary>
        /// Verifica se esiste un utente nel database con la combinazione email e password fornita.
        /// </summary>
        /// <param name="email">L'email dell'utente da verificare.</param>
        /// <param name="password">La password dell'utente da verificare.</param>
        /// <returns>True se esiste un utente con l'email e la password fornita, false altrimenti.</returns>
        public bool checkMailPassword(string email, string password)
        {
            return _ctx.Set<Utente>().Where(x => x.Email.Equals(email) && x.Password.Equals(password)).Any();
        }
    }
}
