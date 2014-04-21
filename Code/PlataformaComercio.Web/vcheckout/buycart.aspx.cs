using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Business.BasketManagement;

namespace PlataformaComercio.Web
{
    public partial class BuyCart : System.Web.UI.Page, IHttpHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadProducts();
        }

        private void LoadProducts()
        {
            Basket basket = new Basket("default");
            
            if(basket.Lines.Count.Equals(0))
                return;

            repBuyCart.DataSource = basket.Lines[0].GetProducts(true);
            repBuyCart.DataBind();

            lblSubTotal.Text = basket.SubTotal.ToString("c");
        }

        protected void lnbEliminar_Command(object sender, CommandEventArgs e)
        {

            Basket basket = new Basket("default");
            basket.Lines[0].RemoveProduct(e.CommandArgument.ToString());

            LoadProducts();
        }

        protected void btnUpdateQuantity_Command(object sender, CommandEventArgs e)
        {

            if (Page.IsValid)
            {
                ImageButton btnUpdateQuantity = sender as ImageButton;
                RepeaterItem repeaterItem = btnUpdateQuantity.Parent as RepeaterItem;
                TextBox txtQuantity = repeaterItem.FindControl("txtQuantity") as TextBox;

                Basket basket = new Basket("default");
                basket.Lines[0].UpdateQuantity(e.CommandArgument.ToString(),decimal.Parse(txtQuantity.Text));

                LoadProducts();
            }

        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proceso-compra/seleccionar-direccion");
        }
    }
}