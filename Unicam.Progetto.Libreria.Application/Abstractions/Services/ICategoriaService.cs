using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    /// <summary>
    /// Interfaccia implementata dall'entità Categoria al fine di esporre i servizi necessari alle web api.
    /// </summary>
    public interface ICategoriaService
    {
        /// <summary>
        /// Questo metodo verrà sfruttato per poter inserire una categoria al database.
        /// </summary>
        /// <param name="categoria"> L'oggetto Categoria che vogliamo passare </param>
        /// <returns>true se l'inserimento viene effettuato, false altrimenti</returns>
        bool AddCategoria(Categoria categoria);

        /// <summary>
        /// Questo metodo verrà sfruttato per poter rimuovere una categoria dal database.
        /// </summary>
        /// <param name="nome">Il nome della categoria che vogliamo rimuovere</param>
        /// <returns>true se la rimozione viene effettuata, false altrimenti</returns>
        public bool RemoveCategoria(string nome);
    }
}
