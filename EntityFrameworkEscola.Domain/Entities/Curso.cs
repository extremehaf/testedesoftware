﻿using System.Collections.Generic;

namespace EntityFrameworkEscola.Domain.Entities
{
    public class Curso
    {
        public Curso()
        {
            Ativo = true;
        }
        public int CursoId { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }


        public override string ToString()
        {
            return Descricao;
        }
    }
}
