using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;

namespace Pelisfran.Repositorios
{
    public class PeliculaRepositorio
    {
        private PelisFranDBContexto _db;

        public PeliculaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(Pelicula pelicula)
        {
            _db.Peliculas.Add(pelicula);
            _db.SaveChanges();
        }

        public Pelicula ObtenerPorId(Guid id)
        {
            return _db.Peliculas.Find(id);
        }
    }
}