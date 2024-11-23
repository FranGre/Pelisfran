using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class PeliculaServicio
    {
        private PeliculaRepositorio _peliculaRepositorio;

        public PeliculaServicio()
        {
            _peliculaRepositorio = new PeliculaRepositorio();
        }

        public void CrearPelicula(Pelicula pelicula)
        {
            _peliculaRepositorio.Crear(pelicula);
        }
    }
}