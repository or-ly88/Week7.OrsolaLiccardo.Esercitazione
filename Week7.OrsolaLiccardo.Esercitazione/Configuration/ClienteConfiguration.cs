using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Configuration
{
    internal class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(k => k.CodiceFiscale);
            builder.Property(c => c.CodiceFiscale)
                   .HasMaxLength(16)
                   .IsFixedLength()
                   .IsRequired();
            builder.Property(n => n.Nome).IsRequired()
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(c => c.Cognome)
                   .HasMaxLength(20)
                   .IsRequired();
            builder.Property(i => i.Indirizzo)
                   .HasMaxLength(50)
                   .IsRequired();

           
            builder.HasMany(p => p.Polizze).WithOne(p => p.Cliente);
                   

        }


    }
}
