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

       
        #region Funzionalità Studenti
        public Esito EliminaStudente(int idStudenteDaEliminare)
        {
            var studenteEsistente = studentiRepo.GetById(idStudenteDaEliminare);
            if (studenteEsistente == null)
            {
                return new Esito { Messaggio = "Nessuno studente corrispondente all'id inserito", IsOk = false };
            }
            studentiRepo.Delete(studenteEsistente);
            return new Esito { Messaggio = "Studente eliminato correttamente", IsOk = true };
        }
        public List<Studente> GetAllStudenti()
        {
            return studentiRepo.GetAll();
        }

        public List<Studente> GetStudentiByCorsoCodice(string codiceCorso)
        {
            //controllo input
            //controllo se codice corso esiste. Se non esiste allora restituisco null
            //se il corso esiste, allora recupero dalla repo degli studenti la lista di quelli che hanno quel corsoCodice
            var corso = corsiRepo.GetByCode(codiceCorso);
            if (corso == null)
            {
                return null;
            }
            List<Studente> studentiFiltrati = new List<Studente>();
            foreach (var item in studentiRepo.GetAll())
            {
                if (item.CorsoCodice == codiceCorso)
                {
                    studentiFiltrati.Add(item);
                }
            }
            return studentiFiltrati;

        }

        public Esito InserisciNuovoStudente(Studente nuovoStudente)
        {
            //controllo input
            Corso corsoEsistente = corsiRepo.GetByCode(nuovoStudente.CorsoCodice);
            if (corsoEsistente == null)
            {
                return new Esito { Messaggio = "Codice corso errato", IsOk = false };
            }
            studentiRepo.Add(nuovoStudente);
            //corsoEsistente.Studenti.Add(nuovoStudente);
            return new Esito { Messaggio = "studente inserito correttamente", IsOk = true };
        }
        public Esito ModificaMailStudente(int idStudenteDaModificare, string nuovaEmail)
        {
            //controllo input
            //controllo se id esiste
            var studente = studentiRepo.GetById(idStudenteDaModificare);
            if (studente == null)
            {
                return new Esito { Messaggio = "Id Studente errato o inesistente", IsOk = false };
            }
            studente.Email = nuovaEmail;
            studentiRepo.Update(studente);
            return new Esito { Messaggio = "Email Studente aggiornata correttamente", IsOk = true };
        }
        #endregion Funzionalità Studenti

        #region Funzionalità Corsi
        public Esito AggiungiCorso(Corso nuovoCorso)
        {
            Corso corsoRecuperato = corsiRepo.GetByCode(nuovoCorso.CorsoCodice);
            if (corsoRecuperato == null)
            {
                corsiRepo.Add(nuovoCorso);
                return new Esito() { IsOk = true, Messaggio = "Corso aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere il corso perché esiste già un corso con quel codice" };
        }
        public Esito EliminaCorso(string? codice)
        {
            var corsoRecuperato = corsiRepo.GetByCode(codice);
            if (corsoRecuperato == null)
            {
                return new Esito() { IsOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsiRepo.Delete(corsoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Corso eliminato correttamente" };
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
                return new Esito() { IsOk = false, Messaggio = "Nessun corso corrispondente al codice inserito" };
            }
            corsoRecuperato.Nome = nuovoNome;
            corsoRecuperato.Descrizione= nuovaDescrizione;
            corsiRepo.Update(corsoRecuperato);
            return new Esito() { IsOk = true, Messaggio = "Corso aggiornato correttamente" };
        }
        #endregion Funzionalità Corsi
    }
}
