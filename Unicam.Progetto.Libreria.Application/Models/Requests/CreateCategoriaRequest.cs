using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Models.Requests
{
    /// <summary>
    /// Richiesta per la creazione di una nuova categoria.
    /// </summary>
    public class CreateCategoriaRequest
    {
        public string NomeCategoria { get; set; }


        /// <summary>
        /// Converte l'istanza di <see cref="CreateCategoriaRequest"/> in un'istanza di <see cref="Categoria"/>.
        /// </summary>
        /// <returns>Un'istanza di <see cref="Categoria"/> con i dati della richiesta.</returns>
        public Categoria toEntity()
        {
            Categoria categoria = new Categoria();
            categoria.NomeCategoria = NomeCategoria;
            return categoria;
        }

    }
}
