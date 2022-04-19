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


        public MainBusinessLayer(IRepositoryCorsi corsi)
        {
            corsiRepo = corsi;
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

        public List<Corso> GetAllCorsi()
        {
            return corsiRepo.GetAll();
        }
    }
}
