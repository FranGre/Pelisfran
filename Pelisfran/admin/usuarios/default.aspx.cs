using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.usuarios
{
    public partial class _default : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private List<Rol> roles = new List<Rol>() { };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.roles = _db.Roles.ToList();
                var usuarios = _db.Usuarios.Include("PeliculasLikes").Include("ComentariosPeliculas").ToList()
                    .Select(u => new
                    {
                        u.Id,
                        u.NombreUsuario,
                        u.Nombre,
                        u.Email,
                        u.FechaNacimiento,
                        u.RolId,
                        Likes = u.PeliculasLikes.Count(),
                        Comentarios = u.ComentariosPeliculas.Count(),
                    });

                var usuariosFechaFormateada = usuarios.Select(u => new
                {
                    u.Id,
                    u.NombreUsuario,
                    u.Nombre,
                    u.Email,
                    FechaNacimiento = u.FechaNacimiento.ToString("dd/MM/yyyy"),
                    u.RolId,
                    u.Likes,
                    u.Comentarios
                });

                gvUsuarios.DataSource = usuariosFechaFormateada;
                gvUsuarios.DataBind();
                upUsuarios.Update();
            }
        }

        protected void btnCrearUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void textsearch_Buscar(object sender, string busqueda)
        {
            var query = _db.Usuarios
            .Include("PeliculasLikes").Include("ComentariosPeliculas")
            .AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(u => u.Nombre.Contains(busqueda) || u.NombreUsuario.Contains(busqueda) || u.Email.Contains(busqueda));
            }

            var usuarios = query
                .Select(u => new
                {
                    u.Id,
                    u.NombreUsuario,
                    u.Nombre,
                    u.Email,
                    u.FechaNacimiento,
                    u.RolId,
                    Likes = u.PeliculasLikes.Count(),
                    Comentarios = u.ComentariosPeliculas.Count()
                })
                .ToList();

            var usuariosFechaFormateada = usuarios.Select(u => new
            {
                u.Id,
                u.NombreUsuario,
                u.Nombre,
                u.Email,
                FechaNacimiento = u.FechaNacimiento.ToString("dd/MM/yyyy"),
                u.RolId,
                u.Likes,
                u.Comentarios
            });

            gvUsuarios.DataSource = usuariosFechaFormateada;
            gvUsuarios.DataBind();
            upUsuarios.Update();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;

            var usuarioId = btnEliminar.CommandArgument;
            controlesModalConfirmar.Id = usuarioId;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModal", "mostrarModal()", true);
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            bool esFilaDatos = e.Row.RowType == DataControlRowType.DataRow;
            if (!esFilaDatos)
            {
                return;
            }

            var dataItem = (dynamic)e.Row.DataItem;

            DropDownList ddlRoles = (DropDownList)e.Row.FindControl("ddlRoles");

            ddlRoles.DataSource = roles;
            ddlRoles.DataTextField = "Nombre";
            ddlRoles.DataValueField = "Id";

            foreach (var role in roles)
            {
                if (role.Id == dataItem.RolId)
                {
                    ddlRoles.SelectedValue = role.Id.ToString();
                    break;
                }
            }

            ddlRoles.DataBind();
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList listItem = (DropDownList)sender;

            var idRolSeleccionado = Convert.ToInt32(listItem.SelectedValue);
            // debe cambiar el rol del usuario seleccionado, en este caso este cambiando el rol del user con
            // el que estoy logeado
            var usuario = _db.Usuarios.Find(usuarioId);
            usuario.RolId = idRolSeleccionado;

            _db.SaveChanges();
            upUsuarios.Update();
        }
    }
}