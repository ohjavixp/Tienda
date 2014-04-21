using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using PlataformaComercio.UI.Routing;
using System.Security.Principal;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.FrameWork.Security;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Threading;

namespace PlataformaComercio.Web
{
    public class Global : System.Web.HttpApplication
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Application_AuthenticateRequest);
        }

        private static void RegisterRoutes(RouteCollection routes)
        {

            routes.Add("Trade", new Route("marca/{trade}/productos/",
                new GeneralRouteHandler("~/vcatalogo/productsbytrade.aspx")));

            routes.Add("SearchResult", new Route("busqueda/resultados/{searchstring}",
                new GeneralRouteHandler("~/vcatalogo/searchresults.aspx")));

            routes.Add("usuario", new Route("usuario/{action}",
                new UserRouteHandler()));

            routes.Add("contacto", new Route("contacto", new GeneralRouteHandler("~/contacto.aspx")));

            //Administracion

            routes.Add("administracion", new Route("administracion",
                new GeneralRouteHandler("~/vadministration/default.aspx")));

            routes.Add("ordenes", new Route("administracion/ordenes",
                new GeneralRouteHandler("~/vadministration/orders/default.aspx")));

            routes.Add("DetalleOrden", new Route("administracion/ordenes/{OrderId}",
                new OrderRouteHandler("~/vadministration/orders/view-or-edit-order.aspx")));

            routes.Add("productos", new Route("administracion/productos",
                new GeneralRouteHandler("~/vadministration/products/default.aspx")));

            routes.Add("DescripcionProducto", new Route("administracion/productos/{SKU}",
                new ProductoRouteHandler("~/vadministration/products/addoreditproduct.aspx")));

            routes.Add("AgregarProducto", new Route("administracion/productos/agregar",
                new GeneralRouteHandler("~/vadministration/products/addoreditproduct.aspx")));

            routes.Add("categorias", new Route("administracion/categorias",
                new GeneralRouteHandler("~/vadministration/inventory/inventory-category.aspx")));

            routes.Add("marcas", new Route("administracion/marcas",
                new GeneralRouteHandler("~/vadministration/trades/default.aspx")));

            routes.Add("AgregarMarcas", new Route("administracion/marcas/agregar",
                new GeneralRouteHandler("~/vadministration/trades/addoredittrade.aspx")));

            routes.Add("TipoCambio", new Route("administracion/tipodecambio",
                new GeneralRouteHandler("~/vadministration/currencys/default.aspx")));

            routes.Add("EditarTipoCambio", new Route("administracion/tipodecambio/{ID}",
                new GeneralRouteHandler("~/vadministration/currencys/addoreditcurrency.aspx")));

            routes.Add("proceso-compra", new Route("proceso-compra/{action}",
                    new CheckOutRouteHandler()));

            routes.Add("DetalleProducto", new Route("producto/detalleproducto/{sku}",
                new ProductoRouteHandler("~/VProducto/VerDetalleProducto.aspx")));

            routes.Add("Nivel8", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}/{nivel4}/{nivel5}/{nivel6}/{nivel7}/{nivel8}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel7", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}/{nivel4}/{nivel5}/{nivel6}/{nivel7}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel6", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}/{nivel4}/{nivel5}/{nivel6}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel5", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}/{nivel4}/{nivel5}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel4", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}/{nivel4}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel3", new Route("catalogo/{nivel1}/{nivel2}/{nivel3}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel2", new Route("catalogo/{nivel1}/{nivel2}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));

            routes.Add("Nivel1", new Route("catalogo/{nivel1}",
                new CatalogoRouteHandler("~/VCatalogo/showcategory.aspx")));
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {


        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}