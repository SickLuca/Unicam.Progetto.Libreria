using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class CreateCategoriaRequest
    {
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }

        public Categoria toEntity()
        {
            Categoria categoria = new Categoria();
            categoria.NomeCategoria = NomeCategoria;
            return categoria;
        }

    }
}
