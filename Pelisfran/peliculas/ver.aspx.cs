using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class ver : System.Web.UI.Page
    {
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

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

                string textoBtnFavorito = "Anadir a Favoritos";
                if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(usuarioId, peliculaId))
                {
                    textoBtnFavorito = "Eliminar de Favoritos";
                }

                ActualizarPanelUpBotonFavorito(textoBtnFavorito);

                if (_db.ComentariosPeliculas.Where(c => c.PeliculaId == peliculaId).Any())
                {
                    // REF
                    var comentarios = _db.ComentariosPeliculas.Where(c => c.PeliculaId == peliculaId).OrderByDescending(c => c.FechaCreacion).Take(5).ToList();
                    repComentarios.DataSource = comentarios;
                    repComentarios.DataBind();
                }
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

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbComentario.Text)) { return; }

            ComentarioPelicula comentario = new ComentarioPelicula
            {
                Id = Guid.NewGuid(),
                Comentario = tbComentario.Text,
                FechaCreacion = DateTime.Now,
                UsuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name),
                PeliculaId = Guid.Parse(Request.QueryString["id"])
            };

            _db.ComentariosPeliculas.Add(comentario);
            _db.SaveChanges();

            tbComentario.Text = string.Empty;
            upFormComentario.Update();

            // REF
            Guid peliculaId = Guid.Parse(Request.QueryString["id"]);
            var comentarios = _db.ComentariosPeliculas.Include("Usuario").Where(c => c.PeliculaId == peliculaId).OrderByDescending(c => c.FechaCreacion).Take(5).ToList();
            repComentarios.DataSource = comentarios;
            repComentarios.DataBind();
            upComentarios.Update();
        }

        protected void repComentarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item;

            HtmlGenericControl nombre = (HtmlGenericControl)repeaterItem.FindControl("nombre");
            HtmlGenericControl fecha = (HtmlGenericControl)repeaterItem.FindControl("fecha");
            HtmlGenericControl comentario = (HtmlGenericControl)repeaterItem.FindControl("comentario");

            ComentarioPelicula comentarioPelicula = (ComentarioPelicula)repeaterItem.DataItem;

            nombre.InnerText = comentarioPelicula.Usuario.NombreUsuario;
            fecha.InnerText = comentarioPelicula.FechaCreacion.ToShortDateString();
            comentario.InnerText = comentarioPelicula.Comentario;
        }
    }
}