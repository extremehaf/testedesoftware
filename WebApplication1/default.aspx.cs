using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityFrameworkEscola.BLL;
using EntityFrameworkEscola.Domain.Entities;
namespace WebApplication1
{
    public partial class @default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            try
            {
                AlunoBLL bll = new AlunoBLL();
                Usuario usuario = bll.login(email, senha);
                if(usuario != null)
                {
                    Response.Redirect("WS/WebService1.asmx");
                }
            }
            catch(Exception ex)
            {
                Response.Write("Email ou senha invalidos. Erro:" +ex.Message);
            }
        }
    }
}