using Pelisfran.Contexto;
using Pelisfran.Modelos;

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
    }
}