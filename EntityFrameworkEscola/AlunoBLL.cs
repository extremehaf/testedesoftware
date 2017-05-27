using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkEscola.DataAccess;
using EntityFrameworkEscola.Domain.Entities;
namespace EntityFrameworkEscola.BLL
{
    public class AlunoBLL
    {
        public List<Domain.Entities.Aluno> retornaAluno()
        {
            using (var db = new DataContext())
            {
                return db.Alunos.ToList();
            }
        }
        public Domain.Entities.Aluno InserirAluno(string email, string senha, string nome)
        {
            using (var db = new DataContext())
            {
                try
                {
                    if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(email))
                    {
                        if (senha.Length > 8)

                        {
                           
                            Aluno aluno = new Aluno();
                            aluno.Nome = nome;


                            Usuario usuario = new Usuario();
                            usuario.Email = email;
                            usuario.Senha = senha;

                            aluno.Usuario = usuario;
                            db.Alunos.Add(aluno);
                            db.SaveChanges();
                            return aluno;
                        }
                        else
                            throw new Exception("Senha Invalida");
                    }
                    else
                        throw new Exception("Nome não pode ser vazio");
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
        }
        public List<Domain.Entities.Aluno> retornaAlunosPorNome(string nome)
        {
            try
            {
                if (!String.IsNullOrEmpty(nome))
                {
                    using (var db = new DataContext())
                    {
                        return db.Alunos.Where(a => a.Nome == nome).ToList();
                    }
                }
                else
                    throw new Exception("Nome não pode ser vazio");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
