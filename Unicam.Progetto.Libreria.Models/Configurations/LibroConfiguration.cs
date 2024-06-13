using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Models.Entities;



namespace Unicam.Progetto.Libreria.Models.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libro");
            builder.HasKey(p => p.LibroId);
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.Property(p => p.Autore)
                .HasMaxLength(100);
            builder.Property(p => p.Editore)
                .HasMaxLength(100);
            
        }
    }
}



/*
 Implementando l'interfaccia IEntity.. sto dicendo che devo implementare un metodo configure attraverso il quale configuriamo il mapping
tra le tabelle del db e le entità dell'applicazione
 */
