using System;
using System.Web;
using PlataformaComercio.Business.BasketManagement;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class confirm_order : System.Web.UI.Page, IHttpHandler
    {
        #region Private Fields

        Basket basket;

        #endregion Private Fields

        protected void Page_Load(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Session["RedirectUrl"] = "~/proceso-compra/carrito";

            //if (!User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/usuario/iniciar-sesion");
            //}

            //if (!Page.IsPostBack)
            //{
            //    if (Request.QueryString["token"] != null)
            //    {
            //        PayPalPaymentMethod paymentMethod = new PayPalPaymentMethod();
            //        GetExpressCheckoutDetailsResponseType response = paymentMethod.GetExpressCheckoutDetails(Request.QueryString["token"]);
            //        Response.Write("Response ACK " + response.Ack + "<br/>");
            //        Response.Write("Order Total " + response.GetExpressCheckoutDetailsResponseDetails.PaymentDetails.OrderTotal.Value + "<br/>");
            //        Response.Write("Zip Code " + response.GetExpressCheckoutDetailsResponseDetails.PayerInfo.Address.PostalCode + "<br/>");
            //        Response.Write("PayerID " + response.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID + "<br/>");
            //        Response.Write("PayerName " + response.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerName.FirstName + "<br/>");
            //        Session["PayerID"] = response.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
            //    }
            //}

            //basket = new Basket(BasketConfiguration.DefaultBasketName);
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //PayPalPaymentMethod paymentMethod = new PayPalPaymentMethod();
            //DoExpressCheckoutPaymentResponseType response = paymentMethod.DoExpressCheckoutPayment(Request.QueryString["token"].ToString(), Session["PayerID"].ToString(), basket.Total.ToString(), PaymentActionCodeType.Authorization, CurrencyCodeType.MXN);

            //if (response.Ack == AckCodeType.Success || response.Ack == AckCodeType.SuccessWithWarning)
            //{
            //    Session["TransactionID"] = response.DoExpressCheckoutPaymentResponseDetails.PaymentInfo.TransactionID;
            //    Response.Redirect("~/proceso-compra/gracias-paypal");
            //}
            //else
            //{
            //    payPalErrors.Errors = response.Errors;
            //    payPalErrors.DataBind();
            //}
        }
    }
}