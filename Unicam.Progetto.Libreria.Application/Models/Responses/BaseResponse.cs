using System.Text.Json.Serialization;

namespace Unicam.Progetto.Libreria.Application.Models.Responses
{

    /// <summary>
    /// Rappresenta una risposta di base con un indicatore di successo, eventuali errori e un risultato generico.
    /// </summary>
    /// <typeparam name="T">Il tipo del risultato.</typeparam>
    public class BaseResponse<T>
    {
        // <summary>
        /// Ottiene o imposta un valore che indica se l'operazione è stata eseguita con successo.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Ottiene o imposta l'elenco degli errori verificatisi durante l'operazione.
        /// Viene ignorato durante la serializzazione se è null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; } = null;


        /// <summary>
        /// Ottiene o imposta il risultato dell'operazione.
        /// Viene ignorato durante la serializzazione se è null.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Result { get; set; } = default;


    }
}
