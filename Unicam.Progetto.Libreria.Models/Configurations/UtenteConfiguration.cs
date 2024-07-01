using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Progetto.Libreria.Entities;
using Unicam.Progetto.Libreria.Models.Entities;

namespace Unicam.Progetto.Libreria.Models.Configurations
{
    /// <summary>
    /// Configurazione della mappatura dell'entità Utente utilizzando Entity Framework Core.
    /// </summary>
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {

        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(p => p.UtenteId);
            builder.Property(p => p.Email)
                .HasMaxLength(100);
            builder.Property(p => p.Nome)
                .HasMaxLength(100);
            builder.Property(p => p.Cognome)
                .HasMaxLength(100);
            builder.Property(p => p.Password)
                .HasMaxLength(100);
        }
    }
}
