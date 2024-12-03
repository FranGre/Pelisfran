using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;

namespace Pelisfran.Repositorios
{
    public class PortadaSerieRepositorio
    {
        private PelisFranDBContexto _db;

        public PortadaSerieRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(PortadaSerie portadaSerie)
        {
            _db.PortadasSeries.Add(portadaSerie);
            _db.SaveChanges();
        }

        public PortadaSerie Obtener(Guid portadaSerieId)
        {
            return _db.PortadasSeries.Find(portadaSerieId);
        }
    }
}