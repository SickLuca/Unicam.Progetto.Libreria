using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la modifica di un libro.
    /// </summary>
    public class CreateUpdateLibroRequest { 
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Autore { get; set; }
    public string Editore { get; set; }
    public DateTime DataPubblicazione { get; set; }
    public List<int> CategorieIds { get; set; }


        /// <summary>
        /// Converte l'istanza di <see cref="CreateUpdateLibroRequest"/> in un'istanza di <see cref="Libro"/>.
        /// </summary>
        /// <returns>Un'istanza di <see cref="Libro"/> con i dati della richiesta.</returns>
        public Libro ToEntity()
        {
            //mapping

            Libro libro = new Libro();
            libro.Nome = Nome;
            libro.Autore = Autore;
            libro.DataPubblicazione = DataPubblicazione;
            libro.Editore = Editore;
            libro.CategorieDelLibro = new List<LibriCategorie>();
            
            return libro;

        }
    }
}
