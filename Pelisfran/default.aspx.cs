using Pelisfran.Contexto;
using System;
using System.Linq;

namespace Pelisfran
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var db = new PelisFranDBContexto();
                db.Roles.ToList();
            }

        }
    }
}