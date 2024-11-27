using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System;

namespace Pelisfran.Servicios
{
    public class PeliculaServicio
    {
        private PeliculaRepositorio _peliculaRepositorio;

        public PeliculaServicio()
        {
            _peliculaRepositorio = new PeliculaRepositorio();
        }

        public void CrearPelicula(Pelicula pelicula)
        {
            _peliculaRepositorio.Crear(pelicula);
        }

        public Pelicula ObtenerPelicula(Guid id)
        {
            return _peliculaRepositorio.ObtenerPorId(id);
        }

        public Pelicula ObtenerPeliculaIncluidaPortada(Guid peliculaId)
        {
            return _peliculaRepositorio.ObtenerConPortadaPorId(peliculaId);
        }
    }
}