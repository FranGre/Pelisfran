using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class Serie
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string SinopsisBreve { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}