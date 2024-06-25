namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class GetLibroRequest
    {
        public int PageSize { get; set; } //Rappresenta la grandezza della pagina
        public int PageNumber { get; set; } //Identifica il numero della pagina ad indice 0

        public string? Name { get; set; }

        public string? Author { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string? Editor { get; set; }
        public string? CategoryName { get; set; }

    }
}
