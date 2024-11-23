using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class PeliculaRepositorio
    {
        private PelisFranDBContexto _db;

        public PeliculaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Pelicula pelicula)
        {
            _db.Peliculas.Add(pelicula);
            _db.SaveChanges();
        }
    }
}