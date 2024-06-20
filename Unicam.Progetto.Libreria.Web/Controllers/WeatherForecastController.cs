using Microsoft.AspNetCore.Mvc;

namespace Unicam.Progetto.Libreria.Web.Controllers
{
    //specifica che ad ogni singola chiamata restituisce un oggetto http
    [ApiController]
    //ci dice che deve rispondere su una determinata url, con "[controller]" indica il nome del controller, posso inserirlo come voglio
    [Route("[controller]")]
    //dopodiche tutti i metodi pubblici qua sotto sono invocabili
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //post (invia info) (come quando metti username e password), delete, put (fatte su una url con un payload)
        //queste chiamate hanno un payload, ovvero un insieme di informazioni che vogliamo passare al server

        //post con payload 2 modalità:
        //-passando un json quando vuole invocare una web api
        //-url encoded -> dentro la payload metto una serie di coppie k,v di quello che dobbiamo inviare (es. usern, pass)
        //get (fatta su una url e basta) prende informazioni
        
        
        /*Di solito quando esponiamo una web api usiamo uno stile di progettazione che si chiama REST
        - Permette di sviluppare le richieste http
        se io voglio andare ad ottenre informazioni su un url faccio get
        se voglio inserire faccio post
        se voglio modificare faccio put
        se voglio cancellare faccio delete
        */


        /*
         * Una web api quindi è un progetto che ci facilita per la creazione di chiamate http rest styile, chiamate con dei verbi
         * che hanno json in ingresso e in uscita.
         * Cosi facendo permettiamo che sistemi distribuiti possono contattare il server centrale. 
         * Per lavorare in Rest utilizza i 4 verbi sopra citati.
         */

        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
