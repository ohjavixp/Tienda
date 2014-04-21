using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.UI;
using PlataformaComercio.FrameWork.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PlataformaComercio.Web
{
    public partial class PrincipalBootstrap : System.Web.UI.MasterPage
    {
        public event EventHandler<StringEventArgs> Search;
        public event EventHandler<MessageEventArgs> Message;


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery", "http://code.jquery.com/jquery.js");
            //Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery-1.9.1", this.ResolveUrl("~/scripts/jquery-1.9.1.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "bootstrap", this.ResolveClientUrl("~/scripts/bootstrap.js"));

            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery.jgrowl", "css/jGrowl/jquery.jgrowl.js");



            

            if (!Page.IsPostBack)
            {
                LoadMenu();
                ShowTrades();
            }
            ShowInfo();
        }

        public void AddHtmlDescription(string descripcion)
        {
            HtmlMeta metaDescription = new HtmlMeta();
            metaDescription.Name = "Description";
            metaDescription.Content = descripcion;
            Page.Header.Controls.Add(metaDescription);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.PreRender += new EventHandler(PrincipalBootstrap__PreRender);
            this.Search += new EventHandler<StringEventArgs>(PrincipalBootstrap_Search);
            this.Message += new EventHandler<MessageEventArgs>(PrincipalBootstrap_Message);
        }

        void PrincipalBootstrap_Message(object sender, MessageEventArgs e)
        {
            string script;
            //script = "$.jGrowl.defaults.closer = false;";
            //script += "$.jGrowl.defaults.check = 500;";
            script = string.Format("$.jGrowl('{0}', {{life:1000, theme:'manilla'}});", e.Message);
            //if (!string.IsNullOrEmpty(e.Header))
            //    script = string.Format("$.jGrowl('{0}', {{ header: '{1}' }});", e.Message, e.Header);
            //else
            //    script = string.Format("$.jGrowl('{0}');", e.Message);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "JqueryMessage", script, true);
        }

        public void OnSearch(object sender, StringEventArgs eventArgs)
        {
            if (Search != null)
            {
                Search(sender, eventArgs);
            }
        }

        public void OnMessage(object sender, MessageEventArgs eventArgs)
        {
            if (Message != null)
            {
                Message(sender, eventArgs);
            }
        }

        void PrincipalBootstrap_Search(object sender, StringEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                txtSearch.Text = e.Data;
        }

        private void ShowTrades()
        {
            Trade trade = new Trade();
            rptTrades.DataSource = trade.GetAll().Where(activos => activos.IsActive == true);
            rptTrades.DataBind();
        }

        private void ShowInfo()
        {
            if (Page.User.Identity.IsAuthenticated)
            {

                hplSession.NavigateUrl = "~/usuario/cerrar-sesion";
                hplSession.Text = "Cerrar Sesión";
            }
            else
            {
                hplSession.NavigateUrl = "~/usuario/iniciar-sesion";
                hplSession.Text = "Iniciar Sesión";
            }
        }

        void PrincipalBootstrap__PreRender(object sender, EventArgs e)
        {
            LoadCartInfo();
        }

        private void LoadCartInfo()
        {
            Basket basket = new Basket("default");

            if (basket.Lines.Count == 0)
            {
                lblCartItems.Text = "0 productos";
                lblCartPrice.Text = basket.SubTotal.ToString("c");
                return;
            }

            lblNoProducts.Text = basket.Lines[0].TotalProducts.ToString();
            lblCartItems.Text = basket.Lines[0].TotalProducts.ToString() + " producto(s)";
            lblCartPrice.Text = basket.SubTotal.ToString("c");
        }

        private void LoadMenu()
        {

            List<EntTopMenu> topMenu = new List<EntTopMenu>();
            topMenu.Add(new EntTopMenu() { Name = "Inicio" });
            topMenu.Add(new EntTopMenu() { Name = "Contacto" });
            topMenu.Add(new EntTopMenu() { Name = "Quienes Somos" });
            topMenu.Add(new EntTopMenu() { Name = "Promociones" });
            topMenu.Add(new EntTopMenu() { Name = "Comunidad" });

            //rptTopMenu.DataSource = topMenu;
            //rptTopMenu.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
                Response.Redirect(ResolveUrl("~/busqueda/resultados/" + txtSearch.Text));
        }

        protected void rptTopMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl liMenuElement = e.Item.FindControl("ilMenuElement") as HtmlGenericControl;
                EntTopMenu topMenu = e.Item.DataItem as EntTopMenu;

                string css = "ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all ui-state-{0}";

                if (topMenu.Name.Equals("Inicio"))
                    css = string.Format(css, "hover");
                else
                    css = string.Format(css, "default");

                liMenuElement.Attributes.Add("class", css);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Page.Header.DataBind();
        }
    }
}