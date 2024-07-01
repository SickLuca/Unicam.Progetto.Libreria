using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{

    /// <summary>
    /// Validator per la richiesta di cancellazione di una categoria.
    /// </summary>
    public class CreateDeleteCategoriaRequestValidator : AbstractValidator<CreateDeleteCategoriaRequest>
    {
        public CreateDeleteCategoriaRequestValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio")
                .NotNull()
                .WithMessage("Il campo nome non può essere nullo");
        }
    }
}
