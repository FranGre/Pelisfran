using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Linq.Dynamic;
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

                gvPeliculas.DataBind();
            }
        }

        protected void btnCrearPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/peliculas/crear.aspx");
        }

        protected void textsearch_Buscar(object sender, string busqueda)
        {
            gvPeliculas.DataBind();
            upPeliculas.Update();
        }

        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con la paginación y ordenación de 
        //, se deben agregar los siguientes parametros:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable gvPeliculas_GetData(int maximumRows, int startRowIndex, out int totalRowCount, string sortByExpression)
        {

            var peliculas = _db.Peliculas
            .Include("Usuario").Include("PeliculasLikes").Include("ComentarioPeliculas").Include("VisitasPeliculas")
            .AsQueryable();

            if (!string.IsNullOrEmpty(textsearch.Text))
            {
                peliculas = peliculas.Where(p => p.Titulo.Contains(textsearch.Text) || p.Duracion.ToString().Contains(textsearch.Text) || p.FechaLanzamiento.ToString().Contains(textsearch.Text));
            }

            if (string.IsNullOrEmpty(sortByExpression))
            {
                sortByExpression = "Titulo";
            }

            totalRowCount = peliculas.Count();

            return peliculas
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
                }).OrderBy(sortByExpression).Skip(startRowIndex).Take(maximumRows);
        }
    }
}