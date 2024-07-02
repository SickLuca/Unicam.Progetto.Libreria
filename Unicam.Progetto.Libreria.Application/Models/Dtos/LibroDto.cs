using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Dtos
{

    /// <summary>
    /// Data Transfer Object (DTO) per la classe Libro.
    /// </summary>
    public class LibroDto
    {
        public int LibroId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;

        public DateTime DataPubblicazione { get; set; } = DateTime.Now;

        public string Editore { get; set; } = string.Empty;

        public List<string> Categorie { get; set; } = null!;



        public LibroDto(Libro libro)
        {

            LibroId = libro.Id;
            Nome = libro.Nome;
            Autore = libro.Autore;
            DataPubblicazione = libro.DataPubblicazione;
            Editore = libro.Editore;
            Categorie = libro.Categorie.Select(c => c.NomeCategoria).ToList();
        }
    }
}
