using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.series
{
    public partial class crear : Page
    {
        private GeneroServicio _generoServicio = new GeneroServicio();
        private SerieServicio _serieServicio = new SerieServicio();
        private GeneroSerieServicio _generoSerieServicio = new GeneroSerieServicio();
        private TemporadaServicio _temporadaServicio = new TemporadaServicio();
        private PortadaSerieServicio _portadaSerieServicio = new PortadaSerieServicio();
        private FileServicio _fileServicio = new FileServicio();

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
                repGeneros.DataSource = _generoServicio.ObtenerListaDeGeneros();
                repGeneros.DataBind();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            var generosSeleccionados = ObtenerGenerosSeleccionados();

            reqGeneros.InnerText = string.Empty;
            if (generosSeleccionados.Count == 0)
            {
                reqGeneros.InnerText = "Debes escoger minimo un genero";
                return;
            }

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

            foreach (Genero genero in generosSeleccionados)
            {
                GeneroSerie generoSerie = new GeneroSerie
                {
                    Id = Guid.NewGuid(),
                    SerieId = serie.Id,
                    GeneroId = genero.Id,
                    CreadoEn = DateTime.Now
                };
                _generoSerieServicio.AgregarGeneroASerie(generoSerie);
            }

            string carpetaDestino = $"~/Uploads/Portadas/Series/{serie.Id}";
            PortadaSerie portadaSerie = new PortadaSerie
            {
                Id = serie.Id,
                Nombre = fuPortada.FileName,
                Extension = Path.GetExtension(fuPortada.FileName),
                NombreOriginal = fuPortada.FileName,
                Ruta = carpetaDestino
            };

            _portadaSerieServicio.AgregarPortadaASerie(portadaSerie);
            _fileServicio.GuardarPortadaDeUnaSerie(fuPortada, serie.Id);

            byte numeroTemporadas = Convert.ToByte(txtNumeroTemporadas.Text);
            for (byte i = 1; i <= numeroTemporadas; i++)
            {
                Temporada temporada = new Temporada
                {
                    Id = Guid.NewGuid(),
                    NumeroTemporada = i,
                    CreadoEn = DateTime.Now,
                    UsuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name),
                    SerieId = serie.Id
                };

                _temporadaServicio.CrearTemporada(temporada);
            }
        }

        protected void repGeneros_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var cbGenero = (CheckBox)e.Item.FindControl("cbGenero");
            var genero = (Genero)e.Item.DataItem;

            cbGenero.Text = genero.Nombre;
            cbGenero.Attributes["data-value"] = genero.Id.ToString();
        }

        private List<Genero> ObtenerGenerosSeleccionados()
        {
            var generosSeleccionados = new List<Genero>();
            foreach (var item in repGeneros.Items)
            {
                RepeaterItem repeaterItem = (RepeaterItem)item;
                CheckBox cbGenero = (CheckBox)repeaterItem.FindControl("cbGenero");
                if (cbGenero.Checked)
                {
                    Genero genero = new Genero
                    {
                        Id = Guid.Parse(cbGenero.Attributes["data-value"]),
                        Nombre = cbGenero.Text
                    };
                    generosSeleccionados.Add(genero);
                }
            }
            return generosSeleccionados;
        }
    }
}