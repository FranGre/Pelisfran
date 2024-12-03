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
            if (!Page.IsPostBack)
            {
                repSeries.DataSource = _serieServicio.ObtenerSeries();
                repSeries.DataBind();
            }
        }

        protected void repSeries_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item;

            Literal titulo = (Literal)repeaterItem.FindControl("titulo");
            Literal fechaLanzamiento = (Literal)repeaterItem.FindControl("fechaLanzamiento");
            Image portada = (Image)repeaterItem.FindControl("portada");
            LinkButton ver = (LinkButton)repeaterItem.FindControl("btnVer");

            Serie serie = (Serie)repeaterItem.DataItem;
            PortadaSerie portadaSerie = _portadaSerieServicio.ObtenerPortada(serie.Id);

            portada.ImageUrl = ResolveUrl($"{portadaSerie.Ruta}/{portadaSerie.NombreOriginal}");
            titulo.Text = serie.Titulo;
            fechaLanzamiento.Text = serie.FechaLanzamiento.ToShortDateString();
            ver.CommandArgument = serie.Id.ToString();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string serieId = btn.CommandArgument;
            Response.Redirect($"~/series/ver.aspx?id={serieId}");
        }
    }
}