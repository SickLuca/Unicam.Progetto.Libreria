namespace Unicam.Progetto.Libreria.Application.Options
{

    /// <summary>
    /// Opzioni di configurazione per l'autenticazione JWT.
    /// </summary>
    public class JwtAuthenticationOption
    {

        /// <summary>
        /// Ottiene o imposta la chiave segreta utilizzata per firmare i token JWT.
        /// </summary>
        public string Key { get; set; } = string.Empty;


        /// <summary>
        /// Ottiene o imposta l'emittente del token JWT.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;
    }
}
