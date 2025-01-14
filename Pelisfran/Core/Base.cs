using System;
using System.Web;
using System.Web.UI;

namespace Pelisfran.Core
{
    public class Base : Page
    {
        protected Guid usuarioId
        {
            get { return HttpContext.Current.Session["usuarioId"] != null
                    ? Guid.Parse(HttpContext.Current.Session["usuarioId"].ToString()) : Guid.Empty; }
            set { HttpContext.Current.Session["usuarioId"] = value; }
        }
    }
}