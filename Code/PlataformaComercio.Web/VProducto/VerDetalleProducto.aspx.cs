using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.UI.Routing;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Business.BasketManagement;
using System.Web.UI.HtmlControls;

namespace PlataformaComercio.Web.VProducto
{
    public partial class VerDetalleProducto : System.Web.UI.Page,IDetalleProducto
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Sku))
                Response.Redirect("~/default.aspx");

            if (!Page.IsPostBack)
            {
                MostrarProducto();
            }
        }

        private void MostrarProducto()
        {
            Inventory ctrlCatalogo = new Inventory();
            EntProduct entProducto = ctrlCatalogo.GetProductByID(Sku);

            if (System.IO.File.Exists( (Server.MapPath(entProducto.Image256Url))))
                imgProductoLarga.ImageUrl = entProducto.Image256Url;
            else
                imgProductoLarga.ImageUrl = "~/images/products/256/default256.png";

            imgProductoLarga.AlternateText = "Imagen producto " + entProducto.Name;

            lblName.Text = entProducto.Name;
            //lblNameBig.Text = entProducto.Name;
            lblDescripcionLarga.Text = entProducto.LargeDescription;
            lblPrice.Text = entProducto.Price.ToString();
            lblIsoCode.Text = entProducto.CurrencyIsoCode;
            //imgAgregarCarrito.CommandArgument = entProducto.SKU;
            lnkAddToCart.CommandArgument = entProducto.SKU;

            ((PrincipalBootstrap)Page.Master).AddHtmlDescription(entProducto.ShortDescription);

            Page.Title = entProducto.SKU + " - " + entProducto.Name;            
            
        }

        protected void imgAgregarCarrito_Command(object sender, CommandEventArgs e)
        {
            Basket basket = new Basket("default");

            if (basket.Lines.Count == 0)
                basket.Lines.Add("default");

            basket.Lines[0].AddProduct(e.CommandArgument.ToString(), 1);

        }

        #region IDetalleProducto Members

        public string Sku
        {
            get;
            set;
        }

        #endregion
    }
}
