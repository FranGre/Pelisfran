using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class crear : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private PeliculaServicio _peliculaServicio = new PeliculaServicio();
        private GeneroPeliculaServicio generoPeliculaServicio = new GeneroPeliculaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var generos = _db.Generos.ToList();

                repGeneros.DataSource = generos;
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
        }
    }
}