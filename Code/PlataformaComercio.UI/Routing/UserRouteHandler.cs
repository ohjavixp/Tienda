using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.Compilation;
using System.Web.UI;

namespace PlataformaComercio.UI.Routing
{
    public class UserRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string _virtualPath = string.Empty;
            switch (requestContext.RouteData.Values["action"].ToString().ToLower())
            {
                case "crear":
                    _virtualPath = "~/vuser/create.aspx";
                    break;
                case "iniciar-sesion":
                    _virtualPath = "~/vuser/iniciar-sesion.aspx";
                    break;
                case "cerrar-sesion":
                    _virtualPath = "~/vuser/close-session.aspx";
                    break;
                case "recuperar-password":
                    _virtualPath = "~/vuser/password-recovery.aspx";
                    break;
                default:
                    requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    requestContext.HttpContext.Response.End();
                    break;
            }


            //if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
            //    _virtualPath, requestContext.HttpContext.User,
            //                  requestContext.HttpContext.Request.HttpMethod))
            //{
            //    requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //    requestContext.HttpContext.Response.End();
            //}

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IHttpHandler;


            return display;
        }
    }
}
