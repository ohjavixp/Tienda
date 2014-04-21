using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.UI.Routing;
using System.Web.Routing;

namespace PlataformaComercio.Web.vadministration.trades
{
    public partial class addoredittrade : System.Web.UI.Page, IGenericDisplay
    {
        #region IGenericDisplay Members

        public RouteValueDictionary RoutedValues
        {
            get;
            set;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (RoutedValues == null)
            //{
            //    Response.Redirect("~/admin/trades/");
            //}

            //if (RoutedValues["tradeid"] == null)
            //{
            //    Response.Redirect("~/admin/trades/");
            //}

            //((administration)this.Master).BackUrl = this.ResolveClientUrl("~/admin/trades");


            //if (!Page.IsPostBack)
            //{
            //    if (RoutedValues["tradeid"].ToString().Equals("new"))
            //    {
            //        btnAction.CommandName = "Add";
            //        btnAction.Text = "Crear";
            //    }
            //    else
            //    {
            //        int tradeID = int.Parse(RoutedValues["tradeid"].ToString());
            //        GetTrade(tradeID);
            //        btnAction.CommandName = "Edit";
            //        btnAction.Text = "Editar";
            //        btnAction.CommandArgument = tradeID.ToString();
            //        btnDelete.Visible = true;
            //    }
            //}
        }

        private void GetTrade(int tradeID)
        {
            Trade trade = new Trade();
            EntTrade entTrade = trade.GetByID(tradeID);

            txtName.Text = entTrade.Name;
            txtShortDescription.Text = entTrade.ShortDescription;
            txtLargeDescription.Text = entTrade.Description;
            chkIsActive.Checked = entTrade.IsActive;
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            Trade trade = new Trade();

            EntTrade entTrade = new EntTrade();
            entTrade.Name = txtName.Text;
            entTrade.ShortDescription = txtShortDescription.Text;
            entTrade.Description = txtLargeDescription.Text;
            entTrade.IsActive = chkIsActive.Checked;
            entTrade.HasSubSite = false;

            if (e.CommandName == "Add")
            {
                int tradeID = trade.Add(entTrade);

                btnAction.CommandArgument = tradeID.ToString();
                btnAction.CommandName = "Edit";
                btnAction.Text = "Editar";
            }
            else
            {
                entTrade.TradeID = int.Parse(e.CommandArgument.ToString());
                trade.Update(entTrade);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Trade trade = new Trade();
            trade.Delete(int.Parse(RoutedValues["tradeid"].ToString()));
            Response.Redirect("~/admin/trades/");
        }
    }
}