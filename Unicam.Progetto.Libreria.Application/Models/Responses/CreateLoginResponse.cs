namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta la risposta per l'esecuzione di un login.
    /// </summary>
    public class CreateLoginResponse
    {
        public string Token { get; set; }
        public CreateLoginResponse(string token)
        {
            Token = token;
        }
    }
}
