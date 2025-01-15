using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran
{
    public partial class mi_perfil : Base
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private AutenticacionServicio _autenticacionServicio = new AutenticacionServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!_autenticacionServicio.EstaUsuarioAutenticado())
            {
                Response.Redirect("~/login.aspx");
                return;
            }

            alerta.Visible = false;

            if (!Page.IsPostBack)
            {
                rangeFechaNacimiento.MaximumValue = DateTime.Now.ToString("dd/MM/yyyy");
                Usuario usuario = _db.Usuarios.Find(this.usuarioId);
                txtNombreUsuario.Text = usuario.NombreUsuario;
                txtEmail.Text = usuario.Email;
                txtNombre.Text = usuario.Nombre;
                txtFechaNacimiento.Text = usuario.FechaNacimiento.ToString("yyyy-MM-dd");
                txtApellidos.Text = usuario.Apellidos;
            }
        }

        protected void custEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Usuario usuario = _db.Usuarios.Find(this.usuarioId);

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

            Usuario usuario = _db.Usuarios.Find(this.usuarioId);

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