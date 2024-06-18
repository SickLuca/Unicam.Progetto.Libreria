using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Entities
{
    public class Categoria

    {
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<LibriCategorie> LibriDellaCategoria { get; set; }
    }
}
