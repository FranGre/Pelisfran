using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System.Collections.Generic;

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

        public List<Serie> ObtenerSeries()
        {
            return _serieRepositorio.Obtener();
        }
    }
}