using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Factories;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;
using Unicam.Progetto.Libreria.Application.Services;

namespace Unicam.Progetto.Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TokenController : Controller
    {   
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }



        [HttpPost]
        [Route("create")]
        public IActionResult Create(CreateTokenRequest request)
        { 
            //STEP 0: Validazione della richiesta
            string token = _tokenService.CreateToken(request);
            //STEP 1: Verificare se username e password sono esatti

            //STEP 2: Se username/password corrette creo il token con le claims necessarie

            //STEP 3: Restituisco il token
            return Ok(ResponseFactory.WithSucces(
                    new CreateTokenResponse(token)
                    )
                );
        }
    }
}
