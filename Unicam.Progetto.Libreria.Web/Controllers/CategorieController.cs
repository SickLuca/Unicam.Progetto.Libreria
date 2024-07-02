using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Factories;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;
using Unicam.Progetto.Libreria.Application.Services;
using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Web.Controllers
{

    /// <summary>
    /// Controller per gestire le operazioni relative alle categorie tramite API.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategorieController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategorieController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }


        /// <summary>
        /// Endpoint per creare una nuova categoria.
        /// </summary>
        /// <param name="request">La richiesta di creazione della categoria.</param>
        /// <returns>Un'azione di risultato con lo stato della creazione.</returns>
        [HttpPost]
        [Route("new")]
        public IActionResult CreateCategoria(CreateCategoriaRequest request)
        {
            // Convertire la richiesta in un'entità di categoria
            var categoria = request.toEntity();

            // Aggiungere la categoria usando il servizio delle categorie
            if (_categoriaService.AddCategoria(categoria))
            {
                // Creare una risposta di successo con i dettagli della categoria creata
                var response = new CreateCategoriaResponse();
                response.Categoria = new Application.Models.Dtos.CategoriaDto(categoria);
                return Ok(
                    ResponseFactory.WithSuccess(response));
            }
            // Restituire un errore se la categoria esiste già
            else return BadRequest(
                    ResponseFactory.WithError("Questa categoria esiste già."));
            
        }


        /// <summary>
        /// Endpoint per rimuovere una categoria esistente.
        /// </summary>
        /// <param name="deleteCategoriaRequest">La richiesta di eliminazione della categoria.</param>
        /// <returns>Un'azione di risultato con lo stato della rimozione.</returns>
        [HttpDelete]
        [Route("remove")]
        public IActionResult RemoveCategoria(CreateDeleteCategoriaRequest deleteCategoriaRequest)
        {
            if (_categoriaService.RemoveCategoria(deleteCategoriaRequest.Nome))
            {
                return Ok();
            }
            return BadRequest("Alla categoria sono associati dei libri.");
        }
    }

}
