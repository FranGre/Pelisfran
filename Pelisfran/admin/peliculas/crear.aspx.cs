using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.peliculas
{
    public partial class crear : Base
    {
        private GeneroServicio _generoServicio = new GeneroServicio();
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private GeneroPeliculaServicio _generoPeliculaServicio = new GeneroPeliculaServicio();
        private PortadaPeliculaServicio _portadaPeliculaServicio = new PortadaPeliculaServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = _db.Usuarios.Where(u => u.Id == this.usuarioId).FirstOrDefault();
            bool esAdmin = (TipoRolesEnum)usuario.RolId == TipoRolesEnum.Administrador;

            if (!esAdmin)
            {
                Response.Redirect("~/peliculas/default.aspx", true);
                return;
            }

            if (!Page.IsPostBack)
            {
                rangeFechaLanzamiento.MinimumValue = DateTime.Now.AddYears(-100).ToShortDateString();
                rangeFechaLanzamiento.MaximumValue = DateTime.Now.ToShortDateString();
                rangeFechaLanzamiento.ErrorMessage = $"Debe estar entre {rangeFechaLanzamiento.MinimumValue} y {rangeFechaLanzamiento.MaximumValue}";
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

            var generosSeleccionados = generos.ObtenerGenerosSeleccionados();

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

            Pelicula pelicula = new Pelicula
            {
                Id = Guid.NewGuid(),
                Titulo = txtTitulo.Text,
                SinopsisBreve = txtSinopsisBreve.Text,
                FechaLanzamiento = Convert.ToDateTime(txtFechaLanzamiento.Text),
                Duracion = Convert.ToInt16(txtDuracion.Text),
                CreadoEn = DateTime.Now,
                UsuarioId = this.usuarioId,
            };

            _peliculaServicio.CrearPelicula(pelicula);

            _generoPeliculaServicio.AgregarGenerosAPelicula(generosSeleccionados, pelicula);

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
            // TODO - refactorizar 
            if (!Directory.Exists(rutaAbsolutaCarpetaDestino))
            {
                Directory.CreateDirectory(rutaAbsolutaCarpetaDestino);
            }
            imagenPortada.MoveTo($"{rutaAbsolutaCarpetaDestino}/{tempFileName}");

            _portadaPeliculaServicio.AgregarPortadaAPelicula(portada);
            //_fileServicio.GuardarPortadaDeUnaPelicula(fuPortada, pelicula.Id);
        }

        private bool ExistePortada()
        {
            return !string.IsNullOrEmpty(Request.Form["originalFileName"]) && !string.IsNullOrEmpty(Request.Form["tempFileName"]);
        }
    }
}