using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;

namespace Pelisfran.Repositorios
{
    public class SerieFavoritaRepositorio
    {
        private PelisFranDBContexto _db;

        public SerieFavoritaRepositorio()
        {
            _db = new PelisFranDBContexto();
        }

        public void Crear(SerieFavorita serieFavorita)
        {
            _db.SeriesFavoritas.Add(serieFavorita);
            _db.SaveChanges();
        }

        public void Eliminar(Guid usuarioId, Guid serieId)
        {
            SerieFavorita serieFavorita = _db.SeriesFavoritas.Where(item => item.UsuarioId == usuarioId && item.SerieId == serieId).FirstOrDefault();

            _db.SeriesFavoritas.Remove(serieFavorita);
            _db.SaveChanges();
        }

        public bool ExisteSerieFavorita(Guid usuarioId, Guid serieId)
        {
            return _db.SeriesFavoritas.Where(item => item.UsuarioId == usuarioId && item.SerieId == serieId).FirstOrDefault() != null ? true : false;
        }
    }
}