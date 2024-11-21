using Pelisfran.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("Roles")]
    public class Rol
    {
        public int Id { get; set; }
        [Required]
        public TipoRolesEnum Tipo { get; set; }
        [Required, MaxLength(30)]
        public string Nombre { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}