using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;



namespace Unicam.Progetto.Libreria.Models.Configurations
{
    /// <summary>
    /// Configurazione della mappatura dell'entità Libro utilizzando Entity Framework Core.
    /// </summary>
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("Libri");
            builder.HasKey(p => p.Id);
            
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.Property(p => p.Autore)
                .HasMaxLength(100);
            builder.Property(p => p.Editore)
                .HasMaxLength(100);

            //specifichiamo la relazione
            builder.HasMany(b => b.Categorie)
            .WithMany(c => c.Libri)
            .UsingEntity<Dictionary<string, object>>(
                "LibriCategorie",
                j => j
                    .HasOne<Categoria>()
                    .WithMany()
                    .HasForeignKey("CategorieId")
                    .OnDelete(DeleteBehavior.Restrict), // Non eliminare le categorie
                j => j
                    .HasOne<Libro>()
                    .WithMany()
                    .HasForeignKey("LibriId")
                    .OnDelete(DeleteBehavior.Cascade) // Elimina le associazioni quando un libro viene eliminato                                             
            );
          

        }
    }
}

/*
 Implementando l'interfaccia IEntity.. sto dicendo che devo implementare un metodo configure attraverso il quale configuriamo il mapping
tra le tabelle del db e le entità dell'applicazione
 */
