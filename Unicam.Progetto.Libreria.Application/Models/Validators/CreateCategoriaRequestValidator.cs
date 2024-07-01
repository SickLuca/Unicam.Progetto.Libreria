using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    /// <summary>
    /// Validator per la richiesta di creazione di una nuova categoria.
    /// </summary>
    public class CreateCategoriaRequestValidator : AbstractValidator<CreateCategoriaRequest>
    {
        public CreateCategoriaRequestValidator()
        {
            RuleFor(m => m.NomeCategoria)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio");
 
        }
    }
}
