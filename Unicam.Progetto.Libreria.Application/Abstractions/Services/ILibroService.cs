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

        void AddLibro(Libro libro, List<int> categorieIds);
    }

    
}
