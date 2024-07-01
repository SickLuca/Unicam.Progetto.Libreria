using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Models.Repositories
{

    /// <summary>
    /// Classe repository per gestire le operazioni specifiche dei libri nel contesto del database.
    /// Eredita da GenericRepository per fornire operazioni di base.
    /// </summary>
    public class LibroRepository : GenericRepository<Libro>
    {

        public LibroRepository(MyDbContext context) : base(context)
        {

        }


        /// <summary>
        /// Recupera un libro dal database utilizzando l'ID del libro.
        /// Include anche le relazioni con le categorie del libro.
        /// </summary>
        /// <param name="id">L'ID del libro da recuperare.</param>
        /// <returns>Il libro corrispondente all'ID fornito, incluse le categorie associate.</returns>
        public Libro GetLibro(object id)
        {
            return _ctx.Set<Libro>().Include(c => c.CategorieDelLibro).Where(x => x.LibroId == (int)id).FirstOrDefault();
        }




        /// <summary>
        /// Recupera una lista di libri dal database utilizzando i criteri di filtro forniti.
        /// </summary>
        /// <param name="from">L'indice iniziale per la paginazione.</param>
        /// <param name="num">Il numero di risultati da recuperare.</param>
        /// <param name="name">Il nome del libro da filtrare (opzionale).</param>
        /// <param name="author">Il nome dell'autore da filtrare (opzionale).</param>
        /// <param name="publicationDate">La data di pubblicazione del libro da filtrare (opzionale).</param>
        /// <param name="editor">Il nome dell'editore da filtrare (opzionale).</param>
        /// <param name="categoryName">Il nome della categoria da filtrare (opzionale).</param>
        /// <param name="totalNum">Restituisce il numero totale di risultati che corrispondono ai criteri di filtro.</param>
        /// <returns>Una lista di libri che corrispondono ai criteri di filtro forniti, con paginazione applicata.</returns>
        public List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? editor, string? categoryName, out int totalNum)
        {
            // Iniziare con la query base
            var query = _ctx.Libri.AsQueryable();

            // Applicare i filtri se forniti
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Nome.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(author))
            {
                query = query.Where(w => w.Autore.ToLower().Contains(author.ToLower()));
            }

            if (publicationDate.HasValue)
            {
                query = query.Where(w => w.DataPubblicazione == publicationDate.Value);
            }

            if (!string.IsNullOrEmpty(editor))
            {
                query = query.Where(w => w.Autore.ToLower().Contains(editor.ToLower()));
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query
                    .Where(w => w.CategorieDelLibro
                        .Any(bc => bc.CategoriaJoin.NomeCategoria.ToLower().Contains(categoryName.ToLower())));
            }

            // Calcolare il numero totale di risultati che corrispondono ai criteri di filtro
            totalNum = query.Count();

            // Restituire i risultati paginati
            return query
                .OrderBy(o => o.Nome)
                .Skip(from)
                .Take(num)
                .ToList();
        }



    }
}
