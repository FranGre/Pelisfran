using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pelisfran.Servicios
{
    public class RolServicio
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        public List<Rol> roles
        {
            get { return (List<Rol>)HttpContext.Current.Session["roles"]; }
            set { HttpContext.Current.Session["roles"] = value; }
        }

        public void CargarRoles()
        {
            roles = _db.Roles.ToList();
        }
    }
}