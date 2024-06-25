using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;
using Unicam.Progetto.Libreria.Application.Services;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Web.Controllers
{
    //controller che restituisce le api
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibriController : ControllerBase
    {

        //inietto LibroService tramite il costruttore, iniezione dei servizi e logiche di business
        private readonly ILibroService _libroService;

        public LibriController(ILibroService libroService)
        {
            _libroService = libroService;
        }
        //dopo iniezione servizi necessari
        //creazione end-point

        [HttpGet]
        [Route("list")] //route eredita dalla rotta che abbiamo impostato a livello di classe
        public IEnumerable<Libro> GetLibri()
        {
            return null;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        //id lo prendiamo o dalla url o dal body
        public Libro GetLibro(int id)
        {
            return null ;
        }


        [HttpPost]
        [Route("new")]
        public IActionResult CreateLibro(CreateLibroRequest request)
        {
            //createlibrorequest dobbiamo trasformarlo in un oggetto di tipo libro, lo facciamo con un metodo nella classe dto che restituisce un ToEntity()
            var libro = request.ToEntity();
            //dobbiamo restituire, per fare questo abbiamo la necessita di andare a persistere questo determinato oggetto all interno del database.
            //uso le repository che ho implementato
            _libroService.AddLibro(libro, request.CategorieIds);//Questo andrà mappato in qualche modo da un dto
            //ora ho il libro
            var response = new CreateLibroResponse();
            response.Libro = new Application.Models.Dtos.LibroDto(libro);
            return Ok(response);
        }
        //model binding automatico
        //esponendo una web api non dovremmo mai esporre le entità //public IActionResult CreateLibro([FromBody] Libro newLibro)
        //di norma, non si fa mai binding su un oggetto del dominio/modello, ma su una classe intermedia che serve per mappare la richiesta che viene effettuata

        //queste classi si chiamano dto, data transfer oject, che servono per trasferire un oggetto da una posizone a ad una b
        //Creiamo quanti dto vogliamo e specifichiamo al loro interno i parametri, e una volta validato il dto abbiamo opportunità di trasformare quest oggetto in un oggetto tale per cui possiamo effettuare le operazioni all interno del nostro dominio
        
        //creiamo uno strato che sara il modello delle nostre web api, quello strato che esponiamo all utente, strato che poi viene mappato al modello che effettivamente abbiamo noi all'interno della nostra app
        //ESEMPIO, mi serve un dto che gestisca la richiesta della creazione di un nuovo libro
        
    }
}
