using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Models.Entities
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Nome { get; set; }
        public string Autore { get; set; }

        public DateTime DataPubblicazione { get; set; }

        public string Editore { get; set; }

        public List<Categoria> Categorie { get; set; }
    }
}
