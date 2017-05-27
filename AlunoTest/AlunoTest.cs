using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkEscola.BLL;
using System.Collections.Generic;
using EntityFrameworkEscola.Domain.Entities;


namespace AlunoTest
{
    [TestClass]
    public class AlunoTest
    {
       /*[TestMethod]
        public void InserirAlunoTest()
        {
            //Assemble
            AlunoBLL alunoBLL = new AlunoBLL();
            Aluno aluno = new Aluno();
            Aluno alunoResult = new Aluno();
            List<Aluno> listAluno = new List<Aluno>();

            //Act
            string email = "aluno1@gmail.com";
            string senha = "password1";
            string nome = "Aluno 1";

            aluno.Usuario.Email = email;
            aluno.Usuario.Senha = senha;
            aluno.Nome = nome;

            alunoResult = alunoBLL.InserirAluno(aluno.Usuario.Email, aluno.Usuario.Senha, aluno.Nome);

            //Assert
            Assert.AreEqual(aluno, alunoResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InserirAlunoTest_ArgumentNullException()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            alunoBLL.InserirAluno("","","");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),"Senha Invalida")]
        public void InserirAlunoTest_SenhaInvalida()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            alunoBLL.InserirAluno("aluno1@email.com", "pass", "Aluno 1");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Nome não pode ser vazio")]
        public void InserirAlunoTest_NomeVazio()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            alunoBLL.InserirAluno("aluno1@email.com", "pass", "");
        }

        [TestMethod]
        public void retornaAlunoTest()
        {
            //Assemble
            AlunoBLL alunoBLL = new AlunoBLL();
            List<Aluno> listAluno = new List<Aluno>();

            //Act
            listAluno.Add(alunoBLL.InserirAluno("aluno1@email.com", "password", "Aluno 1"));
            listAluno.Add(alunoBLL.InserirAluno("aluno2@gmail.com", "password2", "Aluno 2"));

            //Assert
            Assert.AreEqual(listAluno, alunoBLL.retornaAluno());
        }

        [TestMethod]
        public void retornaAlunosPorNomeTest()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            Aluno expectedResult = new Aluno();

            //Act
            alunoBLL.InserirAluno("aluno1@email.com", "password", "Aluno 1");
            expectedResult = alunoBLL.InserirAluno("aluno2@gmail.com", "password2", "Aluno 2");
            alunoBLL.InserirAluno("aluno3@gmail.com", "password2", "Aluno 3");
            
            //Assert
            Assert.AreEqual(expectedResult, alunoBLL.retornaAlunosPorNome("Aluno 2"));
        }*/

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void retornaAlunosPorNomeTest_IsNullOrEmpty()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            Aluno expectedResult = new Aluno();

            //Act
            expectedResult = alunoBLL.InserirAluno("aluno2_@amail.com", "password", "Aluno 2");

            //Assert
            alunoBLL.retornaAlunosPorNome("");
        }
    }
}
