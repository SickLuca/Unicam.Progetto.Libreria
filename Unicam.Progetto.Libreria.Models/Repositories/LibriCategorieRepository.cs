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
    /// Classe repository per gestire le operazioni specifiche delle relazioni tra categorie e libri nel contesto del database.
    /// Eredita da GenericRepository per fornire operazioni di base.
    /// </summary>
    public class LibriCategorieRepository : GenericRepository<LibriCategorie>
    {
        public LibriCategorieRepository(MyDbContext ctx) : base(ctx)
        {
        }
    }
}
