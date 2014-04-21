using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Business.Catalogs;

namespace PlataformaComercio.Web.vadministration.products
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
                ShowProducts();
        }

        private void ShowProducts()
        {   
            Product product = new Product();
            var products = product.GetAll();
            repProduct.DataSource = products;
            repProduct.DataBind();
        }
    }
}