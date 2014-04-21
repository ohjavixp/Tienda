using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.UI.Routing;
using System.Web.Routing;
using PlataformaComercio.Business;

namespace PlataformaComercio.Web.vcatalogo
{
    public partial class productsbytrade : System.Web.UI.Page, IGenericDisplay
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (RoutedValues == null)
                Response.Redirect("~/default.aspx");

            if (RoutedValues["trade"] == null)
                Response.Redirect("~/default.aspx");

            Page.Title = "Productos de la marca " + RoutedValues["trade"].ToString();
            lblTrade.Text = "Productos de la marca " + RoutedValues["trade"].ToString();
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Mostrando todos los productos disponibles de la marca " + RoutedValues["trade"].ToString());
            
        Inventory inventory = new Inventory();
        repProducts.DataSource = inventory.GetProductsByTrade(RoutedValues["trade"].ToString());
        
            
        }


        protected override void OnPreRender(EventArgs e)
        {
            repProducts.DataBind();    
        }

        #region IGenericDisplay Members

        public RouteValueDictionary RoutedValues
        {
            get;
            set;
        }

        #endregion
    }
}