using Pelisfran.Modelos;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;

namespace Pelisfran.Contexto
{
    public class PelisFranDBContexto : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<PortadaPelicula> PortadasPeliculas { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }

        public PelisFranDBContexto() : base(CrearConexion(), true) { }

        static DbConnection CrearConexion()
        {
            var conexion = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["PelisFranConexion"].ProviderName).CreateConnection();
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["PelisFranConexion"].ConnectionString;
            return conexion;
        }
    }
}