using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;

namespace PlataformaComercio.Web.vadministration.inventory
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ShowData();
        }

        private void ShowData()
        {
            Inventory inventory = new Inventory();
            repInventories.DataSource = inventory.GetAll();
            repInventories.DataBind();

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("inventory.aspx");
        }
    }
}