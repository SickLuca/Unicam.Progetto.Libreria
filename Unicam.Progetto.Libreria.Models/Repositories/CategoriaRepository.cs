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
    public class CategoriaRepository : GenericRepository<Categoria>
    {
        public CategoriaRepository(MyDbContext ctx) : base(ctx)
        {

        }

        public Categoria GetByNome(string nome)
        {
            return _ctx.Set<Categoria>().Include(c => c.LibriDellaCategoria).Where(x => x.NomeCategoria.Equals(nome)).FirstOrDefault();
        }
    }
}
