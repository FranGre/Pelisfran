using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.generos
{
    public partial class crear : Page
    {
        private GeneroServicio _generoServicio = new GeneroServicio();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }
            var usuarioAutenticado = HttpContext.Current.User.Identity;

            _generoServicio.CrearGenero(new Genero { Id = Guid.NewGuid(), UsuarioId = Guid.Parse(usuarioAutenticado.Name), Nombre = txtNombre.Text, CreadoEn = DateTime.Now });
        }
    }
}