using System;
using System.Web.UI;

namespace Pelisfran.Controles.Botones
{
    public partial class BotonLike : UserControl
    {
        private const string LIKE_ENABLED = "fa-solid fa-thumbs-up";
        private const string LIKE_DISABLED = "fa-regular fa-thumbs-up";

        public event EventHandler Click;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void buttonLike_ServerClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        public void ActivarLike()
        {
            icono.Attributes["class"] = LIKE_ENABLED;
        }

        public void DesactivarLike()
        {
            icono.Attributes["class"] = LIKE_DISABLED;
        }
    }
}