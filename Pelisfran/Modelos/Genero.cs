using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("Generos")]
    public class Genero
    {
        public Guid Id { get; set; }
        [Required, MaxLength(40)]
        public string Tipo { get; set; }
        [Required]
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<GeneroPelicula> GenerosPeliculas { get; set; }
    }
}