using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Unicam.Progetto.Libreria.Application.Options;
using Unicam.Progetto.Libreria.Web.Results;

namespace Unicam.Progetto.Libreria.Web.Extensions
{

    /// <summary>
    /// Classe statica che fornisce metodi di estensione per configurare i servizi web dell'applicazione.
    /// </summary>
    public static class ServiceExtension
    {

        /// <summary>
        /// Configura i servizi web per l'applicazione, inclusi controller, Swagger, autenticazione JWT e validazione.
        /// </summary>
        /// <param name="services">L'istanza di <see cref="IServiceCollection"/> per aggiungere i servizi.</param>
        /// <param name="configuration">L'istanza di <see cref="IConfiguration"/> per accedere alle impostazioni di configurazione.</param>
        /// <returns>Ritorna l'istanza di <see cref="IServiceCollection"/> con i servizi configurati.</returns>
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Aggiunge i controller all'applicazione e configura le opzioni di comportamento API.
            services.AddControllers()
                .ConfigureApiBehaviorOptions(opt => 
                {
                    opt.InvalidModelStateResponseFactory = (context) =>
                    {
                        return new BadRequestResultFactory(context);
                    };
                    
                });
            // Aggiunge l'esploratore degli endpoint API.
            services.AddEndpointsApiExplorer();

            // Configura Swagger per la documentazione dell'API.
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Unicam Paradigmi Test App",
                    Version = "v1"
                });
                // Aggiunge la definizione di sicurezza per JWT.
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                // Aggiunge il requisito di sicurezza per JWT.
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });
            // Aggiunge la validazione automatica con FluentValidation.
            services.AddFluentValidationAutoValidation();

            // Configura le opzioni di autenticazione JWT leggendo i valori da appsettings.
            var jwtAuthenticationOption = new JwtAuthenticationOption();
            configuration.GetSection("JwtAuthentication")
                .Bind(jwtAuthenticationOption);

            // Configura l'autenticazione con schema JWT.
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(options =>
    {
        string key = jwtAuthenticationOption.Key;
        // Crea una chiave di sicurezza simmetrica
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
            );

        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtAuthenticationOption.Issuer,
            IssuerSigningKey = securityKey

        };
    });
            // Configura le opzioni di autenticazione JWT.
            services.Configure<JwtAuthenticationOption>(
                configuration.GetSection("JwtAuthentication")
    );


            return services;
        }
    }
}
