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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            var db = new PelisFranDBContexto();
            /*
            if (!db.Roles.Any())
            {
                SeederRoles seederRoles = new SeederRoles();
                seederRoles.Insertar();
            }
            */

            if (db.Usuarios.Where(u => u.Email == txtEmail.Text).FirstOrDefault() != null) { return; }

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

            db.Usuarios.Add(usuario);
            db.SaveChanges();
        }
    }
}