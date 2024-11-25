using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
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
                var peliculas = _db.Peliculas.ToList();
                repPeliculas.DataSource = peliculas;
                repPeliculas.DataBind();
            }
        }

        protected void repPeliculas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item;

            Literal titulo = (Literal)repeaterItem.FindControl("titulo");
            Literal fechaLanzamiento = (Literal)repeaterItem.FindControl("fechaLanzamiento");

            Pelicula pelicula = (Pelicula)repeaterItem.DataItem;

            titulo.Text = pelicula.Titulo;
            fechaLanzamiento.Text = pelicula.FechaLanzamiento.ToShortDateString();
        }
    }
}