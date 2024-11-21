using Pelisfran.Contexto;
using Pelisfran.Modelos;
using Pelisfran.SeedersBaseDatos;
using System;
using System.Linq;
using System.Web.UI;

namespace Pelisfran
{
    public partial class login : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            rangeFechaNacimiento.MaximumValue = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            /*
            if (!_db.Roles.Any())
            {
                SeederRoles seederRoles = new SeederRoles();
                seederRoles.Insertar();
            }
            */

            Usuario usuario = new Usuario
            {
                Id = Guid.NewGuid(),
                RolId = (int)Enums.TipoRolesEnum.Administrador,
                NombreUsuario = txtNombreUsuario.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Nombre = "-",
                FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text),
                CreadoEn = DateTime.Now
            };

            _db.Usuarios.Add(usuario);
            _db.SaveChanges();
        }

        protected void custEmail_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            bool existeUsuario = _db.Usuarios.Where(u => u.Email == txtEmail.Text).FirstOrDefault() != null;
            if (existeUsuario)
            {
                custEmail.ErrorMessage = "Email en uso";
                args.IsValid = false;
                return;
            }
            custEmail.ErrorMessage = string.Empty;
            args.IsValid = true;
        }
    }
}