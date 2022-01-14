using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.OrsolaLiccardo.Esercitazione.Models
{
    public class Polizza
    {
        
        public int numeroPolizza { get; set; }
        public DateTime dataStipula { get; set; }
        public float importoAssicurato { get; set; }
        public float rataMensile { get; set; }

        //relazione uno a molti tra cliente e polizza (Foreign Key di cliente in Polizza)
        public string CodiceFiscale { get; set; } //Foreing key con convenzione
        public Cliente Cliente { get; set; } //Navigation property
    }
}
