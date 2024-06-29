using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;

namespace Unicam.Progetto.Libreria.Models.Repositories
{
    public class UtenteRepository : GenericRepository<Utente>
    {
        public UtenteRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public Utente GetByEmail(string email)
        {
            return _ctx.Set<Utente>().Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
        public bool checkMailPassword(string email, string password)
        {
            return _ctx.Set<Utente>().Where(x => x.Email.Equals(email) && x.Password.Equals(password)).Any();
        }
    }
}
