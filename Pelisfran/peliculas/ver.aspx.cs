using Pelisfran.Contexto;
using Pelisfran.Helpers;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class ver : Page
    {
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private AutenticacionServicio _autenticacionServicio = new AutenticacionServicio();

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

                var item = _db.Peliculas.Include("ComentarioPeliculas").Include("PeliculasLikes").Where(p => p.Id == peliculaId).FirstOrDefault();

                visitas.InnerText = "123";
                likes.InnerText = item.PeliculasLikes.Count().ToString() ?? "0";
                estadisticaComentarios.InnerText = item.ComentarioPeliculas.Count().ToString() ?? "0";

                Guid usuarioId = string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name) ? Guid.Empty : Guid.Parse(HttpContext.Current.User.Identity.Name);

                string textoBtnFavorito = "Anadir a Favoritos";
                string iconoFav = "fa-regular fa-heart";
                if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(usuarioId, peliculaId))
                {
                    iconoFav = "fa-solid fa-heart";
                    textoBtnFavorito = "Eliminar de Favoritos";
                }
                favoritoIcono.Attributes["class"] = iconoFav;
                ActualizarPanelUpBotonFavorito(textoBtnFavorito);

                botonLike.DesactivarLike();
                if (_db.PeliculasLikes.Where(p => p.PeliculaId == pelicula.Id && p.UsuarioId == usuarioId).FirstOrDefault() != null)
                {
                    botonLike.ActivarLike();
                }
                upLikes.Update();


                if (_db.ComentariosPeliculas.Where(c => c.PeliculaId == peliculaId).Any())
                {
                    // REF
                    var comentarios = ObtenerComentarios();
                    BindearComentarios(comentarios);
                }
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            if (!_autenticacionServicio.EstaUsuarioAutenticado())
            {
                RedirigirAlLogin();
                return;
            }

            Guid peliculaId = Guid.Parse(hfId.Value);
            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            string iconoFav = string.Empty;
            if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(usuarioId, peliculaId))
            {
                _peliculaFavoritaServicio.DesmarcarPeliculaComoFavorita(usuarioId, peliculaId);
                iconoFav = "fa-regular fa-heart";
                favoritoIcono.Attributes["class"] = iconoFav;
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
            iconoFav = "fa-solid fa-heart";
            favoritoIcono.Attributes["class"] = iconoFav;

            ActualizarPanelUpBotonFavorito("Eliminar de Favoritos");
            upEstadisticas.Update();
        }

        private void ActualizarPanelUpBotonFavorito(string mensaje)
        {
            btnFavorito.Text = mensaje;
            upBotonFavorito.Update();
        }

        protected void btnGuardarComentario_Click(object sender, EventArgs e)
        {
            if (!_autenticacionServicio.EstaUsuarioAutenticado())
            {
                RedirigirAlLogin();
                return;
            }

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
            lvComentarios.DataSource = comentarios;
            lvComentarios.DataBind();
            upComentarios.Update();

            estadisticaComentarios.InnerText = comentarios.Count().ToString();
            upEstadisticas.Update();
        }

        private void RedirigirAlLogin()
        {
            Response.Redirect("login.aspx", false);
        }

        private List<ComentarioPelicula> ObtenerComentarios()
        {
            return _db.ComentariosPeliculas.OrderByDescending(c => c.FechaCreacion).ToList();
        }

        private void BindearComentarios(List<ComentarioPelicula> comentarios)
        {
            lvComentarios.DataSource = comentarios;
            lvComentarios.DataBind();
        }

        protected void lvComentarios_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager dpComentarios = (DataPager)lvComentarios.FindControl("dpComentarios");
            dpComentarios.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            var comentarios = ObtenerComentarios();
            BindearComentarios(comentarios);
        }

        protected void lvComentarios_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewItem repeaterItem = e.Item;

            HtmlGenericControl nombre = (HtmlGenericControl)repeaterItem.FindControl("nombre");
            HtmlGenericControl fecha = (HtmlGenericControl)repeaterItem.FindControl("fecha");
            HtmlGenericControl comentario = (HtmlGenericControl)repeaterItem.FindControl("comentario");

            ComentarioPelicula comentarioPelicula = (ComentarioPelicula)repeaterItem.DataItem;

            nombre.InnerText = comentarioPelicula.Usuario.NombreUsuario;
            fecha.InnerText = HelperFecha.ObtenerTiempoTranscurrido(comentarioPelicula.FechaCreacion);
            comentario.InnerText = comentarioPelicula.Comentario;
        }

        protected void botonLike_Click(object sender, EventArgs e)
        {
            if (!_autenticacionServicio.EstaUsuarioAutenticado())
            {
                RedirigirAlLogin();
                return;
            }

            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            Guid peliculaId = Guid.Parse(Request.QueryString["id"]);
            PeliculaLike peliculaLike = _db.PeliculasLikes.Where(pl => pl.UsuarioId == usuarioId && pl.PeliculaId == peliculaId).FirstOrDefault();

            if (peliculaLike != null)
            {
                _db.PeliculasLikes.Remove(peliculaLike);
                botonLike.DesactivarLike();
            }
            else
            {
                peliculaLike = new PeliculaLike { Id = Guid.NewGuid(), CreadoEn = DateTime.Now, PeliculaId = peliculaId, UsuarioId = usuarioId };
                _db.PeliculasLikes.Add(peliculaLike);
                botonLike.ActivarLike();
            }
            _db.SaveChanges();
            upLikes.Update();

            likes.InnerText = $"{_db.PeliculasLikes.Where(pl => pl.PeliculaId == peliculaId).Count().ToString()}";
            upEstadisticas.Update();
        }
    }
}