using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;
using System.Web.UI;

namespace Pelisfran.admin.peliculas
{
    public partial class _default : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}