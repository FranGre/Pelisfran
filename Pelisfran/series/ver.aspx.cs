using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;

namespace Pelisfran.series
{
    public partial class ver : Page
    {
        private SerieServicio _serieServicio = new SerieServicio();
        private SerieFavoritaServicio _serieFavoritaServicio = new SerieFavoritaServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Guid serieId = Guid.Parse(Request.QueryString["id"]);
                Serie serie = _serieServicio.ObtenerSerie(serieId);
                Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);

                btnFavorito.Text = "Agregar a favoritos";
                if (_serieFavoritaServicio.SerieEstaMarcadaComoFavorita(usuarioId, serie.Id))
                {
                    btnFavorito.Text = "Eliminar de favoritos";
                }

                titulo.InnerText = serie.Titulo;
                descripcion.InnerText = serie.SinopsisBreve;
                hfId.Value = serie.Id.ToString();
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Guid serieId = Guid.Parse(Request.QueryString["id"]);
            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);

            if (!_serieFavoritaServicio.SerieEstaMarcadaComoFavorita(usuarioId, serieId))
            {
                SerieFavorita serieFavorita = new SerieFavorita
                {
                    Id = Guid.NewGuid(),
                    CreadoEn = DateTime.Now,
                    SerieId = serieId,
                    UsuarioId = usuarioId
                };

                _serieFavoritaServicio.MarcarSerieComoFavorita(serieFavorita);
                btnFavorito.Text = "Eliminar de favoritos";
                upBotonFavorito.Update();
                return;
            }

            _serieFavoritaServicio.DesmarcarSerieComoFavorita(usuarioId, serieId);
            btnFavorito.Text = "Agregar a favoritos";
            upBotonFavorito.Update();
        }
    }
}