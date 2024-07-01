namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per l'esecuzione di un login.
    /// </summary>
    public class CreateLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
