using System;
using System.Collections.Generic;

namespace EntityFrameworkEscola.Domain.Entities
{
    public class Turma
    {
        public Turma()
        {
        
        }

        public int TurmaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
       
        public override string ToString()
        {
            return String.Format("Turma: {0} - Data Início: {1} - Professor: {2}", 0, DataInicio.ToShortDateString(), "Jose");
        }
    }
}
