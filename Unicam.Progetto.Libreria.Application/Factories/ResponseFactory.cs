using Unicam.Progetto.Libreria.Application.Models.Responses;

namespace Unicam.Progetto.Libreria.Application.Factories
{
    /// <summary>
    /// Classe factory per creare oggetti di tipo BaseResponse<T>.
    /// </summary>
    public class ResponseFactory
    {

        /// <summary>
        /// Crea una risposta di successo con il risultato specificato.
        /// </summary>
        /// <typeparam name="T">Il tipo del risultato.</typeparam>
        /// <param name="result">Il risultato da includere nella risposta.</param>
        /// <returns>Una risposta di successo contenente il risultato.</returns>
        public static BaseResponse<T> WithSuccess<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }


        /// <summary>
        /// Crea una risposta di errore con il risultato specificato.
        /// </summary>
        /// <typeparam name="T">Il tipo del risultato.</typeparam>
        /// <param name="result">Il risultato da includere nella risposta.</param>
        /// <returns>Una risposta di errore contenente il risultato.</returns>
        public static BaseResponse<T> WithError<T>(T result)
        {
            var response = new BaseResponse<T>();
            response.Success = false;
            response.Result = result;
            return response;
        }


        /// <summary>
        /// Crea una risposta di errore con un messaggio di eccezione.
        /// </summary>
        /// <param name="exception">L'eccezione da cui estrarre il messaggio di errore.</param>
        /// <returns>Una risposta di errore contenente il messaggio dell'eccezione.</returns>
        public static BaseResponse<string?> WithError(Exception exception)
        {
            var response = new BaseResponse<string>();
            response.Success = false;
            response.Errors = new List<string>()
            {
                exception.Message
            };
            return response;
        }

    }
}
