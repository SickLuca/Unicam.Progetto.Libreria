using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    //fluent valuation per validare questi campi nel momento dell inserimento 
    //qui ci metteremo dentro tutti i parametri che serviranno per la creazione della richiesta CreateLibro, ci mappa la richiesta della creazione
    //Questa richiesta ora può essere passata in ingresso all'interno del metodo httppost createLibro che troviamo nel controller
    public class CreateLibroRequest
    {
        public string Nome { get; set; } = String.Empty;    

        public string Autore {  get; set; } = String.Empty;

        public DateTime DataPubblicazione { get; set; } = DateTime.MinValue;

        public string Editore {  get; set; } = String.Empty;

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
