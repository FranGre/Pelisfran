using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;

namespace Pelisfran.peliculas
{
    public partial class ver : System.Web.UI.Page
    {
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("~/autenticado.aspx");
                return;
            }

            Guid peliculaId = Guid.Parse(Request.QueryString["id"]);
            Pelicula pelicula = _peliculaServicio.ObtenerPelicula(peliculaId);

            if (pelicula == null)
            {
                Response.Redirect("~/autenticado.aspx");
                return;
            }

            if (!Page.IsPostBack)
            {
                titulo.InnerText = pelicula.Titulo;
                descripcion.InnerText = pelicula.SinopsisBreve;
                hfId.Value = pelicula.Id.ToString();
            }
        }
    }
}