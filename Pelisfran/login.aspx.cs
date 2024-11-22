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

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            bool usuarioAutenticado = autenticacionServicio.AutenticarUsuario(txtEmail.Text, txtPassword.Text);

            if (!usuarioAutenticado)
            {
                alerta.InnerText = "Email o contraseña incorrectos";
                return;
            }

            Response.Redirect("autenticado.aspx");
        }
    }
}