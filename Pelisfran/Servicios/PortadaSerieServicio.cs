using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class PortadaSerieServicio
    {
        private PortadaSerieRepositorio _portadaSerieRepositorio;

        public PortadaSerieServicio()
        {
            _portadaSerieRepositorio = new PortadaSerieRepositorio();
        }

        public void AgregarPortadaASerie(PortadaSerie portadaSerie)
        {
            _portadaSerieRepositorio.Crear(portadaSerie);
        }
    }
}