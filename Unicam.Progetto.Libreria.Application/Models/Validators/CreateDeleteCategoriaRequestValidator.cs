using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
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
