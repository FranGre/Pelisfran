using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("SeriesFavoritas")]
    public class SerieFavorita
    {
        public Guid Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Serie")]
        public Guid SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}