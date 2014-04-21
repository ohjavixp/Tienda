using PlataformaComercio.Business.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vadministration.currencys
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ShowCurrencyes();
        }

        private void ShowCurrencyes()
        {
            Currency currency = new Currency();
            dtlCurrencys.DataSource = currency.GetAll();
            dtlCurrencys.DataBind();
        }
    }
}