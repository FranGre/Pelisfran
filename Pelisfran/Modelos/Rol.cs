using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("Roles")]
    public class Rol
    {
        public Guid Id { get; set; }
        [Required, MaxLength(30)]
        public string Tipo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }
    }
}