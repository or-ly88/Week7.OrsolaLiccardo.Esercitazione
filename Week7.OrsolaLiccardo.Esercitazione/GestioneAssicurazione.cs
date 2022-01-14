using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.OrsolaLiccardo.Esercitazione.Models;
using Week7.OrsolaLiccardo.Esercitazione.Repository;

namespace Week7.OrsolaLiccardo.Esercitazione
{
    public class GestioneAssicurazione
    {
        static IRepositoryCliente repoCliente = new RepositoryCliente();
        static IRepositoryPolizza repoPolizza = new RepositoryPolizza();
        private static ICollection<Cliente> clienti;

        internal static bool SchermoMenu()
        {
            Console.WriteLine("Benvenuto, seleziona un'opzione" +
                "\n[1] Inserisci un nuovo Cliente" +
                "\n[2] Inserisci una nuova Polizza" +
                "\n[3] Stampa tutte le polizze e le informazioni del cliente" +
                "\n[4] Esci");

            int scelta = -1;
            Console.WriteLine("La tua scelta è: ");
            bool verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            while (scelta > 4 || scelta < 0 || verifica == false)
            {
                Console.WriteLine("Inserisci un valore corretto");
                verifica = Int32.TryParse(Console.ReadLine(), out scelta);
            }
            return GestireScelta(scelta);
        }
        private static bool GestireScelta(int scelta)
        {
            bool continua = true;
            switch (scelta)


            {
                case 1:
                    AggiungiCliente(repoCliente);
                    break;
                case 2:
                    AggiungiPolizza();
                    break;
                case 3:
                    StampaDati();
                    break;
                default:

                    continua = false;
                    Console.WriteLine("Arrivederci");
                    break;

            }
            return continua;

            static void Stampa()
            {
                Console.WriteLine("Quale entità vuoi stampare?");
                Console.WriteLine("1. Clienti - 2. Polizze - 3. StampaDati");
                int scelta = int.Parse(Console.ReadLine());
                if (scelta == 1)
                {
                    var clienti = repoCliente.GetAll();
                    StampaCollection<Cliente>(clienti);
                }
                else if (scelta == 2)
                {
                    var dipendenti = repoCliente.GetAll();
                    StampaCollection<Cliente>(clienti);
                }
                else
                {
                    StampaCollection<Polizza>(repoPolizza.GetAll());
                }
            }
            static void StampaCollection<T>(ICollection<T> collection) where T : class
            {
                if (collection.Count == 0)
                {
                    Console.WriteLine("Lista vuota");
                    return;
                }
                foreach (var item in collection)
                {
                    Console.WriteLine(item);
                }
            }

            static void AggiungiPolizza()
            {
                Polizza polizzaDaAggiungere = new Polizza();
                Console.WriteLine("Inserisci il numero della Polizza");
                string NumeroPolizza = Console.ReadLine();
                Console.WriteLine("Inserisci la data della Stipula");
                string dataStipula = Console.ReadLine();
                Console.WriteLine("Inserisci l'importo");
                float importo;
                Console.WriteLine("Inserisci rata mensile");
                float rataMensile;

                bool verificaImporto = float.TryParse(Console.ReadLine(), out importo);
                while (!verificaImporto || importo < 0)
                {
                    verificaImporto = float.TryParse(Console.ReadLine(), out importo);
                }
                var polizze = repoPolizza.GetAll();
                foreach (var item in polizze)
                {
                    Console.WriteLine(item);
                }
                bool verificaRataMensile = float.TryParse(Console.ReadLine(), out rataMensile);
                while (!verificaRataMensile || rataMensile < 0)
                {
                    verificaRataMensile = float.TryParse(Console.ReadLine(), out rataMensile);
                }
                
                foreach (var item in polizze)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Scegli polizza:");
                int numeroPolizza = int.Parse(Console.ReadLine());
                //controllo se esiste un reparto con quell'id/numero
                var repEsistente = repoPolizza.GetByNumero(numeroPolizza);
                if (repEsistente == null)
                {
                    Console.WriteLine("Polizza errata o inesistente");
                }
                else
                {
                    Console.WriteLine("Che tipo di polizza vuoi inserire? 1-RCAuto 2-Furto 3-Vita");
                    int tipoPolizza;
                    bool verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
                    while (tipoPolizza > 3 || tipoPolizza < 0 || verifica == false)
                    {
                        Console.WriteLine("Inserisci un valore corretto");
                        verifica = Int32.TryParse(Console.ReadLine(), out tipoPolizza);
                    }


                    repoPolizza.Create(polizzaDaAggiungere);
                    Console.WriteLine("Polizza aggiunta");
                }
            }



        }

        private static void StampaCollection<T>(object clienti)
        {
            throw new NotImplementedException();
        }

        private static object percentualeCoperta()
        {
            throw new NotImplementedException();
        }

        private static void StampaDati()
        {
            throw new NotImplementedException();
        }

        private static void AggiungiCliente(IRepositoryCliente repoCliente)
        {
            Console.WriteLine("Inserire un nuovo cliente");
            string codiceFiscale = Console.ReadLine();

            var clienteAggiunto = repoCliente.Create(new Cliente()
            {
                CodiceFiscale = codiceFiscale
            });

            if (clienteAggiunto != null)
            {
                Console.WriteLine("Ciente aggiunto: ");
                Console.WriteLine(clienteAggiunto);
            }
            else
            {
                Console.WriteLine("Operazione non riuscita");
            }

            


         }


        
    }
}
