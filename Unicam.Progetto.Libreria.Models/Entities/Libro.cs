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
        //per mettere campo obbligatorio aggiungere ?
        public int LibroId { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Autore { get; set; } = String.Empty;  

        public DateTime DataPubblicazione { get; set; } = DateTime.Now;

        public string Editore { get; set; } = String.Empty;

        //questa sarà la nostra proprietà di navigazione che ci permette di passare da un entità all'altra
        public virtual ICollection<LibriCategorie> CategorieDelLibro { get; set; } = null!; //stiamo forzando che all'interno di questa assegnazione posso mettere il nullo
    } 
}
