using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EntityFrameworkEscola.DataAccess;
using EntityFrameworkEscola.Domain.Entities;
using EntityFrameworkEscola.BLL;
using Newtonsoft.Json;
namespace WebApplication1.WS
{
    /// <summary>
    /// Descrição resumida de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }
        [WebMethod]
        public string retornaAlunos()
        {
            try
            {

                AlunoBLL alunoBLL = new AlunoBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = alunoBLL.retornaAluno()
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }
        [WebMethod]
        public string InserirAluno(string email, string senha, string nome)
        {
            try
            {
                AlunoBLL alunoBLL = new AlunoBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = alunoBLL.InserirAluno(email, senha, nome)
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }
        [WebMethod]
        public string retornaAlunosPorNome(string nome)
        {
            try
            {
                AlunoBLL alunoBLL = new AlunoBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = alunoBLL.retornaAlunosPorNome(nome)
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }
        [WebMethod]
        public string retornaCursos()
        {
            try
            {

                CursosBLL cursosBLL = new CursosBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = cursosBLL.retornaCursos()
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }
        [WebMethod]
        public string InserirCurso(string descricao, string numero, bool ativo)
        {
            try
            {
                CursosBLL alunoBLL = new CursosBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = alunoBLL.InserirCurso(descricao, numero, ativo)
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }
        [WebMethod]
        public string retornaCursosPorDescricao(string descricao)
        {
            try
            {
                CursosBLL alunoBLL = new CursosBLL();
                return JsonConvert.SerializeObject(new
                {
                    teste = alunoBLL.retornaCursosPorDescricao(descricao)
                });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new
                {
                    codigo = -1,
                    msg = ex.Message
                });
            }
        }

    }
}
