using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class thanks_paypal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblFolio.Text = Session["TransactionID"].ToString();
            }
        }
    }
}