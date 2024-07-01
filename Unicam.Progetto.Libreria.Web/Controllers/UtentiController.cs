using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Factories;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;

namespace Unicam.Progetto.Libreria.Web.Controllers
{
    /// <summary>
    /// Controller per gestire le operazioni relative agli utenti tramite API.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UtentiController : ControllerBase
    { 

    private readonly IUtenteService _utenteService;

    public UtentiController(IUtenteService utenteService)
    {
        _utenteService = utenteService;
    }



    /// <summary>
    /// Endpoint per creare un nuovo utente.
    /// </summary>
    /// <param name="request">La richiesta di creare un nuovo utente.</param>
    /// <returns>Un'azione di risultato con lo stato della creazione dell'utente.</returns>
    [HttpPost]
    [Route("new")]
    public IActionResult CreateUtente(CreateUtenteRequest request)
    {
        // Converti la richiesta in un'entità di utente
        var utente = request.ToEntity();
        
        // Aggiungi l'utente usando il servizio degli utenti
        _utenteService.AddUtente(utente);

        // Prepara la risposta di creazione da restituire
        var response = new CreateUtenteResponse();
        response.Utente = new Application.Models.Dtos.UtenteDto(utente);

        // Restituisci una risposta con successo includendo i dettagli dell'utente creato
        return Ok(
            ResponseFactory.WithSuccess(response));
    }



        /// <summary>
        /// Endpoint per l'autenticazione dell'utente (login).
        /// </summary>
        /// <param name="request">La richiesta di login contenente email e password.</param>
        /// <returns>Un'azione di risultato con il token JWT se l'autenticazione ha successo, altrimenti Unauthorized.</returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(CreateLoginRequest request)
        {
            // Esegui il login usando il servizio degli utenti
            var token = _utenteService.Login(request.Email, request.Password);

            // Verifica se il login ha avuto successo
            if (token != null)
            {
                // Restituisci una risposta con successo includendo il token JWT
                return Ok(ResponseFactory.WithSuccess(new CreateLoginResponse(token)));
            }
            else
            {
                // Restituisci Unauthorized se il login non ha avuto successo
                return Unauthorized();
            }
        }
    }
}
