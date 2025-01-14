using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Pelisfran.admin
{
    public partial class _default : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = _db.Usuarios.Find(this.usuarioId);

            if ((TipoRolesEnum)usuario.RolId != TipoRolesEnum.Administrador)
            {
                // acceso denegado
                return;
            }
            pGenerosTotal.InnerText = _db.Generos.Count().ToString();
            pPeliculasTotal.InnerText = _db.Peliculas.Count().ToString();
            pUsuariosTotal.InnerText = _db.Usuarios.Count().ToString();
        }

        protected void lbGeneros_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/generos/default.aspx");
        }

        protected void lbPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/peliculas/default.aspx");
        }

        protected void lbUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/usuarios/default.aspx");
        }
    }
}