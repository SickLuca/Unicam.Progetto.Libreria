using FluentValidation;
using Unicam.Progetto.Libreria.Application.Extensions;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        public CreateUtenteRequestValidator()
        {
            RuleFor(m => m.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio");

            RuleFor(m => m.Cognome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo cognome è obbligatorio");

            RuleFor(m => m.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio");

            RuleFor(m => m.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo Password è obbligatorio")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale");
        }
    }
}
