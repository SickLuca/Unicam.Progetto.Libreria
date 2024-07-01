using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;
namespace Unicam.Progetto.Libreria.Application.Models.Validators
{

    /// <summary>
    /// Validator per la richiesta di login da parte di un utente.
    /// </summary>
    public class CreateLoginRequestValidator : AbstractValidator<CreateLoginRequest>
    {
        public CreateLoginRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio")
                .NotNull()
                .WithMessage("Il campo email non può essere nullo");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(3)
                .WithMessage("Il campo password deve essere almeno lungo 3 caratteri");
        }
    }
}
