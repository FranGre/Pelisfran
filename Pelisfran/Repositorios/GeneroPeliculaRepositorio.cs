using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class GeneroPeliculaRepositorio
    {
        private PelisFranDBContexto _db;

        public GeneroPeliculaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(GeneroPelicula generoPelicula)
        {
            _db.GenerosPeliculas.Add(generoPelicula);
            _db.SaveChanges();
        }
    }
}