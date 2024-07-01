using Unicam.Progetto.Libreria.Application.Models.Dtos;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta la risposta per la creazione di una nuova categoria.
    /// </summary>
    public class CreateCategoriaResponse
    {
    
        public CategoriaDto Categoria { get; set; } = null!;
    }
}
