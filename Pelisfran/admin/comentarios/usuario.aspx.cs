using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Helpers;
using Pelisfran.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.comentarios
{
    public partial class usuario : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private Guid idUsuarioQuery = Guid.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid usuarioId = Guid.Empty;
            try
            {
                usuarioId = Guid.Parse(Request.QueryString["id"]);
            }
            catch (ArgumentException ex)
            {
                Response.Redirect("~/404.aspx");
            }
            catch (FormatException ex)
            {
                Response.Redirect("~/404.aspx");
            }

            var usuario = _db.Usuarios.Find(usuarioId);

            if (usuario == null)
            {
                Response.Redirect("~/404.aspx");
                return;
            }
            idUsuarioQuery = usuarioId;

            if (!Page.IsPostBack)
            {
                subtitulo.InnerText = usuario.NombreUsuario;
                var comentarios = _db.ComentariosPeliculas.Where(c => c.UsuarioId == this.idUsuarioQuery).ToList();
                BindearComentarios(comentarios);
            }
        }

        private List<ComentarioPelicula> ObtenerComentarios()
        {
            return _db.ComentariosPeliculas.Where(c => c.UsuarioId == this.idUsuarioQuery).OrderByDescending(c => c.FechaCreacion).ToList();
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
            HtmlGenericControl tituloPelicula = (HtmlGenericControl)repeaterItem.FindControl("tituloPelicula");
            HtmlGenericControl fecha = (HtmlGenericControl)repeaterItem.FindControl("fecha");
            HtmlGenericControl comentario = (HtmlGenericControl)repeaterItem.FindControl("comentario");
            Image fotoPerfil = (Image)repeaterItem.FindControl("fotoPerfil");
            Button btnEstado = (Button)repeaterItem.FindControl("btnEstado");

            ComentarioPelicula comentarioPelicula = (ComentarioPelicula)repeaterItem.DataItem;

            nombre.InnerText = comentarioPelicula.Usuario.NombreUsuario;
            tituloPelicula.InnerText = comentarioPelicula.Pelicula.Titulo;
            fecha.InnerText = HelperFecha.ObtenerTiempoTranscurrido(comentarioPelicula.FechaCreacion);
            comentario.InnerText = comentarioPelicula.Comentario;

            btnEstado.Text = "Oculto";
            btnEstado.CssClass = "button is-small is-dark";

            if (comentarioPelicula.Visible)
            {
                btnEstado.Text = "Visible";
                btnEstado.CssClass = "button is-small is-white";
            }

            var usuario = _db.Usuarios.Include("FotoPerfil").Where(u => u.Id == this.idUsuarioQuery).FirstOrDefault();
            string rutaFotoPerfil = usuario.FotoPerfil.Ruta;
            fotoPerfil.ImageUrl = $"~/{rutaFotoPerfil}";
        }

        protected void btnEstado_Command(object sender, CommandEventArgs e)
        {
            Button btnEstado = (Button)sender;
            Guid comentarioId = Guid.Parse(e.CommandArgument.ToString());

            ComentarioPelicula comentarioPelicula = _db.ComentariosPeliculas.Find(comentarioId);
            comentarioPelicula.Visible = !comentarioPelicula.Visible;
            _db.SaveChanges();

            btnEstado.Text = "Oculto";
            btnEstado.CssClass = "button is-small is-dark";

            if (comentarioPelicula.Visible)
            {
                btnEstado.Text = "Visible";
                btnEstado.CssClass = "button is-small is-white";
            }

            UpComentarios.Update();
        }
    }
}