using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Services
{
    //mappiamo le operazioni che devono essere definite sui libri (es caricamento, modifica, eliminazione, ecc..)
    public class LibroService : ILibroService
    {
        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }


    }
}
