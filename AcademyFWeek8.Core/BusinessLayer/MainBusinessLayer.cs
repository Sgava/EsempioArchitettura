using AcademyFWeek8.Core.Entities;
using AcademyFWeek8.Core.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;        
        private readonly IRepositoryStudenti studentiRepo;        


        public MainBusinessLayer(IRepositoryCorsi corsi, IRepositoryStudenti studenti)
        {
            corsiRepo = corsi;
            studentiRepo = studenti;
        }

        public Esito AggiungiCorso(Corso nuovoCorso)
        {
            Corso corsoRecuperato=corsiRepo.GetByCode(nuovoCorso.CorsoCodice);
            if (corsoRecuperato == null)
            {
                corsiRepo.Add(nuovoCorso);
                return new Esito() { isOk = true, Messaggio = "Corso aggiunto correttamente" };
            }
            return new Esito() { isOk = false, Messaggio = "Impossibile aggiungere il corso perché esiste già un corso con quel codice" };
        }

        public Esito EliminaCorso(string? codice)
        {
            var corsoRecuperato = corsiRepo.GetByCode(codice);
            if (corsoRecuperato == null)
            {
                return new Esito() { isOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsiRepo.Delete(corsoRecuperato);
            return new Esito() { isOk = true, Messaggio = "Corso eliminato correttamente" };
        }

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }

        public Esito ModificaCorso(string? codice, string? nuovoNome, string? nuovaDescrizione)
        {
            var corsoRecuperato=corsiRepo.GetByCode(codice);
            if(corsoRecuperato == null)
            {
                return new Esito() { isOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsoRecuperato.Nome = nuovoNome;
            corsoRecuperato.Descrizione= nuovaDescrizione;
            corsiRepo.Update(corsoRecuperato);
            return new Esito() { isOk = true, Messaggio = "Corso aggiornato correttamente" };
        }
    }
}
