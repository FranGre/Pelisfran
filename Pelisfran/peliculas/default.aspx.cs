using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class _default : System.Web.UI.Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var peliculas = _db.Peliculas.Include("PortadaPelicula").ToList();
                repPeliculas.DataSource = peliculas;
                repPeliculas.DataBind();
            }
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

            var peliculas = _db.Peliculas.Include("PortadaPelicula");

            if (!string.IsNullOrEmpty(tbBusqueda.Text))
            {
                peliculas = (DbQuery<Pelicula>)peliculas.Where(item => item.Titulo.Contains(tbBusqueda.Text));
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