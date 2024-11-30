using Pelisfran.Contexto;
using Pelisfran.Modelos;

namespace Pelisfran.Repositorios
{
    public class TemporadaRepositorio
    {
        private PelisFranDBContexto _db;

        public TemporadaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Temporada temporada)
        {
            _db.Temporadas.Add(temporada);
            _db.SaveChanges();
        }
    }
}