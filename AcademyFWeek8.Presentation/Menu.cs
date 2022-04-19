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
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryCorsiMock());

        
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
                case 0:
                    return false;                    
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
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
            Console.WriteLine("Ecco l'elenco dei corsi presenti:");
            foreach (var item in listaCorsi)
            {
                Console.WriteLine(item);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************MENU*****************");
            Console.WriteLine("1.Visualizza Corsi");
            Console.WriteLine("2.Inserisci nuovo Corso");
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
