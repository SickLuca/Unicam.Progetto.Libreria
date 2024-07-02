using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;

namespace Unicam.Progetto.Libreria.Models.Configurations
{
    /// <summary>
    /// Configurazione della mappatura dell'entità Categoria utilizzando Entity Framework Core.
    /// </summary>
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorie");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NomeCategoria)
                .HasMaxLength(100);
        }
    }
}
