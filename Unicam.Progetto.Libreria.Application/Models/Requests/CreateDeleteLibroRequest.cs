namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la cancellazione di un libro.
    /// </summary>
    public class CreateDeleteLibroRequest
    {
        public int Id { get; set; }
        public CreateDeleteLibroRequest(int id)
        {
            this.Id = id;
        }
    }
}
