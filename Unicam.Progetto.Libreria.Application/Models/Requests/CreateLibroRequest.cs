﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la creazione di un nuovo libro.
    /// </summary>
    public class CreateLibroRequest
    {
        public string Nome { get; set; } = string.Empty;    

        public string Autore {  get; set; } = string.Empty;

        public DateTime DataPubblicazione { get; set; } = DateTime.MinValue;

        public string Editore {  get; set; } = string.Empty;

        public List<int> CategorieIds { get; set; }


        /// <summary>
        /// Converte l'istanza di <see cref="CreateLibroRequest"/> in un'istanza di <see cref="Libro"/>.
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
         
            return libro;

        }
    }
}
