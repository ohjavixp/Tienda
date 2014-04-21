using PlataformaComercio.Business.OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vadministration.orders
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ShowOrders();
        }

        private void ShowOrders()
        {
            OrderCatalog orderCatalog = new OrderCatalog();
            repOrder.DataSource = orderCatalog.GetAll();
            repOrder.DataBind();
        }
    }
}