using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkEscola.Domain.Entities;
using EntityFrameworkEscola.DataAccess;
namespace EntityFrameworkEscola.BLL
{
    public class CursosBLL
    {
        public List<Curso> retornaCursos()
        {
            using (var db = new DataContext())
            {
                return db.Cursos.ToList();
            }
        }

        public void ExcluirCursos()
        {
            using (var db = new DataContext())
            {
                List<Curso> cursos = db.Cursos.ToList();
                foreach (Curso item in cursos)
                {
                    db.Cursos.Remove(item);
                }
            }
        }

        public Domain.Entities.Curso InserirCurso(string descricao, string numero, bool ativo)
        {
            var db = new DataContext();

            try
            {
                if (!String.IsNullOrEmpty(descricao) && !String.IsNullOrEmpty(numero))
                {

                    Curso curso = new Curso();
                    curso.Descricao = descricao;
                    curso.Numero = numero;
                    curso.Ativo = ativo;

                    db.Cursos.Add(curso);
                    db.SaveChanges();
                    return curso;

                }
                else
                    throw new Exception("descricao e numero não pode ser vazio");
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<Domain.Entities.Curso> retornaCursosPorDescricao(string descricao)
        {
            try
            {
                if (!String.IsNullOrEmpty(descricao))
                {
                    using (var db = new DataContext())
                    {
                        return db.Cursos.Where(a => a.Descricao == descricao).ToList();
                    }
                }
                else
                    throw new ArgumentNullException("descricao não pode ser vazio");
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("descricao não pode ser vazio");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
