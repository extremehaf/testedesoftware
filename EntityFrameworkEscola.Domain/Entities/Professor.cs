using System.Collections.Generic;

namespace EntityFrameworkEscola.Domain.Entities
{
    public class Professor: Pessoa
    {
        public Professor()
        {
        }
        public int ProfessorId { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
}
