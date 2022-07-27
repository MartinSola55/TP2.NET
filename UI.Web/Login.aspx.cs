using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
        private bool esUserValido(string user, string pass)
        {
            if (this.Logic.ValidaLogin(user, pass))
            {
                return true;
            }
            return false;
        }

        protected void ingresarLinkButton_Click(object sender, EventArgs e)
        {
            Session["user"] = this.txtUser.Text;
            Session["pass"] = this.txtPass.Text;
            if (this.esUserValido((string)Session["user"], (string)Session["pass"]))
            {
                this.ingresarLinkButton.PostBackUrl = "Usuarios.aspx";
            } else
            {
                this.ingresarLinkButton.PostBackUrl = "Login.aspx";
            }
        }
    }
}