using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web.vadministration.currencys
{
    public partial class addoreditcurrency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["CurrencyId"] == null)
                {
                    btnAction.CommandName = "Add";
                    btnAction.Text = "Crear";
                }
                else
                {
                    int tradeID = int.Parse(Request.QueryString["CurrencyId"].ToString());
                    GetTrade(tradeID);
                    btnAction.CommandName = "Edit";
                    btnAction.Text = "Editar";
                    btnAction.CommandArgument = tradeID.ToString();
                    //btnDelete.Visible = true;
                }
            }
        }

        private void GetTrade(int tradeID)
        {
            Currency currency = new Currency();
            EntCurrency entcurrency = currency.GetByID(tradeID);

            txtName.Text = entcurrency.Name;
            txtExchangeRate.Text = entcurrency.ExchangeRate.ToString();
            
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Currency currency = new Currency();
                   

            if (e.CommandName == "Add")
            {
                //int tradeID = trade.Add(entTrade);
                //btnAction.CommandArgument = tradeID.ToString();
                //btnAction.CommandName = "Edit";
                //btnAction.Text = "Editar";
            }
            else
            {                
                EntCurrency entcurrency = currency.GetByID(int.Parse(e.CommandArgument.ToString()));
                entcurrency.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);                 
                currency.Update(entcurrency);
            }
        }
    }
}