using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class PortadaPeliculaRepositorio
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        public void Crear(PortadaPelicula portadaPelicula)
        {
            _db.PortadasPeliculas.Add(portadaPelicula);
            _db.SaveChanges();
        }
    }
}