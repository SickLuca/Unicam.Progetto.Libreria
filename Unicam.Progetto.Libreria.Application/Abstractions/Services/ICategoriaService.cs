﻿using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Application.Abstractions.Services
{
    public interface ICategoriaService
    {
        bool AddCategoria(Categoria categoria);
    }
}
