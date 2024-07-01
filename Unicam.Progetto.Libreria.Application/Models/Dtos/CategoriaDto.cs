using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Dtos
{
    /// <summary>
    /// Data Transfer Object (DTO) per la classe Categoria.
    /// </summary>
    public class CategoriaDto
    { 
        public string NomeCategoria { get; set; } = string.Empty;


        public CategoriaDto(Categoria categoria)
        {
            NomeCategoria = categoria.NomeCategoria;
        }
    }
}
