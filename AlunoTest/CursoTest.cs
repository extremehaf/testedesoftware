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
    class CursoTest
    {
        [TestMethod]
        public void InserirCursoTest()
        {
            //Assemble
            CursosBLL cursoBLL = new CursosBLL();
            Curso curso = new Curso();
            Curso cursoResult = new Curso();

            //Act
            string descricao = "sistemas";
            string numero = "0001";
            bool ativo = true;

            curso.Descricao = descricao;
            curso.Numero = numero;
            curso.Ativo = ativo;

            cursoResult = cursoBLL.InserirCurso(curso.Descricao, curso.Numero, curso.Ativo);
            curso.CursoId = cursoResult.CursoId;
            curso.CursoId = cursoResult.CursoId;

            //Assert
            string ExpectedResult = JsonConvert.SerializeObject(cursoResult);
            string ActualResult = JsonConvert.SerializeObject(curso);
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InserirAlunoTest_ArgumentNullException()
        {
            CursosBLL cursoBLL = new CursosBLL();
            cursoBLL.InserirCurso("", "", false);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Curso inexistente")]
        public void InserirAlunoTest_SenhaInvalida()
        {
            CursosBLL cursoBLL = new CursosBLL();
            cursoBLL.InserirCurso("sistemas", "0002", true);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Descrição não pode ser vazia")]
        public void InserirAlunoTest_NomeVazio()
        {
            CursosBLL cursoBLL = new CursosBLL();
            cursoBLL.InserirCurso("sistemas", "0002", false);

        }

        [TestMethod]
        public void retornaCursoTest()
        {

            //Assemble
            CursosBLL cursoBLL = new CursosBLL();
            List<Curso> expectedResult = new List<Curso>();
            List<Curso> actualResult = new List<Curso>();
            string expectedConvert = "", actualConvert = "";

            //Act
            expectedResult.Add(cursoBLL.InserirCurso("sistemas", "password", false));
            expectedResult.Add(cursoBLL.InserirCurso("direito", "password", false));

            foreach (Curso al in expectedResult)
            {
                expectedConvert += JsonConvert.SerializeObject(al.CursoId + "" + al.Descricao);
            }

            actualResult = cursoBLL.retornaCursosPorDescricao("sistemas");
            foreach (Curso al in actualResult)
            {
                actualConvert += JsonConvert.SerializeObject(al.CursoId + "" + al.Descricao);
            }

            //Assert
            Assert.AreEqual(expectedConvert, actualConvert);
        }
    }
}