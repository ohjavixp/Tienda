using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Security;
using System.Net;
using System.Web.Compilation;
using System.Web.UI;
using System.Web;

namespace PlataformaComercio.UI.Routing
{
    public class ProductoRouteHandler : IRouteHandler
    {
          string _virtualPath;
          public ProductoRouteHandler(string virtualPath)
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
                              _virtualPath, typeof(Page)) as IDetalleProducto;

              display.Sku = requestContext.RouteData.Values["sku"] as string;              
              return display;
          }
    }
}
