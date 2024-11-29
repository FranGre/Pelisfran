using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class SerieServicio
    {
        private SerieRepositorio _serieRepositorio;

        public SerieServicio()
        {
            _serieRepositorio = new SerieRepositorio();
        }

        public void CrearSerie(Serie serie)
        {
            _serieRepositorio.Crear(serie);
        }
    }
}