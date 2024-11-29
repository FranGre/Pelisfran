using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class Temporada
    {
        public Guid Id { get; set; }
        [Required]
        public byte NumeroTemporada { get; set; }
        public string SinopsisBreve { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Serie")]
        public Guid SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}