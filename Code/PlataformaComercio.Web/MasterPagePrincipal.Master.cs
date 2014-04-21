using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Business.BasketManagement;
using System.Web.UI.HtmlControls;
using PlataformaComercio.Entities.UI;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.FrameWork.Events;

namespace PlataformaComercio.Web
{
    public partial class MasterPagePrincipal : System.Web.UI.MasterPage
    {

        
        public event EventHandler<StringEventArgs> Search;
        public event EventHandler<MessageEventArgs> Message;

        /// <summary>
        /// Agrega la etiqueta html description de la página
        /// </summary>
        /// <param name="descripcion"></param>
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
            this.PreRender += new EventHandler(MasterPagePrincipal_PreRender);
            this.Search += new EventHandler<StringEventArgs>(MasterPagePrincipal_Search);
            this.Message += new EventHandler<MessageEventArgs>(MasterPagePrincipal_Message);
        }

        void MasterPagePrincipal_Message(object sender, MessageEventArgs e)
        {
            string script;
            if(!string.IsNullOrEmpty(e.Header))
                script =string.Format( "$.jGrowl('{0}', {{ header: '{1}' }});",e.Message,e.Header);
            else
                script =string.Format( "$.jGrowl('{0}');",e.Message);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "JqueryMessage",script , true);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery-1.3.2.min", this.ResolveUrl("~/scripts/jquery-1.3.2.min.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery-ui-1.7.2.custom.min", this.ResolveUrl("~/scripts/jquery-ui-1.7.2.custom.min.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jquery.jgrowl_compressed", this.ResolveUrl("~/scripts/jquery.jgrowl_compressed.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "jqueryMenu", this.ResolveUrl("~/scripts/jQuery.jGlideMenu.067.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "boxOver", this.ResolveUrl("~/scripts/boxOver.js"));
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "PCScripts", this.ResolveUrl("~/scripts/PCScripts.js")); 
            
            
    
            
            if (!Page.IsPostBack)
            {
                LoadMenu();
                ShowTrades();
            }

            

            ShowInfo();

            
        }

        public void OnSearch(object sender,StringEventArgs eventArgs)
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

        void MasterPagePrincipal_Search(object sender, StringEventArgs e)
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

        void MasterPagePrincipal_PreRender(object sender, EventArgs e)
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

            lblCartItems.Text = basket.Lines[0].TotalProducts.ToString() + " producto(s)";
            lblCartPrice.Text = basket.SubTotal.ToString("c");
        }

        private void LoadMenu()
        {

            List<EntTopMenu> topMenu = new List<EntTopMenu>();
            topMenu.Add(new EntTopMenu(){Name="Inicio"});
            topMenu.Add(new EntTopMenu() { Name = "Contacto" });
            topMenu.Add(new EntTopMenu() { Name = "Quienes Somos" });
            topMenu.Add(new EntTopMenu() { Name = "Promociones" });
            topMenu.Add(new EntTopMenu() { Name = "Comunidad" });

            //rptTopMenu.DataSource = topMenu;
            //rptTopMenu.DataBind();
   
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
                Response.Redirect("~/busqueda/resultados/" + txtSearch.Text);
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
