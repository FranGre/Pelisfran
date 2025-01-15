using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Web.UI;

namespace Pelisfran.admin.peliculas
{
    public partial class _default : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private RolServicio _rolServicio = new RolServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var usuario = _db.Usuarios.Find(this.usuarioId);
                TipoRolesEnum rolActual = (TipoRolesEnum)usuario.RolId;

                if (!_rolServicio.EsRol(rolActual, TipoRolesEnum.Administrador))
                {
                    Response.Redirect("~/acceso-denegado.aspx");
                    return;
                }
            }

            var peliculas = _db.Peliculas
                .Include("Usuario").Include("PeliculasLikes").Include("ComentarioPeliculas").Include("VisitasPeliculas")
                .AsEnumerable().Select(p => new
                {
                    p.Id,
                    p.Titulo,
                    FechaLanzamiento = p.FechaLanzamiento.ToShortDateString(),
                    p.Duracion,
                    CreadoPor = p.Usuario.NombreUsuario,
                    Likes = p.PeliculasLikes.Count().ToString() ?? "0",
                    Comentarios = p.ComentarioPeliculas.Count.ToString() ?? "0",
                    Visitas = p.VisitasPeliculas.Count.ToString() ?? "0",
                }).ToList();

            gvPeliculas.DataSource = peliculas;
            gvPeliculas.DataBind();
        }

        protected void btnCrearPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/peliculas/crear.aspx");
        }

        protected void textsearch_Buscar(object sender, string busqueda)
        {
            var query = _db.Peliculas
            .Include("Usuario").Include("PeliculasLikes").Include("ComentarioPeliculas").Include("VisitasPeliculas")
            .AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(p => p.Titulo.Contains(busqueda));
            }

            var peliculas = query
                .Select(p => new
                {
                    p.Id,
                    p.Titulo,
                    p.FechaLanzamiento,
                    p.Duracion,
                    CreadoPor = p.Usuario.NombreUsuario,
                    Likes = p.PeliculasLikes.Count().ToString(),
                    Comentarios = p.ComentarioPeliculas.Count.ToString(),
                    Visitas = p.VisitasPeliculas.Count.ToString(),
                })
                .ToList();

            var peliculasFechaFormateda = peliculas.Select(p => new
            {
                p.Id,
                p.Titulo,
                FechaLanzamiento = p.FechaLanzamiento.ToShortDateString(),
                p.Duracion,
                p.CreadoPor,
                p.Likes,
                p.Comentarios,
                p.Visitas
            });

            gvPeliculas.DataSource = peliculasFechaFormateda;
            gvPeliculas.DataBind();
            upPeliculas.Update();
        }
    }
}