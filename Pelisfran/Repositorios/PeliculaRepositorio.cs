using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;

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

        public Pelicula ObtenerConPortadaPorId(Guid peliculaId)
        {
            return _db.Peliculas.Include("PortadaPelicula").Where(item => item.Id == peliculaId).FirstOrDefault();
        }
    }
}