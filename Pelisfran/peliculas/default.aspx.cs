using Pelisfran.Contexto;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class _default : System.Web.UI.Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            var peliculas = _db.Peliculas.AsQueryable().Include("PortadaPelicula");
            if (Page.IsPostBack)
            {
                string busqueda = (string)ViewState["Text"];
                var idsGenerosSeleccionados = generos.ObtenerIDsGenerosSeleccionados();
                bool hayTextoDeBusqueda = !string.IsNullOrEmpty(busqueda);
                bool hayGenerosSeleccionados = idsGenerosSeleccionados.Any();

                if (hayTextoDeBusqueda && !hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Where(item => item.Titulo.Contains(busqueda));
                }
                else if (!hayTextoDeBusqueda && hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Include("GenerosPeliculas");
                    peliculas = peliculas.Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
                }
                else if (hayTextoDeBusqueda && hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Include("GenerosPeliculas");
                    peliculas = peliculas.Where(item => item.Titulo.Contains(busqueda)).Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
                }
            }

            ucPeliculas.Cargar(peliculas.ToList());
            upPeliculas.Update();
        }

        protected void tsBusqueda_Buscar(object sender, string e)
        {
            var peliculas = _db.Peliculas.AsQueryable().Include("PortadaPelicula");
            var idsGenerosSeleccionados = generos.ObtenerIDsGenerosSeleccionados();

            ViewState["Text"] = tsBusqueda.Text;

            bool hayTextoDeBusqueda = !string.IsNullOrEmpty(tsBusqueda.Text);
            bool hayGenerosSeleccionados = idsGenerosSeleccionados.Any();

            if (hayTextoDeBusqueda && !hayGenerosSeleccionados)
            {
                peliculas = peliculas.Where(item => item.Titulo.Contains(tsBusqueda.Text));
            }
            else if (!hayTextoDeBusqueda && hayGenerosSeleccionados)
            {
                peliculas = peliculas.Include("GenerosPeliculas");
                peliculas = peliculas.Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
            }
            else if (hayTextoDeBusqueda && hayGenerosSeleccionados)
            {
                peliculas = peliculas.Include("GenerosPeliculas");
                peliculas = peliculas.Where(item => item.Titulo.Contains(tsBusqueda.Text)).Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
            }

            ucPeliculas.Cargar(peliculas.ToList());
            upPeliculas.Update();
        }
    }
}