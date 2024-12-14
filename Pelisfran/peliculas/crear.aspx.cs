using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class crear : Page
    {
        private GeneroServicio _generoServicio = new GeneroServicio();
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private GeneroPeliculaServicio generoPeliculaServicio = new GeneroPeliculaServicio();
        private PortadaPeliculaServicio _portadaPeliculaServicio = new PortadaPeliculaServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rangeFechaLanzamiento.MinimumValue = DateTime.Now.AddYears(-100).ToShortDateString();
                rangeFechaLanzamiento.MaximumValue = DateTime.Now.ToShortDateString();
                rangeFechaLanzamiento.ErrorMessage = $"Debe estar entre {rangeFechaLanzamiento.MinimumValue} y {rangeFechaLanzamiento.MaximumValue}";
                repGeneros.DataSource = _generoServicio.ObtenerListaDeGeneros();
                repGeneros.DataBind();
            }
        }

        protected void repGeneros_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var cbGenero = (CheckBox)e.Item.FindControl("cbGenero");
            var genero = (Genero)e.Item.DataItem;

            cbGenero.Text = genero.Nombre;
            cbGenero.Attributes["data-value"] = genero.Id.ToString();
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

            reqPortada.InnerText = string.Empty;
            if (!ExistePortada())
            {
                reqPortada.InnerText = "Suba una portada";
                return;
            }

            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);

            Pelicula pelicula = new Pelicula
            {
                Id = Guid.NewGuid(),
                Titulo = txtTitulo.Text,
                SinopsisBreve = txtSinopsisBreve.Text,
                FechaLanzamiento = Convert.ToDateTime(txtFechaLanzamiento.Text),
                Duracion = Convert.ToInt16(txtDuracion.Text),
                CreadoEn = DateTime.Now,
                UsuarioId = usuarioId,
            };

            _peliculaServicio.CrearPelicula(pelicula);

            foreach (Genero genero in generosSeleccionados)
            {
                GeneroPelicula generoPelicula = new GeneroPelicula
                {
                    Id = Guid.NewGuid(),
                    PeliculaId = pelicula.Id,
                    GeneroId = genero.Id,
                    CreadoEn = DateTime.Now
                };
                generoPeliculaServicio.AgregarGeneroAPelicula(generoPelicula);
            }

            string carpetaDestino = $"~/Uploads/Portadas/Peliculas/{pelicula.Id}";
            var rutaAbsolutaCarpetaDestino = Server.MapPath($"~/Uploads/Portadas/Peliculas/{pelicula.Id}");

            var originalFileName = Request.Form["originalFileName"];
            var tempFileName = Request.Form["tempFileName"];

            FileInfo imagenPortada = new FileInfo(Server.MapPath($"~/Uploads/Temp/Portadas/Peliculas/{tempFileName}"));

            PortadaPelicula portada = new PortadaPelicula
            {
                Id = pelicula.Id,
                Nombre = tempFileName,
                NombreOriginal = originalFileName,
                Extension = imagenPortada.Extension,
                Ruta = carpetaDestino
            };
            if (!Directory.Exists(rutaAbsolutaCarpetaDestino))
            {
                Directory.CreateDirectory(rutaAbsolutaCarpetaDestino);
            }
            imagenPortada.MoveTo($"{rutaAbsolutaCarpetaDestino}/{tempFileName}");

            _portadaPeliculaServicio.AgregarPortadaAPelicula(portada);
            //_fileServicio.GuardarPortadaDeUnaPelicula(fuPortada, pelicula.Id);
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

        private bool ExistePortada()
        {
            return !string.IsNullOrEmpty(Request.Form["originalFileName"]) && !string.IsNullOrEmpty(Request.Form["tempFileName"]);
        }
    }
}