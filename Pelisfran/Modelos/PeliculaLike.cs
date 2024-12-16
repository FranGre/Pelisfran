using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class PeliculaLike
    {
        public Guid Id { get; set; }
        public DateTime CreadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Pelicula")]
        public Guid PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}