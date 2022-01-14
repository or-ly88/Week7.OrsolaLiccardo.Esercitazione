using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Repository
{
    public class ReposioryCliente : IRepositoryCliente
    {
        public bool Create(Cliente item)
        {
            using (var ctx = new Context())
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();

            }
            return true;

        }

        private static ICollection<Cliente> GetAll()
        {
            using (var ctx = new Context())
            {
                return ctx.Clienti.ToList();
            }
        }

        public Cliente? GetByCodice(string codiceFiscale)
        {
            return GetAll().FirstOrDefault(c => c.CodiceFiscale == codiceFiscale);
        }

        public Cliente GetByAll(int numero)
        {
            throw new NotImplementedException();
        }

        Cliente IRepository<Cliente>.Create(Cliente item)
        {
            throw new NotImplementedException();
        }

        ICollection<Cliente> IRepository<Cliente>.GetAll()
        {
            throw new NotImplementedException();
        }

        public Cliente? GetByNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public Polizza? GetByString(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
