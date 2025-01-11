using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pelisfran.Modelos
{
    public class Usuario
    {
        public Guid Id { get; set; }
        [Required, MaxLength(20)]
        public string NombreUsuario { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellidos { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public DateTime CreadoEn { get; set; }
        public DateTime? ActualizadoEn { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public ICollection<Genero> Generos { get; set; }
        public ICollection<PeliculaFavorita> PeliculaFavoritas { get; set; }
        public ICollection<SerieFavorita> SerieFavoritas { get; set; }
        public ICollection<Pelicula> Peliculas { get; set; }
        public ICollection<Serie> Series { get; set; }
        public ICollection<Temporada> Temporadas { get; set; }
        public ICollection<ComentarioPelicula> ComentariosPeliculas { get; set; }
        public ICollection<PeliculaLike> PeliculasLikes { get; set; }
        public FotoPerfil FotoPerfil { get; set; }
    }
}