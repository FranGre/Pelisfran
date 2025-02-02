﻿using Pelisfran.Modelos;
using System.Web;
using System.Web.Security;

namespace Pelisfran.Servicios
{
    public class AutenticacionServicio
    {
        private UsuarioServicio _usuarioServicio;

        public AutenticacionServicio()
        {
            _usuarioServicio = new UsuarioServicio();
        }

        public bool AutenticarUsuario(string email, string password)
        {
            if (!_usuarioServicio.ExisteUsuarioRegistrado(email))
            {
                return false;
            }

            if (!_usuarioServicio.ExisteUsuarioConCredenciales(email, password))
            {
                return false;
            }

            Usuario usuario = _usuarioServicio.ObtenerUsuario(email);
            FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), false);
            return true;
        }

        public bool EstaUsuarioAutenticado()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public bool EstaActivo(string email)
        {
            Usuario usuario = _usuarioServicio.ObtenerUsuario(email);
            return usuario.Activo;
        }
    }
}