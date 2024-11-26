using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class PeliculaFavoritaRepositorio
    {
        private PelisFranDBContexto _db;

        public PeliculaFavoritaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(PeliculaFavorita peliculaFavorita)
        {
            _db.PeliculasFavoritas.Add(peliculaFavorita);
            _db.SaveChanges();
        }
    }
}