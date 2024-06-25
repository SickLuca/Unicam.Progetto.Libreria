using FluentValidation;
using System.Text.RegularExpressions;
using Unicam.Progetto.Libreria.Application.Extensions;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Il campo username è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
        }
    }
}
