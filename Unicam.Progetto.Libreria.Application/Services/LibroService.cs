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
    /// <summary>
    /// Servizio per la gestione delle operazioni sui libri.
    /// </summary>
    public class LibroService : ILibroService
    {

        // Dipendenza iniettata per ottenere il repository dei libri, il contesto del database e il repository delle categorie
        private readonly LibroRepository _libroRepository;
        private readonly CategoriaRepository _categoriaRepository;
        private readonly MyDbContext _context;


        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="LibroService"/>.
        /// </summary>
        /// <param name="libroRepository">Il repository dei libri.</param>
        /// <param name="context">Il contesto del database.</param>
        /// <param name="categoriaRepository">Il repository delle categorie.</param>
        public LibroService(LibroRepository libroRepository, MyDbContext context, CategoriaRepository categoriaRepository)
        {
            _libroRepository = libroRepository;
            _context = context;
            _categoriaRepository = categoriaRepository;
        }



        /// <summary>
        /// Aggiunge un nuovo libro con le categorie specificate.
        /// </summary>
        /// <param name="libro">Il libro da aggiungere.</param>
        /// <param name="categorieIds">Gli ID delle categorie da associare al libro.</param>
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



        /// <summary>
        /// Ottiene una lista di libri in base ai criteri di ricerca specificati. Grazie al validatore, almeno un parametro
        /// sarà obbligatorio.
        /// </summary>
        /// <param name="from">L'indice iniziale della lista dei libri da restituire.</param>
        /// <param name="num">Il numero di libri da restituire.</param>
        /// <param name="name">Il nome del libro (facoltativo).</param>
        /// <param name="author">L'autore del libro (facoltativo).</param>
        /// <param name="publicationDate">La data di pubblicazione del libro (facoltativo).</param>
        /// <param name="editor">L'editore del libro (facoltativo).</param>
        /// <param name="categoryName">Il nome della categoria (facoltativo).</param>
        /// <param name="totalNum">Il numero totale di libri che corrispondono ai criteri di ricerca.</param>
        public List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? editor, string? categoryName, out int totalNum)
        {
            return _libroRepository.GetLibri(from, num, name, author, publicationDate, editor, categoryName, out totalNum);
        }



        /// <summary>
        /// Rimuove un libro specificato per ID.
        /// </summary>
        /// <param name="id">L'ID del libro da rimuovere.</param>
        /// <returns>true se il libro è stato rimosso con successo, false altrimenti.</returns>
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



        /// <summary>
        /// Aggiorna le informazioni di un libro esistente e le categorie associate.
        /// </summary>
        /// <param name="id">L'ID del libro da aggiornare.</param>
        /// <param name="nome">Il nuovo nome del libro.</param>
        /// <param name="autore">Il nuovo autore del libro.</param>
        /// <param name="editore">Il nuovo editore del libro.</param>
        /// <param name="data">La nuova data di pubblicazione del libro.</param>
        /// <param name="categorie">Gli ID delle nuove categorie da associare al libro.</param>
        /// <returns>true se il libro è stato aggiornato con successo, false se il libro non esiste.</returns>
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
