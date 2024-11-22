using Pelisfran.Modelos;
using Pelisfran.Repositorios;

namespace Pelisfran.Servicios
{
    public class UsuarioServicio
    {
        private UsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            _usuarioRepositorio.Crear(usuario);
        }

        public bool ExisteUsuarioRegistrado(string email)
        {
            return _usuarioRepositorio.ExisteUsuario(email);
        }

        public bool ExisteUsuarioConCredenciales(string email, string password)
        {
            Usuario usuario = _usuarioRepositorio.ObtenerUsuario(email);

            if (usuario == null) { return false; }

            if (usuario.Password != password) { return false; }

            return true;
        }

        public Usuario ObtenerUsuario(string email)
        {
            return _usuarioRepositorio.ObtenerUsuario(email);
        }
    }
}