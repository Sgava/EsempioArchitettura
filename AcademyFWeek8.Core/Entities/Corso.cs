using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Corso
    {
        public string CorsoCodice { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }


        public override string ToString()
        {
            return $"{CorsoCodice}\t{Nome}\t{Descrizione}";
        }
    }
}
