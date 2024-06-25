using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Dtos
{
    public class LibroDto
    {
        public int LibroId { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Autore { get; set; } = String.Empty;

        public DateTime DataPubblicazione { get; set; } = DateTime.Now;

        public string Editore { get; set; } = String.Empty;

        //questa sarà la nostra proprietà di navigazione che ci permette di passare da un entità all'altra
        public List<string> Categorie { get; set; } = null!;



        public LibroDto(Libro libro)
        {

            LibroId = libro.LibroId;
            Nome = libro.Nome;
            Autore = libro.Autore;
            DataPubblicazione = libro.DataPubblicazione;
            Editore = libro.Editore;
            Categorie = libro.CategorieDelLibro.Select(lc => lc.CategoriaJoin.NomeCategoria).ToList();
        }

        public LibroDto()
        {

        }

    }
}
