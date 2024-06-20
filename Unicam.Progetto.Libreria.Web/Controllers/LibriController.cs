using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Web.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class LibriController : ControllerBase
    {

        List<Libro> libri = new List<Libro>();

        public LibriController()
        {
            libri.Add(new Libro()
            {
                Autore = "Alessandro Baricco",
                Nome = "Novecento",
                DataPubblicazione = DateTime.Now,
                Editore = "Zanichelli"
            });
        }


        [HttpGet]
        [Route("list")]
        public IEnumerable<Libro> GetLibri()
        {
            return libri;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        //id lo prendiamo o dalla url o dal body
        public Libro GetLibro(int id)
        {
            return libri.Where(w => w.LibroId == id).First();
        }


        [HttpPost]
        [Route("new")]
        public IActionResult CreateLibro(CreateLibroRequest request)
        {
            //createlibrorequest dobbiamo trasformarlo in un oggetto di tipo libro, lo facciamo con un metodo nella classe dto che restituisce un ToEntity()
            var libro = request.ToEntity();
            //dobbiamo restituire, per fare questo abbiamo la necessita di andare a persistere questo determinato oggetto all interno del database.
            return Ok();
        }
        //esponendo una web api non dovremmo mai esporre le entità //public IActionResult CreateLibro([FromBody] Libro newLibro)
        //di norma, non si fa mai binding su un oggetto del dominio/modello, ma su una classe intermedia che serve per mappare la richiesta che viene effettuata

        //queste classi si chiamano dto, data transfer oject, che servono per trasferire un oggetto da una posizone a ad una b
        //Creiamo quanti dto vogliamo e specifichiamo al loro interno i parametri, e una volta validato il dto abbiamo opportunità di trasformare quest oggetto in un oggetto tale per cui possiamo effettuare le operazioni all interno del nostro dominio
        
        //creiamo uno strato che sara il modello delle nostre web api, quello strato che esponiamo all utente, strato che poi viene mappato al modello che effettivamente abbiamo noi all'interno della nostra app
        //ESEMPIO, mi serve un dto che gestisca la richiesta della creazione di un nuovo libro
        
    }
}
