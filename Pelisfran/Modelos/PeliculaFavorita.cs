using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("PeliculasFavoritas")]
    public class PeliculaFavorita
    {
        public Guid Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Pelicula")]
        public Guid PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}