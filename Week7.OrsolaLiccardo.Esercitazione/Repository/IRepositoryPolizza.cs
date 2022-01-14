using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Repository
{
    internal interface IRepositoryPolizza : IRepository<Polizza>
    {
        public Polizza? GetByNumero(int numero);
        public Polizza? GetByAll(int numero);
        
    }
}
