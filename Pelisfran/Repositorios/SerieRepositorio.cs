using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System.Collections.Generic;
using System.Linq;

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
        public List<Serie> Obtener()
        {
            return _db.Series.ToList();
        }
    }
}