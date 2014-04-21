using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using System.Configuration;

namespace PlataformaComercio.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowNewProducts();
                ShowRecommendedProducts();
            }

            Page.Title = ConfigurationManager.AppSettings["DefaultTitle"];
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription(ConfigurationManager.AppSettings["DefaultHtmlDescription"]);
            
        }

        private void ShowNewProducts()
        {
            Inventory inventory = new Inventory();
            EntProduct[] products = inventory.GetProductsByCategory("New Products");
            repNewProducts.DataSource = products;
            repNewProducts.DataBind();
        }

        private void ShowRecommendedProducts()
        {
            Inventory inventory = new Inventory();
            EntProduct[] products = inventory.GetProductsByCategory("Recommended Products");
            repRecommendedProducts.DataSource = products;
            repRecommendedProducts.DataBind();
        }
    }
}
