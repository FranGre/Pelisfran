using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelisfran.Modelos
{
    [Table("PortadasPeliculas")]
    public class PortadaPelicula
    {
    [ForeignKey("Pelicula")]
    public Guid Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string NombreOriginal { get; set; }
    [Required]
    public string Extension { get; set; }
    [Required]
    public string Ruta { get; set; }
    public Pelicula Pelicula { get; set; }
    }
}