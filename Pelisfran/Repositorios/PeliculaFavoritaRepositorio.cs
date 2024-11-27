using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pelisfran.Repositorios
{
    public class PeliculaFavoritaRepositorio
    {
        private PelisFranDBContexto _db;

        public PeliculaFavoritaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(PeliculaFavorita peliculaFavorita)
        {
            _db.PeliculasFavoritas.Add(peliculaFavorita);
            _db.SaveChanges();
        }

        public bool ExistePeliculaFavorita(Guid usuarioId, Guid peliculaId)
        {
            return _db.PeliculasFavoritas.Where(item => item.UsuarioId == usuarioId && item.PeliculaId == peliculaId).FirstOrDefault() != null;
        }

        public void Eliminar(Guid usuarioId, Guid peliculaId)
        {
            PeliculaFavorita peliculaFavorita = _db.PeliculasFavoritas.Where(item => item.UsuarioId == usuarioId && item.PeliculaId == peliculaId).FirstOrDefault();

            _db.PeliculasFavoritas.Remove(peliculaFavorita);
            _db.SaveChanges();
        }

        public List<PeliculaFavorita> ObtenerPeliculasFavoritasPorUsuario(Guid usuarioId)
        {
            return _db.PeliculasFavoritas.Where(peliculaFavorita => peliculaFavorita.UsuarioId == usuarioId).ToList();
        }
    }
}