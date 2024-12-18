using Pelisfran.Modelos;
using Pelisfran.Servicios;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pelisfran.Controles.CheckBoxLists
{
    public partial class CheckBoxListGeneros : UserControl
    {
        private GeneroServicio _generoServicio = new GeneroServicio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                repGeneros.DataSource = _generoServicio.ObtenerListaDeGeneros();
                repGeneros.DataBind();
            }
        }

        protected void repGeneros_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var cbGenero = (CheckBox)e.Item.FindControl("cbGenero");
            var genero = (Genero)e.Item.DataItem;

            cbGenero.Text = genero.Nombre;
            cbGenero.Attributes["data-value"] = genero.Id.ToString();
        }

        public List<Genero> ObtenerGenerosSeleccionados()
        {
            var generosSeleccionados = new List<Genero>();
            foreach (var item in repGeneros.Items)
            {
                RepeaterItem repeaterItem = (RepeaterItem)item;
                CheckBox cbGenero = (CheckBox)repeaterItem.FindControl("cbGenero");
                if (cbGenero.Checked)
                {
                    Genero genero = new Genero
                    {
                        Id = Guid.Parse(cbGenero.Attributes["data-value"]),
                        Nombre = cbGenero.Text
                    };
                    generosSeleccionados.Add(genero);
                }
            }
            return generosSeleccionados;
        }

        public List<Guid> ObtenerIDsGenerosSeleccionados()
        {
            var idsGenerosSeleccionados = new List<Guid>();
            foreach (var item in repGeneros.Items)
            {
                RepeaterItem repeaterItem = (RepeaterItem)item;
                CheckBox cbGenero = (CheckBox)repeaterItem.FindControl("cbGenero");
                if (cbGenero.Checked)
                {
                    Guid idGenero = Guid.Parse(cbGenero.Attributes["data-value"]);
                    idsGenerosSeleccionados.Add(idGenero);
                }
            }
            return idsGenerosSeleccionados;
        }
    }
}