using FluentValidation;
using System.Text.RegularExpressions;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    public static class ValidationExtensions
    {
        public static void RegEx<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string regex, string validationMessage)
        {
            ruleBuilder.Custom((value, context) =>
            {
                var regEx = new Regex(regex);
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    context.AddFailure(validationMessage);
                }
            });
            
        }
    }
}
