﻿using System;
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

        public void ExcluirAlunos()
        {
            using (var db = new DataContext())
            {
                List<Aluno> alunos = db.Alunos
                    .Include("Usuario")
                .ToList();
                foreach (Aluno item in alunos)
                {
                    db.Alunos.Remove(item);
                }
            }
        }
        public Domain.Entities.Aluno InserirAluno(string email, string senha, string nome)
        {
            var db = new DataContext();
            
                try
                {
                    if (!String.IsNullOrEmpty(nome) && !String.IsNullOrEmpty(email))
                    {
                        if (senha.Length >= 8)

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
                    throw new ArgumentNullException("Nome não pode ser vazio");
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Nome não pode ser vazio" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Domain.Entities.Usuario login(string email, string senha)
        {
            try
            {
                if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(senha))
                {
                    if (senha.Length >= 8)

                    {
                        using(var db = new DataContext())
                        {
                            return db.Usuarios.Where(u => u.Senha == senha && u.Email == email).FirstOrDefault();
                        }  
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
}
