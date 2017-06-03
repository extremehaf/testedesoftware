using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkEscola.BLL;
using System.Collections.Generic;
using EntityFrameworkEscola.Domain.Entities;
using Newtonsoft.Json;
using EntityFrameworkEscola.DataAccess;
using System.Linq;


namespace AlunoTest
{
    [TestClass]
    public class AlunoTest
    {
        [TestMethod]
        public void InserirAlunoTest()
        {
            //Assemble
            AlunoBLL alunoBLL = new AlunoBLL();
            Aluno aluno = new Aluno();
            Aluno alunoResult = new Aluno();

            //Act
            string email = "aluno1@gmail.com";
            string senha = "password1";
            string nome = "Aluno 1";

            aluno.Usuario.Email = email;
            aluno.Usuario.Senha = senha;
            aluno.Nome = nome;

            alunoResult = alunoBLL.InserirAluno(aluno.Usuario.Email, aluno.Usuario.Senha, aluno.Nome);
            aluno.AlunoId = alunoResult.AlunoId;
            aluno.Usuario.UsuarioId = alunoResult.Usuario.UsuarioId;

            //Assert
            string ExpectedResult = JsonConvert.SerializeObject(alunoResult);
            string ActualResult = JsonConvert.SerializeObject(aluno);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InserirAlunoTest_ArgumentNullException()
        {
            AlunoBLL alunoBLL = new AlunoBLL();
            alunoBLL.InserirAluno("", "", "");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Senha Invalida")]
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
            List<Aluno> expectedResult = new List<Aluno>();
            List<Aluno> actualResult = new List<Aluno>();
            string expectedConvert = "", actualConvert = "";

            //Act
            expectedResult.Add(alunoBLL.InserirAluno("retornaAluno1@email.com", "password", "retornaAluno 1"));
            expectedResult.Add(alunoBLL.InserirAluno("retornaAluno2@email.com", "password", "retornaAluno 2"));

            foreach (Aluno al in expectedResult)
            {
                expectedConvert += JsonConvert.SerializeObject(al.AlunoId + "" + al.Nome);
            }

            actualResult = alunoBLL.retornaAluno();
            foreach (Aluno al in actualResult)
            {
                actualConvert += JsonConvert.SerializeObject(al.AlunoId + "" + al.Nome);
            }

            //Assert
            Assert.AreEqual(expectedConvert, actualConvert);
        }

        [TestMethod]
        public void retornaAlunosPorNomeTest()
        {
            AlunoBLL alunoBLL = new AlunoBLL();

            List<Aluno> ExpectedAluno = new List<Aluno>();
            List<Aluno> ResultAluno = new List<Aluno>();
            List<Usuario> usuario = new List<Usuario>();

            string expectedResult = "", ActualResult = "";

            //Act
            alunoBLL.InserirAluno("retornaAlunosPorNome@email.com", "password", "retornaAlunosPorNome 1");
            ExpectedAluno.Add(alunoBLL.InserirAluno("retornaAlunosPorNome2@gmail.com", "password2", "retornaAlunosPorNome 2"));
            alunoBLL.InserirAluno("retornaAlunosPorNome3@gmail.com", "password2", "retornaAlunosPorNome 3");

            foreach (Aluno al in ExpectedAluno)
            {
                expectedResult += JsonConvert.SerializeObject(al.AlunoId + "" + al.Nome);
            }

            ResultAluno = alunoBLL.retornaAlunosPorNome("retornaAlunosPorNome 2");
            foreach (Aluno al in ResultAluno)
            {
                ActualResult += JsonConvert.SerializeObject(al.AlunoId + "" + al.Nome);
            }
            Assert.AreEqual(expectedResult, ActualResult);
        }

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
