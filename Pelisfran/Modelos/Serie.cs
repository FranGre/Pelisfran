using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class Serie
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Titulo { get; set; }
        [Required, MaxLength(350)]
        public string SinopsisBreve { get; set; }
        [Required]
        public DateTime FechaLanzamiento { get; set; }
        [Required]
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Temporada> Temporadas { get; set; }
    }
}