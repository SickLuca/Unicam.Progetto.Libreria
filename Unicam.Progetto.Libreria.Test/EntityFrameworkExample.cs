using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Abstractions;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Context;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Test
{
    public class EntityFrameworkExample : IExample
    {
        public void RunExample()
        {

            //as no tracking dovrebbe risolvere il problema di di sotto, se la query non la voglio tracciare ma la voglio fare e basta
            var ctx = new MyDbContext();
            var libri = ctx.Libri.AsNoTracking().ToList();
            QueryDiFiltro(ctx);
            AddLibro(ctx);
            AddCategoria(ctx);
            AddRelazione(ctx);
            //EditLibroCompleto(ctx);
            //EditProprietaLibro(ctx);
            //UpdateConLettura(ctx);
            //CORREGGERE!
            //LoadWithEagerLoading(ctx);
            LoadWithLazyLoading(ctx);
        }

        //il contesto glielo iniettiamo
        private void QueryDiFiltro(MyDbContext ctx)
        {
            //libri che iniziano con C
            var libriConCSintsassiSqlLite = from a in ctx.Libri
                                            where a.Nome.StartsWith("C")
                                            select a;

            //di norma questa è piu intuitiva
            var libriConCSintassiFluida = ctx.Libri
                .Where(w => w.Nome.StartsWith("C"));

            foreach (var libro in libriConCSintassiFluida)
            {
                Console.WriteLine(libro);
            }
        }


        private void AddLibro(MyDbContext ctx)
        {
            var newLibro = new Libro();
            newLibro.Nome = "La fattoria degli animali";
            newLibro.Autore = "George Orwell";
            newLibro.DataPubblicazione = DateTime.Now;
            newLibro.Editore = "Garzanti";

            ctx.Libri.Add(newLibro);

            ctx.SaveChanges();
        }

        //dobbiamo passare sempre la totalità dell'oggetto, altrimenti lui mette null sui campi inutilizzati
        private void EditLibroCompleto (MyDbContext ctx)
        {
            var editLibro = new Libro();
            editLibro.LibroId = 1;
            editLibro.Nome = "L'amico ritrovato";
            editLibro.Autore = "Fred Uhlman";
            editLibro.DataPubblicazione = DateTime.Now;
            editLibro.Editore = "Zanichelli";

            //dico che l'entità è stata modificata
            ctx.Entry(editLibro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ctx.SaveChanges();
        }


        private void EditProprietaLibro (MyDbContext ctx)
        {
            var editLibro = new Libro();
            editLibro.LibroId = 2;
            editLibro.Nome = "Una vita come tante";
            editLibro.Autore = "Hanya Yanagihara";

            var entry = ctx.Entry(editLibro);
            entry.Property(p => p.Nome).IsModified = true;
            entry.Property(p => p.Autore).IsModified = true;

            ctx.SaveChanges();
        }


        private void deleteLibro (MyDbContext ctx)
        {
            var deleteLibro = new Libro();
            deleteLibro.LibroId = 3;
            var entry = ctx.Entry(deleteLibro);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            ctx.SaveChanges();

        }

        private void UpdateConLettura(MyDbContext ctx)
        {
            var libro = ctx.Libri.Where(w => w.LibroId == 1001).FirstOrDefault();
            libro.Editore = "Zanichelli";
            ctx.SaveChanges();
        }

        private void AddCategoria(MyDbContext ctx)
        {
            var newCategoria = new Categoria();
            newCategoria.NomeCategoria = "Avventura";

            ctx.Categorie.Add(newCategoria);

            ctx.SaveChanges();
        }


        private void AddRelazione(MyDbContext ctx)
        {
            var newRelazione = new LibriCategorie();
            newRelazione.LibroId = 3;
            newRelazione.CategoriaId = 1;

            ctx.Relazioni.Add(newRelazione);

            ctx.SaveChanges();
        }
        //EF gestisce automaticamente anche le entità correlate

        //


        //questo si fa perche le prop di navigazione altrimenti non vengono caricate di default
        public void LoadWithEagerLoading (MyDbContext ctx)
        {
            var libro = ctx.Libri
                .Include(w => w.CategorieDelLibro)
                //query
                .Where(p => p.LibroId == 1).First();
        }

        //per lazy loading devo marcare prop di navigazione con virtual
        public void LoadWithLazyLoading(MyDbContext ctx)
        {
            var libro = ctx.Libri
                .Where(w => w.LibroId == 1).First();

            var nome = libro.CategorieDelLibro.First().CategoriaJoin;

        }

    }
}
