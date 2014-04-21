using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.Inventory;
using System.IO;
using PlataformaComercio.UI;
using PlataformaComercio.UI.Routing;
using System.Web.Routing;

namespace PlataformaComercio.Web.vadministration.products
{
    public partial class addoreditproduct : System.Web.UI.Page, IDetalleProducto
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
            //    Response.Redirect("~/admin/products/");

            //if (RoutedValues["productid"] == null)
            //    Response.Redirect("~/admin/products/");

            //((BootAdministration)this.Master).BackUrl = this.ResolveClientUrl("~/admin/products");

            if (!Page.IsPostBack)
            {
                //((BootAdministration)this.Master).Title = "Producto";                

                Trade trade = new Trade();
                ddlTrade.DataSource = trade.GetAll();
                ddlTrade.DataTextField = "Name";
                ddlTrade.DataValueField = "TradeID";
                ddlTrade.DataBind();

                Currency currency = new Currency();
                ddlCurrency.DataSource = currency.GetAll();
                ddlCurrency.DataTextField = "Name";
                ddlCurrency.DataValueField = "CurrencyId";
                ddlCurrency.DataBind();

                chkImage128.Enabled = false;
                chkImage256.Enabled = false;

                //if (RoutedValues["productid"].ToString() == "new")
                //{
                //    btnAction.CommandName = "Add";
                //    btnAction.Text = "Crear";
                //}
                //else
                //{
                //    string productID = RoutedValues["productid"].ToString();
                //    GetProduct(productID);
                //    EnableEdit(productID);
                //}
                //if (string.IsNullOrEmpty(Sku))
                if(Sku.Equals("agregar"))
                {
                    btnAction.CommandName = "Add";
                    btnAction.Text = "Crear";
                }
                else
                {
                    string productID = Sku;
                    GetProduct(productID);
                    EnableEdit(productID);
                }
            }
        }

        private void GetProduct(string productID)
        {
            Product product = new Product();
            EntProduct entProduct = product.GetByID(productID);

            txtProductID.Text = entProduct.SKU;
            txtName.Text = entProduct.Name;
            txtShortDescription.Text = entProduct.ShortDescription;
            //txtLargeDescription.Html = entProduct.LargeDescription;
            txtLargeDescription.Text = entProduct.LargeDescriptionRaw;
            txtPrice.Text = entProduct.Price.ToString();
            ddlTrade.SelectedValue = entProduct.TradeID.ToString();
            chkImage128.Checked = entProduct.Image128;
            chkImage256.Checked = entProduct.Image256;
            txtWeight.Text = entProduct.Weight.ToString();
            txtMeasure.Text = entProduct.Measure;
            chkIsActive.Checked = entProduct.IsActive;
            ddlCurrency.SelectedValue = entProduct.CurrencyID.ToString();
        }

        private void EnableEdit(string productID)
        {
            btnAction.CommandName = "Edit";
            btnAction.Text = "Editar";
            btnAction.CommandArgument = productID;

            fu128.Enabled = true;
            fu256.Enabled = true;
            btnAdd128.Enabled = true;
            btnAdd128.CommandArgument = productID;
            btnAdd256.Enabled = true;
            btnAdd256.CommandArgument = productID;
            btnDelete.Enabled = true;

        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            HtmlToText htmlToText = new HtmlToText();

            Product product = new Product();

            EntProduct entProduct = new EntProduct();
            entProduct.SKU = txtProductID.Text;
            entProduct.Name = txtName.Text;
            entProduct.ShortDescription = txtShortDescription.Text;
            //entProduct.LargeDescription = txtLargeDescription.Html;
            //entProduct.LargeDescriptionRaw = htmlToText.Convert(txtLargeDescription.Html);
            entProduct.LargeDescription = txtLargeDescription.Text;
            entProduct.LargeDescriptionRaw = txtLargeDescription.Text;
            entProduct.Price = decimal.Parse(txtPrice.Text);
            entProduct.TradeID = Int32.Parse(ddlTrade.SelectedValue);
            entProduct.Image128 = chkImage128.Checked;
            entProduct.Image256 = chkImage256.Checked;
            entProduct.Weight = decimal.Parse(txtWeight.Text);
            entProduct.Measure = txtMeasure.Text;
            entProduct.IsActive = chkIsActive.Checked;
            entProduct.CurrencyID = Int32.Parse(ddlCurrency.SelectedValue);

            if (e.CommandName == "Add")
            {
                product.Add(entProduct);
                EnableEdit(txtProductID.Text);
            }
            else
            {
                string path = "~/images/products/";

                path = Server.MapPath(String.Format("{0}128/{1}.png", path, txtProductID.Text));
                if (fu128.HasFile)
                {                    
                    File.WriteAllBytes(path, fu128.FileBytes);
                }

                entProduct.Image128 = File.Exists(path);

                path = "~/images/products/";
                path = Server.MapPath(String.Format("{0}256/{1}.png", path, txtProductID.Text));
                if (fu256.HasFile)
                {                    
                    File.WriteAllBytes(path, fu256.FileBytes);
                }

                entProduct.Image256 = File.Exists(path);

                entProduct.SKU = e.CommandArgument.ToString();
                product.Update(entProduct);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Delete(txtProductID.Text);
            Response.Redirect("default.aspx");
        }

        #region IDetalleProducto Members

        public string Sku
        {
            get;
            set;
        }

        #endregion
    }
}