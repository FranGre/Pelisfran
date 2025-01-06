using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Linq;
using System.Web.UI;

namespace Pelisfran.admin.generos
{
    public partial class editar : Page
    {
        private PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Guid generoId = Guid.Parse(Request.QueryString["id"]);
                Genero genero = _db.Generos.Where(g => g.Id == generoId).FirstOrDefault();
                txtNombre.Text = genero.Nombre;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            Guid generoId = Guid.Parse(Request.QueryString["id"]);
            Genero genero = _db.Generos.Where(g => g.Id == generoId).FirstOrDefault();

            genero.Nombre = txtNombre.Text;
            genero.ActualizadoEn = DateTime.Now;
            _db.SaveChanges();

            Response.Redirect("~/admin/generos/default.aspx");
        }
    }
}