using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            var categoria = request.toEntity();
           

            if (_categoriaService.AddCategoria(categoria))
            {
                var response = new CreateCategoriaResponse();
                response.Categoria = new Application.Models.Dtos.CategoriaDto(categoria);
                return Ok(
                    ResponseFactory.WithSuccess(response));
            }
            else
            {
                var response = new CreateCategoriaResponse();
                response.Categoria = new Application.Models.Dtos.CategoriaDto(categoria);
                return Ok(
                    ResponseFactory.WithError("Questa categoria esiste già."));
            }
        }
    }
}

