using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Servicios;
using System;
using System.Linq;

namespace Pelisfran.admin
{
    public partial class _default : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private RolServicio _rolServicio = new RolServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var usuario = _db.Usuarios.Find(this.usuarioId);
                TipoRolesEnum rolActual = (TipoRolesEnum)usuario.RolId;

                if (!_rolServicio.EsRol(rolActual, TipoRolesEnum.Administrador))
                {
                    Response.Redirect("~/acceso-denegado.aspx");
                    return;
                }

                pGenerosTotal.InnerText = _db.Generos.Count().ToString();
                pPeliculasTotal.InnerText = _db.Peliculas.Count().ToString();
                pUsuariosTotal.InnerText = _db.Usuarios.Count().ToString();
            }
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