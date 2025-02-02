﻿using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Modelos;
using Pelisfran.SeedersBaseDatos;
using Pelisfran.Servicios;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran
{
    public partial class login : Base
    {
        private UsuarioServicio usuarioServicio = new UsuarioServicio();
        private AutenticacionServicio autenticacionServicio = new AutenticacionServicio();
        private PelisFranDBContexto _db = new PelisFranDBContexto();

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
                Activo = true,
                CreadoEn = DateTime.Now
            };

            usuarioServicio.RegistrarUsuario(usuario);

            FileInfo fotoPerfilDefault = new FileInfo(Server.MapPath("~/Uploads/FotosPerfil/default.jpg"));

            FotoPerfil fotoPerfilUser = new FotoPerfil
            {
                Id = usuario.Id,
                Extension = fotoPerfilDefault.Extension,
                Nombre = Guid.NewGuid().ToString(),
                NombreOriginal = fotoPerfilDefault.Name,
                Ruta = "/Uploads/FotosPerfil/default.jpg"
            };
            // nombreUsuario existe errror

            _db.FotosPerfiles.Add(fotoPerfilUser);
            _db.SaveChanges();
            autenticacionServicio.AutenticarUsuario(usuario.Email, usuario.Password);
            this.usuarioId = usuario.Id;

            Response.Redirect("~/peliculas/default.aspx");
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
            Response.Redirect("~/login.aspx");
        }
    }
}