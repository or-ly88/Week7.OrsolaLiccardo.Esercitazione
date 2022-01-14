using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Cliente GetByAll(int numero);

    }
}
