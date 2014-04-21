using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Business.Catalogs;

namespace PlataformaComercio.Web.vadministration.trades
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                ShowTrades();
        }

        private void ShowTrades()
        {
            Trade trade = new Trade();
            repTrades.DataSource = trade.GetAll();
            repTrades.DataBind();
        }
    }
}