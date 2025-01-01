using Pelisfran.Servicios;
using System;
using System.Web.UI;

namespace Pelisfran.Controles.Navegacion
{
    public partial class Menu : UserControl
    {
        private AutenticacionServicio _autenticacionServicio = new AutenticacionServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegistrarse.Visible = false;
            btnIniciarSesion.Visible = false;
            btnCerrarSesion.Visible = false;

            if (_autenticacionServicio.EstaUsuarioAutenticado())
            {
                btnCerrarSesion.Visible = true;
            }
            else
            {
                btnRegistrarse.Visible = true;
                btnIniciarSesion.Visible = true;
            }

            upBotonesMenu.Update();
        }

        protected void lbPelisFran_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }

        protected void lkPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/peliculas/default.aspx");
        }

        protected void lkSeries_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/series/default.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/registrarse.aspx");
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {

        }
    }
}