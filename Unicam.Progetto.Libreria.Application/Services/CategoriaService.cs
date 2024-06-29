using Unicam.Progetto.Libreria.Application.Abstractions.Services;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly CategoriaRepository _categoriaRepository;
        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


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

        public bool RemoveCategoria(string nome)
        {
            Categoria categoria = _categoriaRepository.GetByNome(nome);
            if (categoria != null && !categoria.LibriDellaCategoria.Any())          //controlla che non ci siano libri associati alla categoria e che la categoria esista
            {
                _categoriaRepository.Elimina(categoria.CategoriaId);
                _categoriaRepository.Save();
                return true;
            }
            return false;
        }
    }
}
