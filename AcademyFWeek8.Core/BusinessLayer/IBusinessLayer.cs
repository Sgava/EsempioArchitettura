using AcademyFWeek8.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        //Elenco dei metodi/funzionalità esposte
        List<Corso> GetAllCorsi();
        Esito AggiungiCorso(Corso nuovoCorso);
    }
}
