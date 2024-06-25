using Unicam.Progetto.Libreria.Application.Models.Dtos;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{
    public class GetLibriResponse
    {
        public List<LibroDto> Libri { get; set; } = new List<LibroDto>();
        public int NumeroPagine { get; set; }
    }
}
