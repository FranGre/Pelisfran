using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran
{
    public partial class mi_perfil : Page
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/login.aspx");
                return;
            }

            alerta.Visible = false;

            if (!Page.IsPostBack)
            {
                rangeFechaNacimiento.MaximumValue = DateTime.Now.ToString("dd/MM/yyyy");
                Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
                Usuario usuario = _db.Usuarios.Find(usuarioId);
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtEmail.Text = usuario.Email;
                txtNombre.Text = usuario.Nombre;
                txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                txtApellidos.Text = usuario.Apellidos;
            }
        }

        protected void custEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            Usuario usuario = _db.Usuarios.Find(usuarioId);

            if (txtEmail.Text == usuario.Email)
            {
                args.IsValid = true;
                return;
            }

            if (usuarioServicio.ExisteUsuarioRegistrado(txtEmail.Text))
            {
                custEmail.ErrorMessage = "Email en uso";
                args.IsValid = false;
                return;
            }

            custEmail.ErrorMessage = string.Empty;
            args.IsValid = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            Guid usuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name);
            Usuario usuario = _db.Usuarios.Find(usuarioId);

            if (usuario.NombreUsuario == txtNombreUsuario.Text &&
            usuario.Email == txtEmail.Text &&
            usuario.Nombre == txtNombre.Text &&
            usuario.FechaNacimiento == Convert.ToDateTime(txtFechaNacimiento.Text) &&
            usuario.Apellidos == txtApellidos.Text)
            {
                alerta.InnerHtml = "<div class=\"is-flex is-justify-content-center buttons\">\r\n            <span class=\"material-symbols-outlined\">check</span>\r\n            <p>\r\n                Perfil actualizado\r\n            </p>\r\n            <button class=\"delete ml-3\"></button>\r\n        </div>";
                alerta.Visible = true;
                return;
            }

            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Email = txtEmail.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            usuario.Apellidos = txtApellidos.Text;
            usuario.ActualizadoEn = DateTime.Now;

            _db.SaveChanges();

            alerta.InnerHtml = "<div class=\"is-flex is-justify-content-center buttons\">\r\n            <span class=\"material-symbols-outlined\">check</span>\r\n            <p>\r\n                Perfil actualizado\r\n            </p>\r\n            <button class=\"delete ml-3\"></button>\r\n        </div>";
            alerta.Visible = true;
        }
    }
}