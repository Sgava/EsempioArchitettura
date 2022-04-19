using AcademyFWeek8.Core.BusinessLayer;
using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.RepositoryMOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Presentation
{
    internal static class Menu
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock(), new RepositoryStudentiMock());

        
        internal static void Start()
        {
            bool continua=true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaCorsi();
                    break;
                case 2:
                    InserisciNuovoCorso();
                    break;
                case 3:
                    ModificaCorso();
                    break; 
                case 4:
                    EliminaCorso();
                    break;
                case 0:
                    return false;                    
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }

        private static void EliminaCorso()
        {
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice");
            string codice = Console.ReadLine();
            Esito esito=bl.EliminaCorso(codice);
            Console.WriteLine(esito.Messaggio);
        }

        private static void ModificaCorso()
        {
            VisualizzaCorsi();
            Console.WriteLine("Quale corso vuoi modificare? Inserisci il codice");
            string codice = Console.ReadLine();
            Console.WriteLine("Inserisci il nuovo nome del corso");
            string nuovoNome=Console.ReadLine();
            Console.WriteLine("Inserisci la nuova descrizione del corso");
            string nuovaDescrizione=Console.ReadLine();

            Esito esito=bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
            Console.WriteLine(esito.Messaggio);
        }

        private static void InserisciNuovoCorso()
        {
            //chiedo all'utente i dati per "creare" il nuovo corso
            Console.WriteLine("Inserisci il codice del nuovo corso");
            string codice=Console.ReadLine();
            Console.WriteLine("Inserisci il nome del nuovo corso");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la descrizione del nuovo corso");
            string descrizione = Console.ReadLine();

            Corso nuovoCorso = new Corso();
            nuovoCorso.CorsoCodice = codice;
            nuovoCorso.Nome = nome;
            nuovoCorso.Descrizione = descrizione;
            
            var esito=bl.AggiungiCorso(nuovoCorso);
            Console.WriteLine(esito.Messaggio);
        }

        private static void VisualizzaCorsi()
        {
            var listaCorsi=bl.GetAllCorsi();
            if (listaCorsi.Count == 0)
            {
                Console.WriteLine("Non ci sono corsi");
            }
            else
            {
                Console.WriteLine("Ecco l'elenco dei corsi presenti:");
                foreach (var item in listaCorsi)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("1.Visualizza Corsi");
            Console.WriteLine("2.Inserisci nuovo Corso");
            Console.WriteLine("3.Modifica Corso");
            Console.WriteLine("4.Elimina Corso");
            Console.WriteLine("\n0. Exit");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while(!(int.TryParse(Console.ReadLine(), out scelta) /*&& scelta >=0 && scelta <= 1*/))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
