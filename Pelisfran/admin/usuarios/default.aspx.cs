using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.usuarios
{
    public partial class _default : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private RolServicio _rolServicio = new RolServicio();
        private const string CLASS_BTN_ACTIVO = "button is-fullwidth has-text-weight-semibold is-family-code is-light";
        private const string CLASS_BTN_INACTIVO = "button is-fullwidth has-text-weight-semibold is-family-code is-dark";

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

                _rolServicio.roles = _db.Roles.ToList();
                gvUsuarios.DataBind();
                upUsuarios.Update();
            }
        }

        protected void btnCrearUsuarios_Click(object sender, EventArgs e)
        {

        }

        protected void textsearch_Buscar(object sender, string busqueda)
        {
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

            var usuario = (dynamic)e.Row.DataItem;

            DropDownList ddlRoles = (DropDownList)e.Row.FindControl("ddlRoles");

            ddlRoles.DataSource = _rolServicio.roles;
            ddlRoles.DataTextField = "Nombre";
            ddlRoles.DataValueField = "Id";

            foreach (var role in _rolServicio.roles)
            {
                if (role.Id == usuario.RolId)
                {
                    ddlRoles.SelectedValue = role.Id.ToString();
                    break;
                }
            }

            ddlRoles.DataBind();

            Button btnActivo = (Button)e.Row.FindControl("btnActivo");
            btnActivo.Text = "Inactivo";
            btnActivo.CssClass = CLASS_BTN_INACTIVO;

            if (usuario.Activo)
            {
                btnActivo.Text = "Activo";
                btnActivo.CssClass = CLASS_BTN_ACTIVO;
            }
        }

        protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddRoles = (DropDownList)sender;

            GridViewRow row = (GridViewRow)ddRoles.NamingContainer;

            var idUsuarioSeleccionado = Guid.Parse(gvUsuarios.DataKeys[row.RowIndex].Value.ToString());

            var idRolSeleccionado = Convert.ToInt32(ddRoles.SelectedValue);
            var usuario = _db.Usuarios.Find(idUsuarioSeleccionado);
            usuario.RolId = idRolSeleccionado;

            _db.SaveChanges();
            upUsuarios.Update();
        }
        protected void btnActivo_Command(object sender, CommandEventArgs e)
        {
            Button btnActivo = (Button)sender;
            var usuarioId = Guid.Parse(e.CommandArgument.ToString());

            var usuario = _db.Usuarios.Find(usuarioId);

            usuario.Activo = !usuario.Activo;
            _db.SaveChanges();
            btnActivo.Text = "Inactivo";
            btnActivo.CssClass = CLASS_BTN_INACTIVO;

            if (usuario.Activo)
            {
                btnActivo.Text = "Activo";
                btnActivo.CssClass = CLASS_BTN_ACTIVO;
            }
            upUsuarios.Update();
        }

        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con la paginación y ordenación de 
        //, se deben agregar los siguientes parametros:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable gvUsuarios_GetData(int maximumRows, int startRowIndex, out int totalRowCount, string sortByExpression)
        {
            var usuarios = _db.Usuarios.Include("PeliculasLikes").Include("ComentariosPeliculas").AsQueryable();

            if (!string.IsNullOrEmpty(textsearch.Text))
            {
                usuarios = usuarios.Where(u => u.Nombre.Contains(textsearch.Text) || u.NombreUsuario.Contains(textsearch.Text) || u.Email.Contains(textsearch.Text));
            }

            if (string.IsNullOrEmpty(sortByExpression))
            {
                sortByExpression = "NombreUsuario";
            }

            totalRowCount = usuarios.Count();

            return usuarios.Select(u => new
            {
                u.Id,
                u.NombreUsuario,
                u.Nombre,
                u.Email,
                u.FechaNacimiento,
                u.RolId,
                u.Activo,
                Likes = u.PeliculasLikes.Count(),
                Comentarios = u.ComentariosPeliculas.Count()
            }).OrderBy(sortByExpression).Skip(startRowIndex).Take(maximumRows);
        }
    }
};