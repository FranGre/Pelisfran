using Pelisfran.Contexto;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Pelisfran.PaginasMaestras
{
    public partial class Base : MasterPage
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                MostrarMenu();
                return;
            }

            Guid giudUsuario = Guid.Parse(HttpContext.Current.User.Identity.Name);
            Usuario usuario = _db.Usuarios.Include("Rol").Where(u => u.Id == giudUsuario).FirstOrDefault();
            bool isAdmin = (TipoRolesEnum)usuario.Rol.Id == TipoRolesEnum.Administrador;

            if (isAdmin)
            {
                MostrarAdminMenu();
                return;
            }
            MostrarMenu();
        }

        private void MostrarMenu()
        {
            menu.Visible = true;
            adminmenu.Visible = false;
        }

        private void MostrarAdminMenu()
        {
            menu.Visible = false;
            adminmenu.Visible = true;
        }
    }
}