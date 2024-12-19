using Pelisfran.Servicios;
using System;
using System.Web.UI;

namespace Pelisfran
{
    public partial class login1 : Page
    {
        private AutenticacionServicio autenticacionServicio = new AutenticacionServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtEmail.Focus();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            bool usuarioAutenticado = autenticacionServicio.AutenticarUsuario(txtEmail.Text, txtPassword.Text);

            if (!usuarioAutenticado)
            {
                if (!alerta.Attributes["class"].Contains(" notification is-danger"))
                {
                    alerta.Attributes["class"] += " notification is-danger";
                }
                alerta.InnerText = "Email o contraseña incorrectos";
                return;
            }

            alerta.Attributes["class"] = string.Empty;
            alerta.InnerText = string.Empty;

            Response.Redirect("autenticado.aspx");
        }

        protected void lbRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("registrarse.aspx");
        }
    }
}