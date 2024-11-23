using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System.Collections.Generic;

namespace Pelisfran.Servicios
{
    public class GeneroServicio
    {
        private GeneroRepositorio _generoRepositorio;

        public GeneroServicio()
        {
            _generoRepositorio = new GeneroRepositorio();
        }

        public void CrearGenero(Genero genero)
        {
            _generoRepositorio.Crear(genero);
        }

        public List<Genero> ObtenerListaDeGeneros()
        {
            return _generoRepositorio.ObtenerGeneros();
        }
    }
}