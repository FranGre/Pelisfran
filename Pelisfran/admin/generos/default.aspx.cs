using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.generos
{
    public partial class _default_aspx : Base
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();
        private RolServicio _rolServicio = new RolServicio();

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

                gvGeneros.DataBind();
                upGeneros.Update();
            }
        }

        protected void btnCrearGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/generos/crear.aspx");
        }

        protected void controlesModalConfirmar_ClickEliminar(object sender, EventArgs e)
        {
            Guid generoId = Guid.Parse(controlesModalConfirmar.Id);
            Genero genero = _db.Generos.Where(g => g.Id == generoId).FirstOrDefault();
            _db.Generos.Remove(genero);
            _db.SaveChanges();

            gvGeneros.DataBind();
            upGeneros.Update();
        }


        protected void textsearch_Buscar(object sender, string busqueda)
        {
            gvGeneros.DataBind();
            upGeneros.Update();
        }

        protected void btnEditar_Command(object sender, CommandEventArgs e)
        {
            var generoId = e.CommandArgument.ToString();

            Response.Redirect($"~/admin/generos/editar.aspx?id={generoId}");
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            var generoId = e.CommandArgument.ToString();

            controlesModalConfirmar.Id = generoId;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModal", "mostrarModal()", true);
        }

        // El tipo devuelto puede ser modificado a IEnumerable, sin embargo, para ser compatible con la paginación y ordenación de 
        //, se deben agregar los siguientes parametros:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable gvGeneros_GetData(int maximumRows, int startRowIndex, out int totalRowCount, string sortByExpression)
        {
            var generos = _db.Generos.Include("GenerosPeliculas").AsQueryable();

            if (!string.IsNullOrEmpty(textsearch.Text))
            {
                generos = generos.Where(g => g.Nombre.Contains(textsearch.Text));
            }

            if (string.IsNullOrEmpty(sortByExpression))
            {
                sortByExpression = "Nombre";
            }

            totalRowCount = generos.Count();

            return generos.Select(g => new
            {
                g.Id,
                g.Nombre,
                TotalPeliculas = g.GenerosPeliculas.Count().ToString(),
            }).OrderBy(sortByExpression).Skip(startRowIndex).Take(maximumRows);
        }
    }
}