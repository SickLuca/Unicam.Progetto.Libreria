using FluentValidation;
using System.Text.RegularExpressions;

namespace Unicam.Progetto.Libreria.Application.Extensions
{
    /// <summary>
    /// Classe d'estenzione per l'utilizzo di un espressione regolare, verrà utilizzata nell'autenticazione
    /// dell'utente. Utilizza FluentValidation.
    /// </summary>
    public static class ValidationExtensions
    {
        // <summary>
        /// Aggiunge una regola di validazione per verificare se una proprietà soddisfa un'espressione regolare specificata.
        /// </summary>
        /// <typeparam name="T">Il tipo dell'oggetto da validare.</typeparam>
        /// <typeparam name="TProperty">Il tipo della proprietà da validare.</typeparam>
        /// <param name="ruleBuilder">Il costruttore di regole di FluentValidation.</param>
        /// <param name="regex">L'espressione regolare da utilizzare per la validazione.</param>
        /// <param name="validationMessage">Il messaggio di validazione da visualizzare in caso di errore.</param>
        public static void RegEx<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string regex, string validationMessage)
        {
            // Aggiunge una regola personalizzata al costruttore di regole.
            ruleBuilder.Custom((value, context) =>
            {
                // Crea un'istanza di Regex utilizzando l'espressione regolare fornita.
                var regEx = new Regex(regex);
                // Verifica se il valore della proprietà corrisponde all'espressione regolare.
                if (regEx.IsMatch(value.ToString()) == false)
                {
                    // Se non corrisponde, aggiunge un errore di validazione con il messaggio fornito.
                    context.AddFailure(validationMessage);
                }
            });
            
        }
    }
}
