using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Application.Services
{

    /// <summary>
    /// Servizio per la gestione delle operazioni sulle categorie.
    /// </summary>
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;


        /// <summary>
        /// Inizializza una nuova istanza della classe <see cref="CategoriaService"/>.
        /// </summary>
        /// <param name="categoriaRepository">Il repository delle categorie.</param>
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }



        /// <summary>
        /// Aggiunge una nuova categoria se non esiste già una categoria con lo stesso nome.
        /// </summary>
        /// <param name="categoria">La categoria da aggiungere.</param>
        /// <returns>true se la categoria è stata aggiunta con successo, false se una categoria con lo stesso nome esiste già.</returns>
        public bool AddCategoria(Categoria categoria)
        {
            if (_categoriaRepository.GetByNome(categoria.NomeCategoria) != null)
            {
                return false;
            }
            _categoriaRepository.Aggiungi(categoria);
            _categoriaRepository.Save();
            return true;
        }


        /// <summary>
        /// Rimuove una categoria se esiste e non ha libri associati.
        /// </summary>
        /// <param name="nome">Il nome della categoria da rimuovere.</param>
        /// <returns>true se la categoria è stata rimossa con successo, false se la categoria non esiste o ha libri associati.</returns>
        public bool RemoveCategoria(string nome)
        {
            Categoria categoria = _categoriaRepository.GetByNome(nome);
            //controlla che non ci siano libri associati alla categoria e che la categoria esista
            if (categoria != null && !categoria.LibriDellaCategoria.Any())
            {
                _categoriaRepository.Elimina(categoria.CategoriaId);
                _categoriaRepository.Save();
                return true;
            }
            return false;
        }
    }
}
