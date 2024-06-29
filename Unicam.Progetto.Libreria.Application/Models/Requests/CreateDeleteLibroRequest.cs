namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class CreateDeleteLibroRequest
    {
        public int Id { get; set; }
        public CreateDeleteLibroRequest(int id)
        {
            this.Id = id;
        }
    }
}
