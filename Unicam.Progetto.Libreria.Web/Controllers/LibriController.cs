using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Libro> GetLibri ()
        {
            return libri;
        }

        [HttpGet]
        [Route("get/{id:int}")]
        //id lo prendiamo o dalla url o dal body
        public Libro GetLibro (int id)
        {
            return libri.Where(w => w.LibroId == id).First();
        }


        [HttpPost]
        [Route("new")]
        public  IActionResult CreateLibro (Libro newLibro)
        {
            return Ok();
        }
    }
}
