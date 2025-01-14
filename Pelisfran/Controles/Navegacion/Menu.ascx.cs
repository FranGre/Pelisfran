using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Pelisfran.Controles.Navegacion
{
    public partial class Menu : UserControl
    {
        private AutenticacionServicio _autenticacionServicio = new AutenticacionServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegistrarse.Visible = false;
            btnIniciarSesion.Visible = false;
            botonCerrarSesion.Visible = false;
            miPerfil.Visible = false;

            if (_autenticacionServicio.EstaUsuarioAutenticado())
            {
                botonCerrarSesion.Visible = true;
                miPerfil.Visible = true;
                Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
                Usuario usuario = _db.Usuarios.Include("FotoPerfil").Where(u => u.Id == usuarioId).FirstOrDefault();

                string rutaFotoPerfil = usuario.FotoPerfil.Ruta;
                imgFotoPerfil.ImageUrl = $"~/{rutaFotoPerfil}";

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

        protected void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Request.Cookies.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("~/peliculas/default.aspx");
        }
    }
}