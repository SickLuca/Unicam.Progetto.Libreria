using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Entities;
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
        private readonly CategoriaRepository _categoriaRepository;
        private readonly MyDbContext _context;
        public LibroService(LibroRepository libroRepository, MyDbContext context, CategoriaRepository categoriaRepository)
        {
            _libroRepository = libroRepository;
            _context = context;
            _categoriaRepository = categoriaRepository;
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

        public bool RemoveLibro(int id)
        {
            if (_libroRepository.GetLibro(id) != null)
            {
                _libroRepository.Delete(_libroRepository.GetLibro(id));
                _libroRepository.Save();
                return true;
            }
            return false;
        }



        /*
        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, List<int> categorie)
        {
            List<int> categorieSet = new List<int>();
            categorieSet = GetCategorie(categorie);
            if (_libroRepository.GetLibro(id) != null)
            {
                Libro libro = _libroRepository.GetLibro(id);
                libro.Nome = nome;
                libro.Autore = autore;
                libro.Editore = editore;
                libro.DataPubblicazione = data;
                libro.CategorieDelLibro =  categorieSet;
                _libroRepository.Update(libro);
                _libroRepository.Save();
                return true;
            }
            return false;
        }
        */



        public bool UpdateLibro(int id, string nome, string autore, string editore, DateTime data, List<int> categorie)
        {
            // Recupera il libro esistente
            var libro = _libroRepository.GetLibro(id);
            if (libro == null)
            {
                return false;
            }

            // Aggiorna le proprietà del libro
            libro.Nome = nome;
            libro.Autore = autore;
            libro.Editore = editore;
            libro.DataPubblicazione = data;

            // Recupera le categorie dal database in base agli ID forniti
            var categorieEntities = _categoriaRepository.GetCategorieByIds(categorie);

            // Cancella le categorie attuali del libro
            libro.CategorieDelLibro.Clear();

            // Aggiungi le nuove categorie
            foreach (var categoria in categorieEntities)
            {
                libro.CategorieDelLibro.Add(new LibriCategorie { LibroId = libro.LibroId, CategoriaId = categoria.CategoriaId });
            }

            // Aggiorna il libro nel repository
            _libroRepository.Update(libro);
            _libroRepository.Save();

            return true;
        }

    }
}
