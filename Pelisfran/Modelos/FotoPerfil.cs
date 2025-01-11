using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pelisfran.Modelos
{
    [Table("FotosPerfil")]
    public class FotoPerfil
    {
        [ForeignKey("Usuario")]
        public Guid Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string NombreOriginal { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string Ruta { get; set; }
        public Usuario Usuario { get; set; }
    }
}