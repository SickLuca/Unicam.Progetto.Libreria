﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;


namespace Unicam.Progetto.Libreria.Models.Context
{

    /// <summary>
    /// Classe di contesto per Entity Framework Core che gestisce l'accesso al database.
    /// </summary>
    public class MyDbContext : DbContext
    {

        /// <summary>
        /// Costruttore predefinito.
        /// </summary>
        public MyDbContext()
        { 
        }

        /// <summary>
        /// Costruttore che accetta le opzioni di configurazione del contesto.
        /// </summary>
        /// <param name="config">Le opzioni di configurazione del contesto.</param>
        public MyDbContext(DbContextOptions<MyDbContext> config)
        {

        }

        /// <summary>
        /// Set di entità che rappresentano i libri nel database.
        /// </summary>
        public DbSet<Libro> Libri {  get; set; }


        /// <summary>
        /// Set di entità che rappresentano gli utenti nel database.
        /// </summary>
        public DbSet<Utente> Utenti { get; set; }


        /// <summary>
        /// Set di entità che rappresentano le categorie nel database.
        /// </summary>
        public DbSet<Categoria> Categorie { get; set; }


        /// <summary>
        /// Set di entità che rappresentano le relazioni tra libri e categorie nel database.
        /// </summary>
        public DbSet<LibriCategorie> Relazioni { get; set; }


        /// <summary>
        /// Configura il modello durante la creazione del contesto.
        /// </summary>
        /// <param name="modelBuilder">Il costruttore del modello.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applica tutte le configurazioni definite nell'assembly corrente
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            // Chiama il metodo base per eseguire eventuali ulteriori configurazioni
            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// Configura le opzioni del contesto, inclusa la connessione al database e l'utilizzo dei proxy per il caricamento lazy.
        /// </summary>
        /// <param name="optionsBuilder">Il costruttore delle opzioni del contesto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // Abilita l'utilizzo dei proxy per il caricamento lazy
                .UseLazyLoadingProxies()
                // Configura l'uso di SQL Server con una stringa di connessione specificata
                .UseSqlServer("data source=(LocalDb)\\MSSQLLocalDB;Initial catalog=Libreria;User Id=progetto;Password=progetto");
        }
    }
}
