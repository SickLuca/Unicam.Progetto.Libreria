using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Progetto.Libreria.Entities
{
    public class Utente
    {

        public int UtenteId { get; set; }
        public string Email { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string Password { get; set; }

    }
}
