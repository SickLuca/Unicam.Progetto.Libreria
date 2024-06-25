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
    public class CategorieController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategorieController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost]
        [Route("new")]
        public IActionResult CreateCategoria(CreateCategoriaRequest request)
        {
            //createlibrorequest dobbiamo trasformarlo in un oggetto di tipo libro, lo facciamo con un metodo nella classe dto che restituisce un ToEntity()
            var categoria = request.toEntity();
            //dobbiamo restituire, per fare questo abbiamo la necessita di andare a persistere questo determinato oggetto all interno del database.
            //uso le repository che ho implementato
            _categoriaService.AddCategoria(categoria);//Questo andrà mappato in qualche modo da un dto
            //ora ho il libro
            var response = new CreateCategoriaResponse();
            response.Categoria = new Application.Models.Dtos.CategoriaDto(categoria);
            return Ok(
                ResponseFactory.WithSucces(response));
        }
    }
}
