using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Pelisfran.Repositorios
{
    public class GeneroRepositorio
    {
        private PelisFranDBContexto _db;

        public GeneroRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Genero genero)
        {
            _db.Generos.Add(genero);
            _db.SaveChanges();
        }

        public List<Genero> ObtenerGeneros()
        {
            return _db.Generos.ToList();
        }
    }
}