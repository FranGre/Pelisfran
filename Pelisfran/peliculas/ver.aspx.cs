using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web;

namespace Pelisfran.peliculas
{
    public partial class ver : System.Web.UI.Page
    {
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();

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

                Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);

                if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(usuarioId, peliculaId))
                {
                    ActualizarPanelUpBotonFavorito("Eliminar de Favoritos");
                    return;
                }
                ActualizarPanelUpBotonFavorito("Anadir a Favoritos");
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Guid peliculaId = Guid.Parse(hfId.Value);
            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);

            if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(usuarioId, peliculaId))
            {
                _peliculaFavoritaServicio.DesmarcarPeliculaComoFavorita(usuarioId, peliculaId);
                ActualizarPanelUpBotonFavorito("Anadir a Favoritos");
                return;
            }

            PeliculaFavorita peliculaFavorita = new PeliculaFavorita
            {
                Id = Guid.NewGuid(),
                CreadoEn = DateTime.Now,
                UsuarioId = usuarioId,
                PeliculaId = peliculaId
            };
            _peliculaFavoritaServicio.MarcarPeliculaComoFavorita(peliculaFavorita);
            ActualizarPanelUpBotonFavorito("Eliminar de Favoritos");
        }

        private void ActualizarPanelUpBotonFavorito(string mensaje)
        {
            btnFavorito.Text = mensaje;
            upBotonFavorito.Update();
        }
    }
}