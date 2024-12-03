using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System;

namespace Pelisfran.Servicios
{
    public class PortadaSerieServicio
    {
        private PortadaSerieRepositorio _portadaSerieRepositorio;

        public PortadaSerieServicio()
        {
            _portadaSerieRepositorio = new PortadaSerieRepositorio();
        }

        public PortadaSerie ObtenerPortada(Guid portadaSerieId)
        {
            return _portadaSerieRepositorio.Obtener(portadaSerieId);
        }

        public void AgregarPortadaASerie(PortadaSerie portadaSerie)
        {
            _portadaSerieRepositorio.Crear(portadaSerie);
        }
    }
}