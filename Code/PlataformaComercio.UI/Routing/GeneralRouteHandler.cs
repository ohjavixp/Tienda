using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web.Security;
using System.Web;
using System.Net;
using System.Web.Compilation;
using System.Web.UI;

namespace PlataformaComercio.UI.Routing
{
    public class GeneralRouteHandler : IRouteHandler
    {
        string _virtualPath;
        public GeneralRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            

            if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
                _virtualPath, requestContext.HttpContext.User,
                              requestContext.HttpContext.Request.HttpMethod))
            {
                requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                requestContext.HttpContext.Response.End();
            }

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IHttpHandler;

            IGenericDisplay genericDisplay = display as IGenericDisplay;
            
            if (genericDisplay != null)
                genericDisplay.RoutedValues = requestContext.RouteData.Values;


            return display;
        }
    }
}

