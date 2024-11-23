using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class GeneroPeliculaServicio
    {
        private GeneroPeliculaRepositorio _generoPeliculaRepositorio;

        public GeneroPeliculaServicio()
        {
            _generoPeliculaRepositorio = new GeneroPeliculaRepositorio();
        }

        public void AgregarGeneroAPelicula(GeneroPelicula generoPelicula)
        {
            _generoPeliculaRepositorio.Crear(generoPelicula);
        }
    }
}