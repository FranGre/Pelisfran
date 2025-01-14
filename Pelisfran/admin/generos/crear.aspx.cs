using Pelisfran.Core;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.admin.generos
{
    public partial class crear : Base
    {
        private GeneroServicio _generoServicio = new GeneroServicio();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            _generoServicio.CrearGenero(new Genero { Id = Guid.NewGuid(), UsuarioId = this.usuarioId, Nombre = txtNombre.Text, CreadoEn = DateTime.Now });
            Response.Redirect("~/admin/generos/default.aspx");
        }
    }
}