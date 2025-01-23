using Pelisfran.Contexto;
using Pelisfran.Core;
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
    public partial class ver : Base
    {
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private AutenticacionServicio _autenticacionServicio = new AutenticacionServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid peliculaId = Guid.Empty;
            try
            {
                peliculaId = Guid.Parse(Request.QueryString["id"]);
            }
            catch (ArgumentException ex)
            {
                Response.Redirect("~/404.aspx");
            }
            catch (FormatException ex)
            {
                Response.Redirect("~/404.aspx");
            }

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

                var item = _db.Peliculas.Include("ComentarioPeliculas").Include("PeliculasLikes").Include("VisitasPeliculas").Where(p => p.Id == peliculaId).FirstOrDefault();

                visitas.InnerText = item.VisitasPeliculas.Count().ToString();
                likes.InnerText = item.PeliculasLikes.Count().ToString();
                estadisticaComentarios.InnerText = item.ComentarioPeliculas.Where(c => c.Visible).Count().ToString();

                botonFavorito.DesactivarFavorito();
                if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(this.usuarioId, peliculaId))
                {
                    botonFavorito.ActivarFavorito();
                }
                upBotonFavorito.Update();

                botonLike.DesactivarLike();
                if (_db.PeliculasLikes.Where(p => p.PeliculaId == pelicula.Id && p.UsuarioId == usuarioId).FirstOrDefault() != null)
                {
                    botonLike.ActivarLike();
                }
                upLikes.Update();


                if (_db.ComentariosPeliculas.Where(c => c.Visible && c.PeliculaId == peliculaId).Any())
                {
                    // REF
                    var comentarios = ObtenerComentarios(peliculaId);
                    BindearComentarios(comentarios);
                }
            }
        }

        protected void botonFavorito_Click(object sender, EventArgs e)
        {
            if (!_autenticacionServicio.EstaUsuarioAutenticado())
            {
                RedirigirAlLogin();
                return;
            }

            Guid peliculaId = Guid.Parse(hfId.Value);
            if (_peliculaFavoritaServicio.PeliculaEstaMarcadaComoFavorita(this.usuarioId, peliculaId))
            {
                _peliculaFavoritaServicio.DesmarcarPeliculaComoFavorita(this.usuarioId, peliculaId);
                botonFavorito.DesactivarFavorito();
                upBotonFavorito.Update();
                return;
            }

            PeliculaFavorita peliculaFavorita = new PeliculaFavorita
            {
                Id = Guid.NewGuid(),
                CreadoEn = DateTime.Now,
                UsuarioId = this.usuarioId,
                PeliculaId = peliculaId
            };
            _peliculaFavoritaServicio.MarcarPeliculaComoFavorita(peliculaFavorita);
            botonFavorito.ActivarFavorito();

            upBotonFavorito.Update();
            upEstadisticas.Update();
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
                Visible = true,
                UsuarioId = this.usuarioId,
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

        private List<ComentarioPelicula> ObtenerComentarios(Guid peliculaId)
        {
            return _db.ComentariosPeliculas.Where(c => c.Visible && c.PeliculaId == peliculaId).OrderByDescending(c => c.FechaCreacion).ToList();
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
            Guid peliculaId = Guid.Parse(Request.QueryString["id"]);

            var comentarios = ObtenerComentarios(peliculaId);
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

            Guid peliculaId = Guid.Parse(Request.QueryString["id"]);
            PeliculaLike peliculaLike = _db.PeliculasLikes.Where(pl => pl.UsuarioId == this.usuarioId && pl.PeliculaId == peliculaId).FirstOrDefault();

            if (peliculaLike != null)
            {
                _db.PeliculasLikes.Remove(peliculaLike);
                botonLike.DesactivarLike();
            }
            else
            {
                peliculaLike = new PeliculaLike { Id = Guid.NewGuid(), CreadoEn = DateTime.Now, PeliculaId = peliculaId, UsuarioId = this.usuarioId };
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