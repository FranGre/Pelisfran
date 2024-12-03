using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web.UI;

namespace Pelisfran.series
{
    public partial class ver : Page
    {
        private SerieServicio _serieServicio = new SerieServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Guid serieId = Guid.Parse(Request.QueryString["id"]);
                Serie serie = _serieServicio.ObtenerSerie(serieId);

                titulo.InnerText = serie.Titulo;
                descripcion.InnerText = serie.SinopsisBreve;
                hfId.Value = serie.Id.ToString();
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {

        }
    }
}