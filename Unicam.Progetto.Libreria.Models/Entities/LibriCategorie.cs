using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Models.Entities
{
    public class LibriCategorie
    {
        public int LibroId { get; set; }
        public virtual Libro LibroJoin { get; set; }
        public int CategoriaId {get; set; }
        public virtual Categoria CategoriaJoin { get; set; }

    }
}
