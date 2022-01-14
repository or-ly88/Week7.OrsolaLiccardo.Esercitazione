using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Repository
{
    internal class RepositoryPolizza :IRepositoryPolizza
    {
        public bool Create(Polizza item)
        {
            
            using (var ctx = new Context())
            {
                ctx.Polizze.Add(item);
                ctx.SaveChanges();

            }
            return true;

        }

        private static ICollection<Polizza> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Polizze.ToList();
            }
        }

        public Polizza? GetByNumero(int numero)
        {
            return GetAll().FirstOrDefault(n => n.numeroPolizza == numero);
        }

        public Polizza? GetByAll(int numero)
        {
            throw new NotImplementedException();
        }

        Polizza IRepository<Polizza>.Create(Polizza item)
        {
            throw new NotImplementedException();
        }

        ICollection<Polizza> IRepository<Polizza>.GetAll()
        {
            throw new NotImplementedException();
        }

        Cliente? IRepository<Polizza>.GetByNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public Polizza? GetByString(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
