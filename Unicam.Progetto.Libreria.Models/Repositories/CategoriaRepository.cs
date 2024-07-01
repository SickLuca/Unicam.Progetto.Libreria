using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Models.Repositories
{

    /// <summary>
    /// Classe repository per gestire le operazioni specifiche della categoria nel contesto del database.
    /// Eredita da GenericRepository per fornire operazioni di base.
    /// </summary>
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {

        }

        /// <summary>
        /// Recupera una categoria dal database utilizzando il nome della categoria.
        /// Include anche le relazioni con i libri della categoria.
        /// </summary>
        /// <param name="nome">Il nome della categoria da recuperare.</param>
        /// <returns>La categoria corrispondente al nome fornito, inclusi i libri associati.</returns>
        public Categoria GetByNome(string nome)
        {
            return _ctx.Set<Categoria>().Include(c => c.LibriDellaCategoria).Where(x => x.NomeCategoria.Equals(nome)).FirstOrDefault();
        }


        /// <summary>
        /// Recupera una lista di categorie dal database utilizzando una lista di identificatori di categorie.
        /// </summary>
        /// <param name="categorieIds">Lista degli identificatori delle categorie da recuperare.</param>
        /// <returns>Una lista di categorie corrispondenti agli identificatori forniti.</returns>
        public List<Categoria> GetCategorieByIds(List<int> categorieIds)
        {
            return _ctx.Categorie.Where(c => categorieIds.Contains(c.CategoriaId)).ToList();
        }

    }
}
