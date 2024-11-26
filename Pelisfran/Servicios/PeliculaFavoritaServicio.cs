using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class PeliculaFavoritaServicio
    {
        private PeliculaFavoritaRepositorio _peliculaFavoritaRepositorio;

        public PeliculaFavoritaServicio()
        {
            _peliculaFavoritaRepositorio = new PeliculaFavoritaRepositorio();
        }

        public void MarcarPeliculaComoFavorita(PeliculaFavorita peliculaFavorita)
        {
            _peliculaFavoritaRepositorio.Crear(peliculaFavorita);
        }
    }
}