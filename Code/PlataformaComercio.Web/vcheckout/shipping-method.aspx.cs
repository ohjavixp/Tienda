using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.Entities.Shipping;
using PlataformaComercio.Business.Core;
using System.Net.Mail;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class shipping_method : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Basket basket = new Basket(BasketConfiguration.DefaultBasketName);
            EntShippingMethod[] shippingMethods = basket.Shipping.ShippingMethods.GetShippingMethods();

            //Si solo existe un método de envío se agrega de manera automatica y se redirecciona
            if (shippingMethods.Count().Equals(1))
            {
                basket.Shipping.ShippingMethods.AddOrUpdate(shippingMethods[0].ShippingCostId);
                Response.Redirect("seleccionar-forma-pago");
            }
            else if (shippingMethods.Count().Equals(0))
            {
                //MessageControl1.Show("Lo sentimos, no pudimos determinar de manera automatica el cargo por costo de envío", UI.Enums.MessageType.HighLight);
                FailureText.Text = "Lo sentimos, no pudimos determinar de manera automatica el cargo por costo de envío";
                ErrorMessage.Visible = true;
                btnContinue.CommandArgument = "NoShippingCost";
                lblNoShipping.Visible = true;


                string body = string.Format("No se localizo el envío para el código postal {0} del carrito de compras {1}", basket.Shipping.ShippingAddress.Address.ZipCode, basket.BasketId);
                MailMessage message = new MailMessage("ventas@espaciomascota.com", "ventas@espaciomascota.com", "Código postal no localizado", body);
                EmailManagement.Send(message, 2);
            }
            else
            {
                blsShippingMethods.DataSource = shippingMethods;
                blsShippingMethods.DataValueField = "ShippingCostId";
                blsShippingMethods.DataTextField = "Cost";
                blsShippingMethods.DataBind();
                btnContinue.CommandArgument = "ShippingCost";
            }

            
        }

      

        protected void btnContinue_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.Equals("NoShippingCost"))
            {
                Response.Redirect("gracias-orden");
            }
            else
            {
                Response.Redirect("seleccionar-forma-pago");
            }
        }
    }
}