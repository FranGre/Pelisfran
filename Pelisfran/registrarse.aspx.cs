﻿using Pelisfran.Modelos;
using Pelisfran.SeedersBaseDatos;
using Pelisfran.Servicios;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran
{
    public partial class login : Page
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private AutenticacionServicio autenticacionServicio = new AutenticacionServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            rangeFechaNacimiento.MaximumValue = DateTime.Now.ToString("dd/MM/yyyy");
            txtNombreUsuario.Focus();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }


            SeederRoles seederRoles = new SeederRoles();
            seederRoles.Insertar();


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
            // nombreUsuario existe errror

            usuarioServicio.RegistrarUsuario(usuario);
            autenticacionServicio.AutenticarUsuario(usuario.Email, usuario.Password);

            Response.Redirect("autenticado.aspx");
        }

        protected void custEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (usuarioServicio.ExisteUsuarioRegistrado(txtEmail.Text))
            {
                custEmail.ErrorMessage = "Email en uso";
                args.IsValid = false;
                return;
            }

            custEmail.ErrorMessage = string.Empty;
            args.IsValid = true;
        }

        protected void lbLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}