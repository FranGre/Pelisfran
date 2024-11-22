using Pelisfran.Modelos;
using System.Web.Security;

namespace Pelisfran.Servicios
{
    public class AutenticacionServicio
    {
        private UsuarioServicio usuarioServicio;

        public AutenticacionServicio()
        {
            usuarioServicio = new UsuarioServicio();
        }

        public bool AutenticarUsuario(string email, string password)
        {
            if (!usuarioServicio.ExisteUsuarioRegistrado(email))
            {
                return false;
            }

            if (!usuarioServicio.ExisteUsuarioConCredenciales(email, password))
            {
                return false;
            }

            Usuario usuario = usuarioServicio.ObtenerUsuario(email);
            FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), false);
            return true;
        }
    }
}