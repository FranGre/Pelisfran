using Pelisfran.Contexto;
using Pelisfran.Modelos;
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
                var idsGenerosSeleccionados = generos.ObtenerIDsGenerosSeleccionados();

                pPeliculasNoEncontradas.InnerText = string.Empty;

                bool hayTextoDeBusqueda = !string.IsNullOrEmpty(tbBusqueda.Text);
                bool hayGenerosSeleccionados = idsGenerosSeleccionados.Any();

                if (hayTextoDeBusqueda && !hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Where(item => item.Titulo.Contains(tbBusqueda.Text));
                }
                else if (!hayTextoDeBusqueda && hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Include("GenerosPeliculas");
                    peliculas = peliculas.Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
                }
                else if (hayTextoDeBusqueda && hayGenerosSeleccionados)
                {
                    peliculas = peliculas.Include("GenerosPeliculas");
                    peliculas = peliculas.Where(item => item.Titulo.Contains(tbBusqueda.Text)).Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
                }

                if (peliculas.Count() == 0)
                {
                    pPeliculasNoEncontradas.InnerText = $"No se encontraron peliculas con el titulo {tbBusqueda.Text}";
                }
            }

            repPeliculas.DataSource = peliculas.ToList();
            repPeliculas.DataBind();
        }

        protected void repPeliculas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item;

            Literal titulo = (Literal)repeaterItem.FindControl("titulo");
            Literal fechaLanzamiento = (Literal)repeaterItem.FindControl("fechaLanzamiento");
            Image portada = (Image)repeaterItem.FindControl("portada");
            LinkButton ver = (LinkButton)repeaterItem.FindControl("btnVer");

            Pelicula pelicula = (Pelicula)repeaterItem.DataItem;
            PortadaPelicula portadaPelicula = pelicula.PortadaPelicula;

            titulo.Text = pelicula.Titulo;
            fechaLanzamiento.Text = pelicula.FechaLanzamiento.ToShortDateString();
            portada.ImageUrl = ResolveUrl($"{portadaPelicula.Ruta}/{portadaPelicula.Nombre}");
            ver.CommandArgument = pelicula.Id.ToString();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var peliculaId = btn.CommandArgument;

            Response.Redirect($"~/peliculas/ver.aspx?id={peliculaId}", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pPeliculasNoEncontradas.InnerText = string.Empty;

            var peliculas = _db.Peliculas.AsQueryable().Include("PortadaPelicula");
            var idsGenerosSeleccionados = generos.ObtenerIDsGenerosSeleccionados();

            bool hayTextoDeBusqueda = !string.IsNullOrEmpty(tbBusqueda.Text);
            bool hayGenerosSeleccionados = idsGenerosSeleccionados.Any();

            if (hayTextoDeBusqueda && !hayGenerosSeleccionados)
            {
                peliculas = peliculas.Where(item => item.Titulo.Contains(tbBusqueda.Text));
            }
            else if (!hayTextoDeBusqueda && hayGenerosSeleccionados)
            {
                peliculas = peliculas.Include("GenerosPeliculas");
                peliculas = peliculas.Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
            }
            else if (hayTextoDeBusqueda && hayGenerosSeleccionados)
            {
                peliculas = peliculas.Include("GenerosPeliculas");
                peliculas = peliculas.Where(item => item.Titulo.Contains(tbBusqueda.Text)).Where(p => p.GenerosPeliculas.Any(g => idsGenerosSeleccionados.Contains(g.GeneroId)));
            }

            if (peliculas.Count() == 0)
            {
                pPeliculasNoEncontradas.InnerText = $"No se encontraron peliculas con el titulo {tbBusqueda.Text}";
            }

            repPeliculas.DataSource = peliculas.ToList();
            repPeliculas.DataBind();
            upPeliculas.Update();
        }
    }
}