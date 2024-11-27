using Pelisfran.Modelos;
using Pelisfran.Repositorios;
using System;
using System.Collections.Generic;

namespace Pelisfran.Servicios
{
    public class PeliculaFavoritaServicio
    {
        private PeliculaFavoritaRepositorio _peliculaFavoritaRepositorio;

        public PeliculaFavoritaServicio()
        {
            _peliculaFavoritaRepositorio = new PeliculaFavoritaRepositorio();
        }

        public void MarcarPeliculaComoFavorita(PeliculaFavorita peliculaFavorita)
        {
            _peliculaFavoritaRepositorio.Crear(peliculaFavorita);
        }

        public bool PeliculaEstaMarcadaComoFavorita(Guid usuarioId, Guid peliculaId)
        {
            return _peliculaFavoritaRepositorio.ExistePeliculaFavorita(usuarioId, peliculaId);
        }

        public void DesmarcarPeliculaComoFavorita(Guid usuarioId, Guid peliculaId)
        {
            _peliculaFavoritaRepositorio.Eliminar(usuarioId, peliculaId);
        }

        public List<PeliculaFavorita> ObtenerPeliculasMarcadasComoFavoritasDelUsuario(Guid usuarioId)
        {
            return _peliculaFavoritaRepositorio.ObtenerPeliculasFavoritasPorUsuario(usuarioId);
        }
    }
}