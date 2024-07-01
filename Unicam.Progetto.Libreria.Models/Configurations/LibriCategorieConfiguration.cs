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

    /// <summary>
    /// Configurazione della mappatura dell'entità LibriCategorie utilizzando Entity Framework Core.
    /// </summary>
    public class LibriCategorieConfiguration : IEntityTypeConfiguration<LibriCategorie>
    {
        public void Configure(EntityTypeBuilder<LibriCategorie> builder)
        {
            builder.ToTable("LibriCategorie");
            builder.HasKey(p => new { p.LibroId, p.CategoriaId });
            //relazione
            builder
                .HasOne(bc => bc.LibroJoin)
                .WithMany(b => b.CategorieDelLibro)
                .HasForeignKey(bc => bc.LibroId);

            builder
                .HasOne(bc => bc.CategoriaJoin)
                .WithMany(c => c.LibriDellaCategoria)
                .HasForeignKey(bc => bc.CategoriaId);
        }
    }
}
