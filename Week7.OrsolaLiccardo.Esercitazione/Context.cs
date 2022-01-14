using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;
using Week7.OrsolaLiccardo.Esercitazione.Configuration;

namespace Week7.OrsolaLiccardo.Esercitazione
{
    internal class Context : DbContext
    {
     
        public DbSet<Cliente> Clienti { get; set; }
        public DbSet<Polizza> Polizze { get; set; }

        public Context() : base()
        { 
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AssicurazioneDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cliente
            modelBuilder  = modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
            //Polizza
            modelBuilder.ApplyConfiguration<Polizza>(new PolizzaConfiguration());
        }
    }
    
}
