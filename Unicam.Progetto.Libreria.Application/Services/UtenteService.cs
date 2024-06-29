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
    public class UtenteService : IUtenteService
    {
        private readonly UtenteRepository _utenteRepository;
        private readonly JwtAuthenticationOption _jwtAuthOption;

        public UtenteService(UtenteRepository utenteRepository, IOptions<JwtAuthenticationOption> jwtAuthenticationOption)
        {
            _utenteRepository = utenteRepository;
            _jwtAuthOption = jwtAuthenticationOption.Value;
        }

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
        private string GenerateJwtToken(Utente utente)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utente.Nome),
                new Claim(ClaimTypes.Email, utente.Email),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtAuthOption.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securtyyoken = new JwtSecurityToken(
                _jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddDays(90),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(securtyyoken);
        }
    }

}

