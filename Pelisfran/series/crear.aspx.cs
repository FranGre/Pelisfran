using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using Pelisfran.Servicios;
using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.series
{
    public partial class crear : Page
    {
        private SerieServicio _serieServicio = new SerieServicio();
        PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime fechaActual = DateTime.Now;
                DateTime fechaLanzamientoMinima = fechaActual.AddYears(-120);
                DateTime fechaLanzamientoMaxima = fechaActual.AddYears(3);
                rangeFechaLanzamiento.MinimumValue = fechaLanzamientoMinima.ToShortDateString();
                rangeFechaLanzamiento.MaximumValue = fechaLanzamientoMaxima.ToShortDateString();

                rangeFechaLanzamiento.ErrorMessage = $"Debe estar entre {fechaLanzamientoMinima.ToShortDateString()} y {fechaLanzamientoMaxima.ToShortDateString()}";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            Serie serie = new Serie
            {
                Id = Guid.NewGuid(),
                Titulo = txtTitulo.Text,
                SinopsisBreve = txtSinopsis.Text,
                FechaLanzamiento = Convert.ToDateTime(txtFechaLanzamiento.Text),
                CreadoEn = DateTime.Now,
                UsuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name)
            };

            _serieServicio.CrearSerie(serie);
        }
    }
}