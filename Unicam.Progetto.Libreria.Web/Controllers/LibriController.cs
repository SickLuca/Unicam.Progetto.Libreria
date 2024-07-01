using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Factories;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Models.Responses;
using Unicam.Progetto.Libreria.Application.Services;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Web.Controllers
{

    /// <summary>
    /// Controller per gestire le operazioni relative ai libri tramite API.
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LibriController : ControllerBase
    {

        private readonly ILibroService _libroService;

        public LibriController(ILibroService libroService)
        {
            _libroService = libroService;
        }


        /// <summary>
        /// Endpoint per ottenere una lista paginata di libri con filtri opzionali.
        /// </summary>
        /// <param name="request">La richiesta di ottenere i libri paginati con filtri opzionali.</param>
        /// <returns>Un'azione di risultato con la lista paginata dei libri.</returns>
        [HttpPost]
        [Route("list")] 
        public IActionResult GetLibri(CreateGetLibriRequest request)
        {
            // Ottieni i libri paginati e filtrati dal servizio dei libri
            int totalNum = 0;
            var libri = _libroService.GetLibri(request.PageNumber * request.PageSize, request.PageSize, request.Name, request.Author, request.PublicationDate, request.Editor, request.CategoryName, out totalNum);

            // Prepara la risposta da restituire
            var response = new GetLibriResponse();

            // Calcola il numero totale di pagine in base alla dimensione della paginae
            var pageFounded = (totalNum / (decimal)request.PageSize);
            response.NumeroPagine = (int)Math.Ceiling(pageFounded);

            // Mappa i libri nel formato DTO per la risposta
            response.Libri = libri.Select(s =>
            new Application.Models.Dtos.LibroDto(s)).ToList();

            // Restituisci una risposta con successo includendo i libri e le informazioni sulla paginazione
            return Ok(ResponseFactory
              .WithSuccess(response)
              );
        }


        /// <summary>
        /// Endpoint per creare un nuovo libro.
        /// </summary>
        /// <param name="request">La richiesta di creare un nuovo libro.</param>
        /// <returns>Un'azione di risultato con lo stato della creazione del libro.</returns>
        [HttpPost]
        [Route("new")]
        public IActionResult CreateLibro(CreateLibroRequest request)
        {
            // Converti la richiesta in un'entità di libro
            var libro = request.ToEntity();

            // Aggiungi il libro usando il servizio dei libri
            _libroService.AddLibro(libro, request.CategorieIds);

            // Prepara la risposta di creazione da restituire
            var response = new CreateLibroResponse();
            response.Libro = new Application.Models.Dtos.LibroDto(libro);

            // Restituisci una risposta con successo includendo i dettagli del libro creato
            return Ok(
                ResponseFactory.WithSuccess(response));
        }



        /// <summary>
        /// Endpoint per rimuovere un libro esistente.
        /// </summary>
        /// <param name="deleteLibroRequest">La richiesta di rimuovere un libro.</param>
        /// <returns>Un'azione di risultato con lo stato della rimozione del libro.</returns>
        [HttpDelete]
        [Route("remove")]
        public IActionResult RemoveLibro(CreateDeleteLibroRequest deleteLibroRequest)
        {
            // Rimuovi il libro usando il servizio dei libri
            if (_libroService.RemoveLibro(deleteLibroRequest.Id))
            {
                // Restituisci una risposta di successo se il libro è stato rimosso con successo
                return Ok();
            }
            else
            {
                // Restituisci un errore se il libro non può essere rimosso
                return BadRequest();
            }
        }



        /// <summary>
        /// Endpoint per aggiornare le informazioni di un libro esistente.
        /// </summary>
        /// <param name="updateLibroRequest">La richiesta di aggiornare le informazioni di un libro.</param>
        /// <returns>Un'azione di risultato con lo stato dell'aggiornamento del libro.</returns>
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateLibro(CreateUpdateLibroRequest updateLibroRequest)
        {
            // Aggiorna il libro usando il servizio dei libri
            if (_libroService.UpdateLibro(updateLibroRequest.Id, updateLibroRequest.Nome, updateLibroRequest.Autore, updateLibroRequest.Editore, updateLibroRequest.DataPubblicazione, updateLibroRequest.CategorieIds))
            {
                // Restituisci una risposta di successo se il libro è stato modificato con successo
                return Ok();
            }
            else
            {
                // Restituisci un errore se il libro non può essere modificato
                return BadRequest();
            }
        }

    }

    //model binding automatico
    //esponendo una web api non dovremmo mai esporre le entità //public IActionResult CreateLibro([FromBody] Libro newLibro)
    //di norma, non si fa mai binding su un oggetto del dominio/modello, ma su una classe intermedia che serve per mappare la richiesta che viene effettuata

    //queste classi si chiamano dto, data transfer oject, che servono per trasferire un oggetto da una posizone a ad una b
    //Creiamo quanti dto vogliamo e specifichiamo al loro interno i parametri, e una volta validato il dto abbiamo opportunità di trasformare quest oggetto in un oggetto tale per cui possiamo effettuare le operazioni all interno del nostro dominio

    //creiamo uno strato che sara il modello delle nostre web api, quello strato che esponiamo all utente, strato che poi viene mappato al modello che effettivamente abbiamo noi all'interno della nostra app
    //ESEMPIO, mi serve un dto che gestisca la richiesta della creazione di un nuovo libro
}
