using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.admin.generos
{
    public partial class _default_aspx : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var generos = _db.Generos.Include("Peliculas").Select(g => new { g.Id, g.Nombre, TotalPeliculas = g.GenerosPeliculas.Count() }).ToList();
                gvGeneros.DataSource = generos;
                gvGeneros.DataBind();
            }
        }

        protected void btnCrearGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/generos/crear.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;

            var generoId = btnEliminar.CommandArgument;
            controlesModalConfirmar.Id = generoId;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarModal", "mostrarModal()", true);
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
    }
}