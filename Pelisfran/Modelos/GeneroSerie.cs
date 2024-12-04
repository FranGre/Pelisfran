using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Pelisfran.Modelos
{
    [Table("GenerosSeries")]
    public class GeneroSerie
    {
        public Guid Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Genero")]
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }
        [ForeignKey("Serie")]
        public Guid SerieId { get; set; }
        public Serie Serie { get; set; }
    }
}