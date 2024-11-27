using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Pelisfran.peliculas
{
    public partial class favoritas : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private PeliculaFavoritaServicio _peliculaFavoritaServicio = new PeliculaFavoritaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            List<PeliculaFavorita> misPeliculasFavoritas = _peliculaFavoritaServicio.ObtenerPeliculasMarcadasComoFavoritasDelUsuario(usuarioId);
            repPeliculas.DataSource = misPeliculasFavoritas;
            repPeliculas.DataBind();
        }

        protected void repPeliculas_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Image portada = (Image)e.Item.FindControl("portada");
            HtmlGenericControl titulo = (HtmlGenericControl)e.Item.FindControl("titulo");

            PeliculaFavorita miPeliculaFavorita = (PeliculaFavorita)e.Item.DataItem;
            Pelicula pelicula = _db.Peliculas.Include("PortadaPelicula").Where(item => item.Id == miPeliculaFavorita.PeliculaId).FirstOrDefault();

            var imageUrl = ResolveUrl($"{pelicula.PortadaPelicula.Ruta}/{pelicula.PortadaPelicula.NombreOriginal}");
            portada.ImageUrl = imageUrl;
            titulo.InnerText = pelicula.Titulo;
        }
    }
}