using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class GeneroServicio
    {
        private GeneroRepositorio _generoRepositorio;

        public GeneroServicio()
        {
            _generoRepositorio = new GeneroRepositorio();
        }

        public void CrearGenero(Genero genero)
        {
            _generoRepositorio.Crear(genero);
        }
    }
}