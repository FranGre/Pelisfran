using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class GeneroSerieServicio
    {
        private GeneroSerieRepositorio _generoSerieRepositorio;

        public GeneroSerieServicio()
        {
            _generoSerieRepositorio = new GeneroSerieRepositorio();
        }

        public void AgregarGeneroASerie(GeneroSerie generoSerie)
        {
            _generoSerieRepositorio.Crear(generoSerie);
        }
    }
}