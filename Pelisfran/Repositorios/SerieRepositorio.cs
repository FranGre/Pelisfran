using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class SerieRepositorio
    {
        private PelisFranDBContexto _db;

        public SerieRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Serie serie)
        {
            _db.Series.Add(serie);
            _db.SaveChanges();
        }
    }
}