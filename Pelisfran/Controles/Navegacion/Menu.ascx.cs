using System;
using System.Web.UI;

namespace Pelisfran.Controles.Navegacion
{
    public partial class Menu : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbPelisFran_Click(object sender, EventArgs e)
        {
            var goTo = Server.MapPath("~/default.aspx");
            Response.Redirect("~/default.aspx");
        }

        protected void lkPeliculas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/peliculas/default.aspx");
        }

        protected void lkSeries_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/series/default.aspx");
        }
    }
}