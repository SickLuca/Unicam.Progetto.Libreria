using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Options;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Application.Services
{

    /// <summary>
    /// Servizio per la gestione delle operazioni sugli utenti.
    /// </summary>
    public class UtenteService : IUtenteService
    {
        // Dipendenze iniettate per ottenere il repository degli utenti e le opzioni di autenticazione JWT
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthOption;


        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="UtenteService"/>.
        /// </summary>
        /// <param name="utenteRepository">Il repository degli utenti.</param>
        /// <param name="jwtAuthenticationOption">Le opzioni di autenticazione JWT.</param>
        public UtenteService(UtenteRepository utenteRepository, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
        {
            _utenteRepository = utenteRepository;
            _jwtAuthOption = jwtAuthenticationOption.Value;
        }


        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="utente">L'utente da aggiungere.</param>
        /// <returns>true se l'utente è stato aggiunto con successo, false se l'email esiste già.</returns>
        public bool AddUtente(Utente utente)
        {
            if (_utenteRepository.GetByEmail(utente.Email) != null)
            {
                return false;
            }
            _utenteRepository.Aggiungi(utente);
            _utenteRepository.Save();
            return true;
        }


        /// <summary>
        /// Effettua il login di un utente.
        /// </summary>
        /// <param name="mail">L'email dell'utente.</param>
        /// <param name="password">La password dell'utente.</param>
        /// <returns>Il token JWT se il login è riuscito, null altrimenti.</returns>
        public string Login(string mail, string password)
        {
            if (_utenteRepository.checkMailPassword(mail, password))
            {
                return GenerateJwtToken(_utenteRepository.GetByEmail(mail));
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Metodo privto per generare un token JWT per l'utente specificato.
        /// </summary>
        /// <param name="utente">L'utente per il quale generare il token.</param>
        /// <returns>Il token JWT generato.</returns>
        private string GenerateJwtToken(Utente utente)
        {
            // Crea una lista di claim (dichiarazioni) che rappresentano l'utente nel token JWT
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utente.Nome),    // Claim che rappresenta il nome dell'utente
                new Claim(ClaimTypes.Email, utente.Email),  // Claim che rappresenta l'email dell'utente
            };

            // Genera una chiave simmetrica utilizzando la chiave di autenticazione specificata nelle opzioni
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));

            // Crea le credenziali di firma utilizzando l'algoritmo HMAC-SHA256 e la chiave generata
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Crea il token JWT specificando l'emittente, i claim, la data di scadenza e le credenziali di firma
            var securtyyoken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,                      // Emittente del token
                null,                                       // Audience (destinatari) del token (null in questo caso)
                claims,                                     // Claim inclusi nel token
                expires: DateTime.Now.AddDays(30),          // Data di scadenza del token (30 giorni da ora)
                signingCredentials: creds                   // Credenziali di firma del token
                );

            // Scrive il token JWT in una stringa e la restituisce
            return new JwtSecurityTokenHandler().WriteToken(securtyyoken);
        }
    }

}

