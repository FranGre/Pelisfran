using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Pelisfran.Modelos
{
    public class PortadaSerie
    {
        [ForeignKey("Serie")]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NombreOriginal { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string Ruta { get; set; }
        public Serie Serie { get; set; }
    }
}