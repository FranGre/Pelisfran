using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web.UI;

namespace Pelisfran.admin.generos
{
    public partial class crear : Base
    {
        private GeneroServicio _generoServicio = new GeneroServicio();
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
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            _generoServicio.CrearGenero(new Genero { Id = Guid.NewGuid(), UsuarioId = this.usuarioId, Nombre = txtNombre.Text, CreadoEn = DateTime.Now });
            Response.Redirect("~/admin/generos/default.aspx");
        }
    }
}