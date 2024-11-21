using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("GenerosPeliculas")]
    public class GeneroPelicula
    {
        public Guid Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Genero")]
        public Guid GeneroId { get; set; }
        public Genero Genero { get; set; }
        [ForeignKey("Pelicula")]
        public Guid PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}