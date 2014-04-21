using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
using PlataformaComercio.UI.Routing;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Events;

namespace PlataformaComercio.Web.vcatalogo
{
    public partial class searchresults : System.Web.UI.Page, IGenericDisplay
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(RoutedValues == null)
                Response.Redirect("~/default.aspx");

            if (RoutedValues["searchstring"] == null)
                Response.Redirect("~/default.aspx");

            if (string.IsNullOrEmpty(RoutedValues["searchstring"].ToString()))
                Response.Redirect("~/default.aspx");

            Page.Title = "Resultados de busqueda de " + RoutedValues["searchstring"].ToString();
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Mostrando los resultados de busqueda de " + RoutedValues["searchstring"].ToString());

            Inventory inventory = new Inventory();
            EntProduct[] productsResult = inventory.SearchBasic(RoutedValues["searchstring"].ToString(),true);                     
            repProducts.DataSource = productsResult;

            if (productsResult.Count() <= 0)
            {
                //MessageControl1.Show(string.Format("Lo sentimos, su busqueda por <strong>{0}</strong> no obtuvo ningún resultado, pruebe por favor utilizando otros criterios de busqueda diferentes",RoutedValues["searchstring"]), UI.Enums.MessageType.Error);
                FailureText.Text = "Lo sentimos, su busqueda por <strong>" + RoutedValues["searchstring"] + "</strong> no obtuvo ningún resultado, pruebe por favor utilizando otros criterios de busqueda diferentes";
                ErrorMessage.Visible = true;
            }
                
        }

        protected override void OnPreRender(EventArgs e)
        {
            MasterPagePrincipal masterPage = Master as MasterPagePrincipal;
            if (masterPage != null)
                masterPage.OnSearch(this, new StringEventArgs(RoutedValues["searchstring"].ToString()));

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