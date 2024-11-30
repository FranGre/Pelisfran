using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System;

namespace Pelisfran.Servicios
{
    public class TemporadaServicio
    {
        private TemporadaRepositorio _temporadaRepositorio;

        public TemporadaServicio()
        {
            _temporadaRepositorio = new TemporadaRepositorio();
        }

        public void CrearTemporada(Temporada temporada)
        {
            _temporadaRepositorio.Crear(temporada);
        }
    }
}