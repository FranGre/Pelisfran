using Pelisfran.Contexto;
using Pelisfran.Modelos;
using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.series
{
    public partial class crear : Page
    {
        PelisFranDBContexto _db = new PelisFranDBContexto();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) { return; }

            Serie serie = new Serie
            {
                Id = Guid.NewGuid(),
                Titulo = txtTitulo.Text,
                SinopsisBreve = txtSinopsis.Text,
                FechaLanzamiento = Convert.ToDateTime(txtFechaLanzamiento.Text),
                CreadoEn = DateTime.Now,
                UsuarioId = Guid.Parse(HttpContext.Current.User.Identity.Name)
            };


            _db.Series.Add(serie);
            _db.SaveChanges();
        }
    }
}