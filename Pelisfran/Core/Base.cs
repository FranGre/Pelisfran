using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.Core
{
    public class Base : Page
    {
        protected Guid usuarioId
        {
            get { return Guid.Parse(HttpContext.Current.Session["usuarioId"].ToString()); }
            set { HttpContext.Current.Session["usuarioId"] = value; }
        }

        protected bool EstaUsuarioAutenticado()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}