using Unicam.Progetto.Libreria.Application.Models.Dtos;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta la risposta per la creazione di una nuovo libro.
    /// </summary>
    public class CreateLibroResponse
    { 

        public LibroDto Libro { get; set; } = null!;

    }
}
