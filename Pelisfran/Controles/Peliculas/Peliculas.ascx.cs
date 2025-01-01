using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.Controles.Peliculas
{
    public partial class Peliculas : UserControl
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        public List<Pelicula> peliculas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Cargar(peliculas);
            }
        }

        public void Cargar(List<Pelicula> peliculas)
        {
            this.peliculas = peliculas;

            pPeliculasNoEncontradas.InnerText = string.Empty;
            if (!peliculas.Any())
            {
                pPeliculasNoEncontradas.InnerText = $"No se encontraron peliculas";
            }

            repPeliculas.DataSource = peliculas;
            repPeliculas.DataBind();
        }

        protected void repPeliculas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem repeaterItem = e.Item;

            Label titulo = (Label)repeaterItem.FindControl("titulo");
            Image portada = (Image)repeaterItem.FindControl("portada");
            LinkButton ver = (LinkButton)repeaterItem.FindControl("btnVer");

            Pelicula pelicula = (Pelicula)repeaterItem.DataItem;
            PortadaPelicula portadaPelicula = pelicula.PortadaPelicula;

            titulo.Text = pelicula.Titulo;
            portada.ImageUrl = ResolveUrl($"{portadaPelicula.Ruta}/{portadaPelicula.Nombre}");
            ver.CommandArgument = pelicula.Id.ToString();
        }

        protected void btnVer_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton)sender;
            var peliculaId = btn.CommandArgument;

            VisitaPelicula visita = new VisitaPelicula
            {
                Id = Guid.NewGuid(),
                FechaCreacion = DateTime.Now,
                PeliculaId = Guid.Parse(peliculaId),
            };

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                visita.UsuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            }

            _db.VisitasPeliculas.Add(visita);
            _db.SaveChanges();

            Response.Redirect($"~/peliculas/ver.aspx?id={peliculaId}", false);
        }
    }
}