using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;
namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    /// <summary>
    /// Validator per la creazione di un nuovo libro.
    /// </summary>
    public class CreateLibroRequestValidator : AbstractValidator<CreateLibroRequest> 
    {
        public CreateLibroRequestValidator() 
        {
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
