using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System;

namespace Pelisfran.Servicios
{
    public class SerieFavoritaServicio
    {
        private SerieFavoritaRepositorio _serieFavoritaRepositorio;

        public SerieFavoritaServicio()
        {
            _serieFavoritaRepositorio = new SerieFavoritaRepositorio();
        }

        public void MarcarSerieComoFavorita(SerieFavorita serieFavorita)
        {
            _serieFavoritaRepositorio.Crear(serieFavorita);
        }

        public void DesmarcarSerieComoFavorita(Guid usuarioId, Guid serieId)
        {
            _serieFavoritaRepositorio.Eliminar(usuarioId, serieId);
        }

        public bool SerieEstaMarcadaComoFavorita(Guid usuarioId, Guid serieId)
        {
            return _serieFavoritaRepositorio.ExisteSerieFavorita(usuarioId, serieId);
        }

    }
}