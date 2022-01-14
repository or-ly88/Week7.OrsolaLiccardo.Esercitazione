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
    internal class PolizzaConfiguration : IEntityTypeConfiguration<Polizza>
    {
        public void Configure(EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(k => k.numeroPolizza);
            builder.Property(n => n.numeroPolizza)
                   .IsFixedLength()
                   .IsRequired();
            builder.Property(d => d.dataStipula)
                   .HasColumnType("DateTime")
                   .IsRequired();
            builder.Property(i => i.importoAssicurato)
                   .HasColumnType("float")
                   .IsRequired();
            builder.Property(r => r.rataMensile)
                   .HasColumnType("float")
                   .IsRequired();

            builder.HasOne(c => c.Cliente).WithMany(p => p.Polizze).HasForeignKey(c => c.CodiceFiscale);

            //Ereditarietà
            builder.HasDiscriminator<string>("Type")
                .HasValue<RCAuto>("RCAuto")
                .HasValue<Furto>("Furto")
                .HasValue<Vita>("Vita");

        }

        
    }
}
