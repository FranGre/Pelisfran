using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class GeneroSerieRepositorio
    {
        private PelisFranDBContexto _db;

        public GeneroSerieRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(GeneroSerie generoSerie)
        {
            _db.GenerosSeries.Add(generoSerie);
            _db.SaveChanges();
        }
    }
}