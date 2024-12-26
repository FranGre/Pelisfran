using System;
using System.Web.UI;

namespace Pelisfran.Controles.Busqueda
{
    public partial class TextSearch : UserControl
    {
        public string Placeholder { get; set; }
        public string Text { get; set; }

        public event EventHandler<string> Buscar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                tbBusqueda.Attributes["placeholder"] = Placeholder;
                return;
            }
            else
            {
                Text = tbBusqueda.Text.Trim();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Text = tbBusqueda.Text.Trim();
            Buscar?.Invoke(this, Text);
        }
    }
}