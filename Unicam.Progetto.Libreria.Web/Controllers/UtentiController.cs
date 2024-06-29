using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Factories;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;

namespace Unicam.Progetto.Libreria.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtentiController : ControllerBase
    { 

    private readonly IUtenteService _utenteService;

    public UtentiController(IUtenteService utenteService)
    {
        _utenteService = utenteService;
    }

    [HttpPost]
    [Route("new")]
    public IActionResult CreateUtente(CreateUtenteRequest request)
    {
        //createlibrorequest dobbiamo trasformarlo in un oggetto di tipo libro, lo facciamo con un metodo nella classe dto che restituisce un ToEntity()
        var utente = request.ToEntity();
        //dobbiamo restituire, per fare questo abbiamo la necessita di andare a persistere questo determinato oggetto all interno del database.
        //uso le repository che ho implementato
        _utenteService.AddUtente(utente);//Questo andrà mappato in qualche modo da un dto
                                                  //ora ho il libro
        var response = new CreateUtenteResponse();
        response.Utente = new Application.Models.Dtos.UtenteDto(utente);
        return Ok(
            ResponseFactory.WithSuccess(response));
    }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(CreateLoginRequest request)
        {
            var token = _utenteService.Login(request.Email, request.Password);
            if (token != null)
            {
                return Ok(ResponseFactory.WithSuccess(new CreateLoginResponse(token)));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
