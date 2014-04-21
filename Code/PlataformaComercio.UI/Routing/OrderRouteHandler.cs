using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;

namespace PlataformaComercio.UI.Routing
{
    public class OrderRouteHandler : IRouteHandler
    {
        string _virtualPath;
        public OrderRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {


            //if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
            //    _virtualPath, requestContext.HttpContext.User,
            //                  requestContext.HttpContext.Request.HttpMethod))
            //{
            //    requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    requestContext.HttpContext.Response.End();
            //}

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IDetalleOrden;

            display.OrderId = requestContext.RouteData.Values["OrderId"] as string;
            return display;
        }
    }
}
