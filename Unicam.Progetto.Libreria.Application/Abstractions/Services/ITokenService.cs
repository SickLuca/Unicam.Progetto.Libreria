using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    public interface ITokenService
    {

        string CreateToken(CreateTokenRequest request);

    }
}
