using FluentValidation;
using Unicam.Progetto.Libreria.Application.Models.Requests;
namespace Unicam.Progetto.Libreria.Application.Models.Validators
{
    public class CreateGetLibriRequestValidator : AbstractValidator<CreateGetLibriRequest>
    {
        public CreateGetLibriRequestValidator()
        {
            RuleFor(x => x.PageSize)
                 .GreaterThan(0)
                 .WithMessage("Il campo size deve essere maggiore di 0");
            RuleFor(x => x.PageNumber)
                 .GreaterThanOrEqualTo(0)
                 .WithMessage("Il campo from deve essere superiore o uguale a 0");
            RuleFor(x => x)
                 .Must(x => atLeastOne(x))
                 .WithMessage("Almeno un campo deve essere non nullo");
        }
        private bool atLeastOne(CreateGetLibriRequest request)
        {
            return !String.IsNullOrEmpty(request.CategoryName) || !String.IsNullOrEmpty(request.Name) || !String.IsNullOrEmpty(request.Author) || request.PublicationDate != null;
        }
    }
}
