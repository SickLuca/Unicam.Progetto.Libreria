using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Application.Services
{
    //mappiamo le operazioni che devono essere definite sui libri (es caricamento, modifica, eliminazione, ecc..)
    public class LibroService : ILibroService
    {

        //dipendecy injection per ottenere repo, strato di persistenza
        private readonly LibroRepository _libroRepository;
        private readonly MyDbContext _context;
        public LibroService(LibroRepository libroRepository, MyDbContext context)
        {
            _libroRepository = libroRepository;
            _context = context;
        }

      

        public void AddLibro (Libro libro, List<int> categorieIds) {
            // Carica le categorie esistenti dal database
            
            var categorie = _context.Categorie.Where(c => categorieIds.Contains(c.CategoriaId)).ToList();
            // Associa le categorie caricate al libro
            foreach (var categoria in categorie)
            {
                libro.CategorieDelLibro.Add(new LibriCategorie
                {
                    LibroJoin = libro,
                    CategoriaJoin = categoria
                });
            }
            _libroRepository.Aggiungi(libro);
            _libroRepository.Save();
        }

        public List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? editor, string? categoryName, out int totalNum)
        {
            return _libroRepository.GetLibri(from, num, name, author, publicationDate, editor, categoryName, out totalNum);
        }

        public List<Libro> GetLibri()
        {
            return new List<Libro>();
        }
    }
}
