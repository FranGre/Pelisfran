using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class PortadaPeliculaServicio
    {
        private PortadaPeliculaRepositorio _peliculaRepositorio;

        public PortadaPeliculaServicio()
        {
            _peliculaRepositorio = new PortadaPeliculaRepositorio();
        }

        public void AgregarPortadaAPelicula(PortadaPelicula portadaPelicula)
        {
            _peliculaRepositorio.Crear(portadaPelicula);
        }
    }
}