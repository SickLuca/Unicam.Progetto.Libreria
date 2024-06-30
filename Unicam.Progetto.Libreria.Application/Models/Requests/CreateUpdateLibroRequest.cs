using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class CreateUpdateLibroRequest { 
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Autore { get; set; }
    public string Editore { get; set; }
    public DateTime DataPubblicazione { get; set; }
    public List<int> CategorieIds { get; set; }


        public Libro ToEntity()
        {
            //trasformiamo in libro usando il mapping

            Libro libro = new Libro();
            libro.Nome = Nome;
            libro.Autore = Autore;
            libro.DataPubblicazione = DataPubblicazione;
            libro.Editore = Editore;
            libro.CategorieDelLibro = new List<LibriCategorie>();
            //librerie come automapper lo fanno in modo automatico
            return libro;

        }
    }
}
