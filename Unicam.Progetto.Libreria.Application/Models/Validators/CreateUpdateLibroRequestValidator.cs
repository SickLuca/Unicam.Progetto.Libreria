using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;

namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    public class CreateUpdateLibroRequestValidator : AbstractValidator<CreateUpdateLibroRequest>
    {
        public CreateUpdateLibroRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Il campo id è obbligatorio")
                .GreaterThan(0)
                .WithMessage("Il campo id deve essere positivo");
            RuleFor(x => x.Editore)
               .NotEmpty()
               .WithMessage("Il campo titolo è obbligatorio")
               .NotNull()
               .WithMessage("Il campo titolo non può essere nullo");
            RuleFor(x => x.Nome)
               .NotEmpty()
               .WithMessage("Il campo nome è obbligatorio")
               .NotNull()
               .WithMessage("Il campo nome non può essere nullo");
            RuleFor(x => x.Autore)
               .NotEmpty()
               .WithMessage("Il campo autore è obbligatorio")
               .NotNull()
               .WithMessage("Il campo autore non può essere nullo");
            RuleFor(x => x.DataPubblicazione)
               .NotEmpty()
               .WithMessage("Il campo data è obbligatorio")
               .NotNull()
               .WithMessage("Il campo data non può essere nullo");
        }
    }
}
