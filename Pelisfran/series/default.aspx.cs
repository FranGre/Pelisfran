using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.series
{
    public partial class _default : Page
    {
        private SerieServicio _serieServicio = new SerieServicio();
        private PortadaSerieServicio _portadaSerieServicio = new PortadaSerieServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                repSeries.DataSource = _serieServicio.ObtenerSeries();
                repSeries.DataBind();
            }
        }

        protected void imgbPortada_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void repSeries_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = (e.Item);

            ImageButton portada = (ImageButton)repeaterItem.FindControl("imgbPortada");
            Label nombre = (Label)repeaterItem.FindControl("lbNombre");

            Serie serie = (Serie)repeaterItem.DataItem;
            PortadaSerie portadaSerie = _portadaSerieServicio.ObtenerPortada(serie.Id);

            portada.ImageUrl = ResolveUrl($"{portadaSerie.Ruta}/{portadaSerie.NombreOriginal}");
            nombre.Text = serie.Titulo;

        }
    }
}