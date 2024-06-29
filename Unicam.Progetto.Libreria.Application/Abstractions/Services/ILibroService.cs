using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    public interface ILibroService
    {
        List<Libro> GetLibri();
        List<Libro> GetLibri(int from, int num, string? name, string? author, DateTime? publicationDate, string? editor, string? categoryName, out int totalNum);

        void AddLibro(Libro libro, List<int> categorieIds);

        public bool RemoveLibro(int id);
    }

    
}
