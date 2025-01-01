using System;
using System.Web.UI;

namespace Pelisfran.Controles.Botones
{
    public partial class BotonCerrarSesion : UserControl
    {
        public event EventHandler Click;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonCerrarSesion_ServerClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}