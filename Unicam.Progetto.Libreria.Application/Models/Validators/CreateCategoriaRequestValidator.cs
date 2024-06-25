using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
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
