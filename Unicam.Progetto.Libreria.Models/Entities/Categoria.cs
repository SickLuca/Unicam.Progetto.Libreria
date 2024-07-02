using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Entities
{
    /// <summary>
    /// Rappresenta una categoria di libri nel sistema.
    /// </summary>
    public class Categoria

    {
        public int Id { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;

        public virtual ICollection<Libro> Libri{ get; set; } = new List<Libro>();
    }
}
