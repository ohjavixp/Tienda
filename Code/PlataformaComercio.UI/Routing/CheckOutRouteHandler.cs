using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;
using System.Web.Security;
using System.Net;
using System.Web.Compilation;
using System.Web.UI;

namespace PlataformaComercio.UI.Routing
{
    public class CheckOutRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string _virtualPath = string.Empty;
            switch(requestContext.RouteData.Values["action"].ToString().ToLower())
            {
                case "carrito":
                    _virtualPath = "~/vcheckout/buycart.aspx";
                    break;
                case "seleccionar-direccion":
                    _virtualPath = "~/vcheckout/sendaddress.aspx";
                    break;
                case "seleccionar-forma-pago":
                    _virtualPath = "~/vcheckout/selectpaymentmethod.aspx";
                    break;
                case "confirmar-orden":
                    _virtualPath = "~/vcheckout/confirm-order.aspx";
                    break;
                case "confirmar-orden-paypal":
                    _virtualPath = "~/vcheckout/confirm-order-paypal.aspx";
                    break;
                case "gracias-paypal":
                    _virtualPath = "~/vcheckout/thanks-paypal.aspx";
                    break;
                case "gracias-transferencia":
                    _virtualPath = "~/vcheckout/thanks-transfer.aspx";
                    break;
                case "gracias-orden":
                    _virtualPath = "~/vcheckout/thanks-order.aspx";
                    break;
                case "seleccionar-forma-envio":
                    _virtualPath = "~/vcheckout/shipping-method.aspx";
                    break;                    
                default:
                    requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    requestContext.HttpContext.Response.End();
                    break;
            }


            if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
                _virtualPath, requestContext.HttpContext.User,
                              requestContext.HttpContext.Request.HttpMethod))
            {
                requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                requestContext.HttpContext.Response.End();
            }

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IHttpHandler;

            
            return display;
        }
    }
}
