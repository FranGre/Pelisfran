using Pelisfran.Contexto;
using Pelisfran.Core;
using Pelisfran.Enums;
using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Linq;
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

                var generos = _db.Generos.Include("Peliculas")
                   .Select(g => new
                   {
                       g.Id,
                       g.Nombre,
                       TotalPeliculas = g.GenerosPeliculas.Count()
                   }).ToList();

                gvGeneros.DataSource = generos;
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

            var generos = _db.Generos.Include("Peliculas").Select(g => new { g.Id, g.Nombre, TotalPeliculas = g.GenerosPeliculas.Count() }).ToList();
            gvGeneros.DataSource = generos;
            gvGeneros.DataBind();
            upGeneros.Update();
        }


        protected void textsearch_Buscar(object sender, string busqueda)
        {
            var query = _db.Generos
            .Include("GenerosPeliculas").AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(p => p.Nombre.Contains(busqueda));
            }

            var generos = query
                .Select(g => new
                {
                    g.Id,
                    g.Nombre,
                    TotalPeliculas = g.GenerosPeliculas.Count().ToString(),
                })
                .ToList();

            gvGeneros.DataSource = generos;
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
    }
}