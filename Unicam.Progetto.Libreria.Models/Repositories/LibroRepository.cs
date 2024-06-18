using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Models.Repositories
{
    public class LibroRepository : GenericRepository<Libro>
    {

        public LibroRepository(MyDbContext context) : base(context)
        {

        }

        //TODO: Controllare obbligatorietà di almeno uno dei campi
        public List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? categoryName, out int totalNum)
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

        public void Modifica(Libro libro)
        {
            _ctx.Entry(libro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

    }
}
