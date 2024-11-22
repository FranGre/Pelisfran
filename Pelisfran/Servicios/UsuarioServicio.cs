using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class UsuarioServicio
    {
        private UsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            usuarioRepositorio.Crear(usuario);
        }

        public bool ExisteUsuarioRegistrado(string email)
        {
            return usuarioRepositorio.ExisteUsuario(email);
        }

        public bool ExisteUsuarioConCredenciales(string email, string password)
        {
            Usuario usuario = usuarioRepositorio.ObtenerUsuario(email);

            if (usuario == null) { return false; }

            if (usuario.Password != password) { return false; }

            return true;
        }

        public Usuario ObtenerUsuario(string email)
        {
            return usuarioRepositorio.ObtenerUsuario(email);
        }
    }
}