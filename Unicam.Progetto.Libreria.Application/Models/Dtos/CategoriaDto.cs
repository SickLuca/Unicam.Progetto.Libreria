using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Dtos
{
    public class CategoriaDto
    {
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; } = string.Empty;

        public List<string> LibriDellaCategoria { get; set; } = null!;

        public CategoriaDto(Categoria categoria)
        {
            NomeCategoria = categoria.NomeCategoria;
        }
    }
}
