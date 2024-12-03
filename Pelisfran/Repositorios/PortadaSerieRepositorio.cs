using Pelisfran.Contexto;
using Pelisfran.Modelos;

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
    }
}