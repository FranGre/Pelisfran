using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System.Collections.Generic;
using System;

namespace Pelisfran.Servicios
{
    public class GeneroPeliculaServicio
    {
        private GeneroPeliculaRepositorio _generoPeliculaRepositorio;

        public GeneroPeliculaServicio()
        {
            _generoPeliculaRepositorio = new GeneroPeliculaRepositorio();
        }

        public void AgregarGeneroAPelicula(GeneroPelicula generoPelicula)
        {
            _generoPeliculaRepositorio.Crear(generoPelicula);
        }

        public void AgregarGenerosAPelicula(List<Genero> generos, Pelicula pelicula)
        {
            foreach (Genero genero in generos)
            {
                GeneroPelicula generoPelicula = new GeneroPelicula
                {
                    Id = Guid.NewGuid(),
                    PeliculaId = pelicula.Id,
                    GeneroId = genero.Id,
                    CreadoEn = DateTime.Now
                };
                AgregarGeneroAPelicula(generoPelicula);
            }
        }
    }
}