using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Web.UI;

namespace Pelisfran.admin.generos
{
    public partial class editar : Base
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

                Guid generoId = Guid.Parse(Request.QueryString["id"]);
                Genero genero = _db.Generos.Where(g => g.Id == generoId).FirstOrDefault();
                txtNombre.Text = genero.Nombre;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            Guid generoId = Guid.Parse(Request.QueryString["id"]);
            Genero genero = _db.Generos.Where(g => g.Id == generoId).FirstOrDefault();

            genero.Nombre = txtNombre.Text;
            genero.ActualizadoEn = DateTime.Now;
            _db.SaveChanges();

            Response.Redirect("~/admin/generos/default.aspx");
        }
    }
}