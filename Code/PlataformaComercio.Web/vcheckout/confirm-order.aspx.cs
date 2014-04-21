using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.FrameWork.Configuracion;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class confirm_order1 : System.Web.UI.Page, IHttpHandler
    {
        Basket basket;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RedirectUrl"] = "~/proceso-compra/carrito";

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/usuario/iniciar-sesion");
            }

            basket = new Basket(BasketConfiguration.DefaultBasketName);
            txtTotalPayment.Text = basket.Total.ToString("c");
            txtSubTotal.Text = basket.SubTotal.ToString("c");
            txtShippingCost.Text = basket.Shipping.ShippingMethods.ShippingCost.ToString("c");
            txtAddress.Text = string.Format("{0} número: {1} {2} entre las calles: {3} código postal: {4}", basket.Shipping.ShippingAddress.Address.Street, basket.Shipping.ShippingAddress.Address.StreetNumber, string.IsNullOrEmpty(basket.Shipping.ShippingAddress.Address.StreetInternalNumber) ? string.Empty : " número interno: " + basket.Shipping.ShippingAddress.Address.StreetInternalNumber, basket.Shipping.ShippingAddress.Address.StreetBetween, basket.Shipping.ShippingAddress.Address.ZipCode);
            txtShippingMethod.Text = basket.Shipping.ShippingMethods.ShippingMethod.ShippingType.Name;
            txtPaymentMethod.Text = basket.PaymentMethod.Payment.PaymentType.Name;

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/proceso-compra/gracias-transferencia");
        }
    }
}