namespace Unicam.Progetto.Libreria.Application.Models.Responses
{
    public class CreateLoginResponse
    {
        public string Token { get; set; }
        public CreateLoginResponse(string token)
        {
            Token = token;
        }
    }
}
