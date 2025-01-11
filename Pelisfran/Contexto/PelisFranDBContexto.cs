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
        public DbSet<GeneroPelicula> GenerosPeliculas { get; set; }
        public DbSet<GeneroSerie> GenerosSeries { get; set; }
        public DbSet<PeliculaFavorita> PeliculasFavoritas { get; set; }
        public DbSet<PortadaSerie> PortadasSeries { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<SerieFavorita> SeriesFavoritas { get; set; }
        public DbSet<ComentarioPelicula> ComentariosPeliculas { get; set; }
        public DbSet<PeliculaLike> PeliculasLikes { get; set; }
        public DbSet<VisitaPelicula> VisitasPeliculas { get; set; }
        public DbSet<FotoPerfil> FotosPerfiles { get; set; }

        public PelisFranDBContexto() : base(CrearConexion(), true) { }

        static DbConnection CrearConexion()
        {
            var conexion = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["PelisFranConexion"].ProviderName).CreateConnection();
            conexion.ConnectionString = ConfigurationManager.ConnectionStrings["PelisFranConexion"].ConnectionString;
            return conexion;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>()
                .HasOptional(pelicula => pelicula.PortadaPelicula)
                .WithRequired(portadaPelicula => portadaPelicula.Pelicula);

            base.OnModelCreating(modelBuilder);
        }
    }
}