using System;
using System.Web.UI;

namespace Pelisfran.Controles.Botones
{
    public partial class BotonFavorito : UserControl
    {
        private const string FAVORITO_ENABLED = "fa-solid fa-heart";
        private const string FAVORITO_DISABLED = "fa-regular fa-heart";
        public event EventHandler Click;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void botonFavorito_ServerClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        public void ActivarFavorito()
        {
            icono.Attributes["class"] = FAVORITO_ENABLED;
        }

        public void DesactivarFavorito()
        {
            icono.Attributes["class"] = FAVORITO_DISABLED;
        }
    }
}