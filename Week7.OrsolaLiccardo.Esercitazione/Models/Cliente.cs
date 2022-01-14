using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.OrsolaLiccardo.Esercitazione.Models
{
    public class Cliente
    {
        
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }

        //Relazione uno a molti tra Cliente e Polizza (collection di polizza)
        public ICollection<Polizza> Polizze { get; set; } = new List<Polizza>();

    }
}
