using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;
namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    //utilizzato e invocato ogni volta che viene effettuato un binding su createLibroRequest
    public class CreateLibroRequestValidator : AbstractValidator<CreateLibroRequest> 
    {
        public CreateLibroRequestValidator() 
        {
            RuleFor(m => m.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio");
            //vediamo una custom
            RuleFor(m => m.Autore)
                .Custom(ValidaAutore);
        }

        private void ValidaAutore(string value, ValidationContext<CreateLibroRequest> context)
        {
            if (value == null)
            {
                context.AddFailure("Il campo Autore è obbligatorio");
            }
        }
    }
}
