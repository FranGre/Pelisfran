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

        public bool ExisteUsuarioConEmail(string email)
        {
            return usuarioRepositorio.ExisteEmail(email);
        }
    }
}