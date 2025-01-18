using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class ComentarioPelicula
    {
        public Guid Id { get; set; }
        [Required, MaxLength(255)]
        public string Comentario { get; set; }
        [Required]
        public bool Visible { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        [ForeignKey("Pelicula")]
        public Guid PeliculaId { get; set; }
        public virtual Pelicula Pelicula { get; set; }
    }
}