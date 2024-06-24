using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Models.Entities;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Application.Services
{
    //mappiamo le operazioni che devono essere definite sui libri (es caricamento, modifica, eliminazione, ecc..)
    public class LibroService : ILibroService
    {

        //dipendecy injection per ottenere repo, strato di persistenza
        private readonly LibroRepository _libroRepository;
        public LibroService(LibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }

        public void AddLibro (Libro libro) {

            _libroRepository.Aggiungi(libro);
            _libroRepository.Save();
        }

    }
}
