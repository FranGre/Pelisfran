using System;
using System.Web.UI;

namespace Pelisfran.Controles.Botones
{
    public partial class BotonCrear : UserControl
    {
        public event EventHandler Click;
        public string Text { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.Text))
            {
                return;
            }

            text.InnerText = this.Text;
        }

        protected void buttonCrear_ServerClick(object sender, EventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
}