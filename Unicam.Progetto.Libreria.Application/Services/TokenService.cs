using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Application.Models.Requests;
using Unicam.Progetto.Libreria.Application.Options;

namespace Unicam.Progetto.Libreria.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption )
        {
            _jwtAuthOption = jwtAuthOption.Value;
        }

        public string CreateToken(CreateTokenRequest request)
        {

            //Step 1: Verificare esattezza username/password
            //TODO: Effettuare la verifica
            //Step 2: Se us/pass sono corrette, creo il token con le claims
            //TODO : Prendere i parametri dalla configurazione
            //TODO : Prendere le claims dal database
           
            //Simulo
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", "Luca"));
            claims.Add(new Claim("Cognome", "Repupilli"));
            //chiave simmetrica
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key)
                );
            //ora che ho la chiave posso fare le credenziali di firma
            var credentials = new SigningCredentials(securityKey
                , SecurityAlgorithms.HmacSha256);

            //
            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer
                , null
                , claims
                , expires: DateTime.Now.AddMinutes(30)
                , signingCredentials: credentials
                );
            //o chiave simmetrica (condivisa), o asimmetrica, noi la facciamo simmetrica

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            //Step 3: Restituisco il token
            return token;

        }
    }
}
