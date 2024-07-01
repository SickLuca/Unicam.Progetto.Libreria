using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{

    /// <summary>
    /// Validator per la richiesta di cancellazione di un libro.
    /// </summary>
    public class CreateDeleteLibroRequestValidator : AbstractValidator<CreateDeleteLibroRequest>
    {
        public CreateDeleteLibroRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Il campo id è obbligatorio")
                .NotNull()
                .WithMessage("Il campo id non può essere nullo");
        }
    }
}
