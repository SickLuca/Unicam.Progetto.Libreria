namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    public class CreateDeleteCategoriaRequest
    {
        public string Nome { get; set; }
        public CreateDeleteCategoriaRequest(string nome)
        {
            this.Nome = nome;
        }
    }
}
