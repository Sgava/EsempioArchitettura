using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyFWeek8.Core.Entities
{
    public class Docente: Persona
    {
        public string Telefono { get; set; }

        public override string ToString()
        {
            return base.ToString()+ $"\t tel.{Telefono}";
        }
    }
}
