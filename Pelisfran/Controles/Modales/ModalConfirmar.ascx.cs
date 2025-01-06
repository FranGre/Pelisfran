using System;
using System.Web.UI;

namespace Pelisfran.Controles.Modales
{
    public partial class ModalConfirmar : UserControl
    {
        public string Id
        {
            get { return ViewState["IdGeneroAElinar"] as string; }
            set { ViewState["IdGeneroAElinar"] = value; }
        }

        public event EventHandler ClickEliminar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                btnEliminar.CommandArgument = Id;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClickEliminar?.Invoke(this, EventArgs.Empty);
        }
    }
}