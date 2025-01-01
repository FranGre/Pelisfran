using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class VisitaPelicula
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("Pelicula")]
        public Guid PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }

        [ForeignKey("Usuario")]
        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}