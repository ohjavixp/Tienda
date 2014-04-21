using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using com.paypal.soap.api;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.Entities.Basket;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class selectpaymentmethod : System.Web.UI.Page, IHttpHandler
    {
        #region Private Fields
        Basket basket;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RedirectUrl"] = "~/proceso-compra/carrito";

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/usuario/iniciar-sesion");
            }

            basket = new Basket(BasketConfiguration.DefaultBasketName);
            lblTotalPayment.Text = basket.Total.ToString("c");

            rblPaymentMethod.Items[0].Enabled = false;
            rblPaymentMethod.Items[1].Enabled = false;
            
        }

        private string ConvertRelativeUrlToAbsoluteUrl(string relativeUrl)
        {           
            
            if (Request.IsSecureConnection)
                return string.Format("https://{0}{1}{2}{3}", Request.Url.DnsSafeHost,Request.Url.IsDefaultPort?"":":" + Request.Url.Port.ToString(),GeneralConfiguration.WebApplication, Page.ResolveUrl(relativeUrl));
            else
                return string.Format("http://{0}{1}{2}{3}", Request.Url.DnsSafeHost, Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port.ToString(), GeneralConfiguration.WebApplication, Page.ResolveUrl(relativeUrl));

        }


        protected void btnTransfer_Click(object sender, EventArgs e)
        { 
            

        }

        

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(rblPaymentMethod.SelectedValue))
            {
                MessageControl2.Show("Debe seleccionar un método de pago",UI.Enums.MessageType.Error);
                return;
            }

            switch(rblPaymentMethod.SelectedValue)
            {
                case "1":
                    break;
                case "2":
                    string returnURL = ConvertRelativeUrlToAbsoluteUrl("~/proceso-compra/confirmar-orden-paypal");
                    string cancelURL = ConvertRelativeUrlToAbsoluteUrl(Request.Path);

                    //PayPalPaymentMethod paymentMethod = new PayPalPaymentMethod();
                    //SetExpressCheckoutResponseType response = paymentMethod.SetExpressCheckout(basket.Total.ToString(), returnURL, cancelURL, PaymentActionCodeType.Authorization, CurrencyCodeType.MXN);

                    //if (response.Ack == AckCodeType.Success || response.Ack == AckCodeType.SuccessWithWarning)
                    //{
                    //    string host = "www." + PayPalConfiguration.Enviroment + ".paypal.com";
                    //    Response.Redirect("https://" + host + "/cgi-bin/webscr?cmd=_express-checkout&" + "token" + "=" + response.Token);
                    //}
                    //else
                    //{
                    //    payPalErrors.Errors = response.Errors;
                    //    payPalErrors.DataBind();
                    //}
                    break;
                case "3":
                    EntBasketPayment entBasketPayment = new EntBasketPayment();            
                    entBasketPayment.PaymentId = 3;
                    entBasketPayment.TotalPayed = basket.SubTotal;
                    entBasketPayment.Status = 0;

                    basket.PaymentMethod.DeleteAll();
                    basket.PaymentMethod.Add(entBasketPayment);

                    Response.Redirect("~/proceso-compra/confirmar-orden");
                    break;
            }
        }
    }
}