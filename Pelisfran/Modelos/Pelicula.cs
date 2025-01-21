using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    public class Pelicula
    {
        public Guid Id { get; set; }
        [Required, MaxLength(50)]
        public string Titulo { get; set; }
        [Required, MaxLength(1000)]
        public string SinopsisBreve { get; set; }
        [Required]
        public DateTime FechaLanzamiento { get; set; }
        [Required]
        public short Duracion { get; set; }
        [Required]
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        [ForeignKey("Usuario")]
        public Guid? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public PortadaPelicula PortadaPelicula { get; set; }
        public ICollection<GeneroPelicula> GenerosPeliculas { get; set; }
        public ICollection<PeliculaFavorita> PeliculaFavoritas { get; set; }
        public ICollection<ComentarioPelicula> ComentarioPeliculas { get; set; }
        public ICollection<PeliculaLike> PeliculasLikes { get; set; }
        public ICollection<VisitaPelicula> VisitasPeliculas { get; set; }
    }
}