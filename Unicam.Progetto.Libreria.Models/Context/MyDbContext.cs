using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;


namespace Unicam.Progetto.Libreria.Models.Context
{
    public class MyDbContext : DbContext
    {
        
        public DbSet<Libro> Libri {  get; set; }

        public DbSet<Utente> Utenti { get; set; }

        public DbSet<Categoria> Categorie { get; set; }

        public DbSet<LibriCategorie> Relazioni { get; set; }

        /*Cosi facendo ho detto ad EF che voglio gestire queste entità per fare il mapping automatico */

        //deve sapere quale configurazioni deve leggere, lo facciamo overrideando il metodo onmodelcreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //e l'assembly lo prendo dall'assembly in cui si trova il contesto. Lui va nell'assembly Unicam.Progetto.Libreria.Models, vede quello
            //che implementa l'interfaccia IEntityTypeConfiguration e lo applica, ce le carica per noi
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        //ora manca il db provider, di cui dobbiamo far avvalere il contesto, altrimenti non saprebbe la modalita con la quale accede al db, noi vogliamo usare
        //sql server quindi aggiungiamo pacchetto nugat microsoft efcore sql
        //fatto questo comunque devo specificare a lui che voglio usare sql server, vedi efexample

        //cosi gli dico che ogni volta che viene creato un contesto, utilizziampo sql server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;Initial catalog=Libreria;User Id=progetto;Password=progetto");
        }
    }
}
