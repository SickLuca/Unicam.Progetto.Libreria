using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Abstractions;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;
using Unicam.Progetto.Libreria.Models.Repositories;

namespace Unicam.Progetto.Libreria.Test
{
    public class RepositoryExample : IExample
    {
        public async Task RunExampleAsync()
        {

        }
        public void RunExample()
        {
            var ctx = new MyDbContext();
            var libroRepo = new LibroRepository(ctx);
            var categoriaRepo = new CategoriaRepository(ctx);
            var utenteRepo = new UtenteRepository(ctx);

            var libro = libroRepo.Ottieni(1);
            var categoria = categoriaRepo.Ottieni(1);
            libro.Nome = "nuovo";
            libroRepo.Modifica(libro);
            libroRepo.Save();

            var nuovaCategoria = new Categoria();
            nuovaCategoria.NomeCategoria = "Fiction";
            //nuovoDipendente.IdAzienda = 5;

            var nuovoUtente = new Utente();
            nuovoUtente.Nome = "Mario";
            nuovoUtente.Cognome = "Rossi";
            nuovoUtente.Email = "mario.rossi@gmail.com";
            nuovoUtente.Password= "Camerino";
           

            utenteRepo.Aggiungi(nuovoUtente);
            utenteRepo.Save();


        }


    }
}
