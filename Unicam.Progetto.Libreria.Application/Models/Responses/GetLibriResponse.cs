using Unicam.Progetto.Libreria.Application.Models.Dtos;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta la risposta per la richiesta di restituzione di una lista i libri.
    /// </summary>
    public class GetLibriResponse
    {
        public List<LibroDto> Libri { get; set; } = new List<LibroDto>();
        public int NumeroPagine { get; set; }
    }
}
