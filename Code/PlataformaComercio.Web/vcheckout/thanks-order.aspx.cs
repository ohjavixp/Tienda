using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.Business.OrderManagement;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class thanks_order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/usuario/iniciar-sesion");
            }

            Basket basket = new Basket(BasketConfiguration.DefaultBasketName);
            lblTotalOrder.Text = basket.Total.ToString("c");
            lblSubTotal.Text = basket.Total.ToString("c");

            Order order = new Order();
            lblOrderNumber.Text = order.CreateFromBasket(true).ToString();
        }
    }
}