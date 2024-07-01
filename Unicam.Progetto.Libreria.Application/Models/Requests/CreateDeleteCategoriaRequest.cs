namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la cancellazione di una categoria.
    /// </summary>
    public class CreateDeleteCategoriaRequest
    {
        public string Nome { get; set; }
        public CreateDeleteCategoriaRequest(string nome)
        {
            this.Nome = nome;
        }
    }
}
