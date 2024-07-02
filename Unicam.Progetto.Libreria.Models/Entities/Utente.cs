using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Progetto.Libreria.Entities
{
    /// <summary>
    /// Rappresenta un utente nel sistema.
    /// </summary>
    public class Utente
    {

        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;


        public string Cognome { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;


    }
}
