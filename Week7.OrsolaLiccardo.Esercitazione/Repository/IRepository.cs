using Week7.OrsolaLiccardo.Esercitazione.Models;

namespace Week7.OrsolaLiccardo.Esercitazione.Repository
{
    public interface IRepository<T>
    {
        public T Create(T item);

        public ICollection<T> GetAll();
        Cliente? GetByNumero(int numero);
        Polizza? GetByString(int numero);
    }
}