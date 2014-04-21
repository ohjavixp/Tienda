using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Business.Enums;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.Entities.Product;
using PlataformaComercio.UI;
using System.Linq;

namespace PlataformaComercio.Web.vadministration.products
{
    public partial class addoreditbaseproduct : System.Web.UI.Page
    {
        private void RegisterExtenders()
        {
            //AjaxControlToolkit.HtmlEditorExtender htmlEditorExtender = new AjaxControlToolkit.HtmlEditorExtender();
            //htmlEditorExtender.ID = "txtHtmlControlEditorExtender";
            //htmlEditorExtender.TargetControlID = "txtHtmlControl";
            //phControles.Controls.Add(htmlEditorExtender);
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            CreatePropertyValues();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Trade trade = new Trade();

                ddlTrade.DataSource = trade.GetAll();
                ddlTrade.DataTextField = "Name";
                ddlTrade.DataValueField = "TradeID";
                ddlTrade.DataBind();

                PropertyCategory propertyCategory = new PropertyCategory();
                ddlPropertyCategoryID.DataSource = propertyCategory.GetAll().Where(p => p.IsActive == true);
                ddlPropertyCategoryID.DataTextField = "Name";
                ddlPropertyCategoryID.DataValueField = "PropertyCategoryId";
                ddlPropertyCategoryID.DataBind();

                ddlPropertySubCategoryID_SelectedIndexChanged(ddlPropertyCategoryID, null);

                //WebHtmlEditor1.SpellCheckerID = SpellChecker.ClientID;

                if (Request.QueryString["baseProductID"] == null)
                {
                    btnAction.CommandName = "Add";
                    btnAction.Text = "Crear";
                }
                else
                {
                    string productID = Request.QueryString["baseProductID"].ToString();
                    GetBaseProduct(productID);
                    btnAction.CommandName = "Edit";
                    btnAction.Text = "Editar";
                    btnAction.CommandArgument = productID.ToString();
                }
            }
            else
            {
                TextBox txt = FindControl("txtHtmlControl") as TextBox;
                HtmlToText convert = new HtmlToText();
                string xy = convert.Convert(HttpUtility.HtmlDecode(txt.Text));
                FileUpload fu = FindControl("fuPreviewImage") as FileUpload;
                if (fu.HasFile)
                {
                    string fileName = Server.MapPath(@"~/files/products/") + fu.FileName;
                    fu.PostedFile.SaveAs(fileName);
                }
            }

            RegisterExtenders();
        }

        private void CreatePropertyValues()
        {
            PlaceHolder phDynamicControls;
            if (Page.IsPostBack)
            {
                phDynamicControls = Session["phDynamicControls"] as PlaceHolder;
                if (phDynamicControls != null)
                    phControles.Controls.Add(phDynamicControls);

                foreach (Control item in phDynamicControls.Controls)
                {
                    if (item.ID != null && item.ID.StartsWith("phControlSimpleList"))
                    {
                        PlaceHolder ph = item as PlaceHolder;
                        foreach (Control button in ph.Controls)
                        {
                            if (button is Button)
                            {
                                Button btnSimpleList = button as Button;

                                if (btnSimpleList.ID.StartsWith("btnSimpleListDelete"))
                                    btnSimpleList.Click += new EventHandler(btnSimpleListDelete_Click);
                                else
                                    btnSimpleList.Click += new EventHandler(btnSimpleList_Click);
                            }
                        }
                    }
                }

                return;
            }

            if (ddlPropertySubCategoryID.SelectedValue == null || ddlPropertySubCategoryID.SelectedValue == "")
                return;

            Property property = new Property();
            EntProperty[] properties = property.GetByCategoryAndSubCategoryId(Int32.Parse(ddlPropertyCategoryID.SelectedValue), Int32.Parse(ddlPropertySubCategoryID.SelectedValue)).Where(p => p.IsActive == true && p.IsBase==true).ToArray();

            phDynamicControls = new PlaceHolder();
            phDynamicControls.ID = "phDynamicControls";
            phControles.Controls.Add(phDynamicControls);

            foreach (var item in properties)
            {
                PropertyType propertyType = (PropertyType)item.Type;

                Label lblControl = new Label();
                lblControl.ID = "lbl" + item.Name;
                lblControl.Text = item.FriendlyName;
                phDynamicControls.Controls.Add(lblControl);

                switch (propertyType)
                {
                    case PropertyType.Number:
                    case PropertyType.Currency:
                    case PropertyType.Text:
                        TextBox txtControl = new TextBox();
                        txtControl.ID = "txt" + item.Name;
                        phDynamicControls.Controls.Add(txtControl);
                        break;
                    case PropertyType.Html:
                        TextBox txtHtmlControl = new TextBox();
                        txtHtmlControl.ID = "txtHtmlControl";
                        txtHtmlControl.TextMode = TextBoxMode.MultiLine;
                        txtHtmlControl.Columns = 50;
                        txtHtmlControl.Rows = 10;
                        phDynamicControls.Controls.Add(txtHtmlControl);

                        break;
                    case PropertyType.DateTime:
                        break;
                    case PropertyType.SimpleList:
                        PlaceHolder phControlSimpleList = new PlaceHolder();
                        phControlSimpleList.ID = "phControlSimpleList" + item.Name;
                        phDynamicControls.Controls.Add(phControlSimpleList);

                        Button btnSimpleList = new Button();
                        btnSimpleList.ID = "btnSimpleList" + item.Name;
                        btnSimpleList.Text = "Agregar Control";
                        btnSimpleList.Click += new EventHandler(btnSimpleList_Click);
                        btnSimpleList.CommandArgument = item.Name;
                        phControlSimpleList.Controls.Add(btnSimpleList);
                        ViewState["txtControlSimpleList" + item.Name] = 1;

                        CreateSimpleListElement(item.Name + "1", phControlSimpleList);
                        break;
                    case PropertyType.SimpleMatrix:
                        break;
                    case PropertyType.File:
                        FileUpload fuControl = new FileUpload();
                        fuControl.ID = "fu" + item.Name;
                        phDynamicControls.Controls.Add(fuControl);
                        break;
                    case PropertyType.FileList:
                        PlaceHolder phControlFileList = new PlaceHolder();
                        phControlFileList.ID = "phFileList" + item.Name;
                        phDynamicControls.Controls.Add(phControlFileList);

                        FileUpload fuFileListControl = new FileUpload();
                        fuFileListControl.ID = "fuFileListControl";
                        phControlFileList.Controls.Add(fuFileListControl);

                        break;
                    default:
                        break;
                }

                phDynamicControls.Controls.Add(new HtmlGenericControl("br"));
            }

            Session["phDynamicControls"] = phDynamicControls;
        }

        private void CreateSimpleListElement(string name, PlaceHolder phControlSimpleList)
        {
            TextBox txtControlSimpleList = new TextBox();
            txtControlSimpleList.ID = "txtControlSimpleList" + name;
            phControlSimpleList.Controls.Add(txtControlSimpleList);

            Button btnSimpleListDelete = new Button();
            btnSimpleListDelete.ID = "btnSimpleListDelete" + name;
            btnSimpleListDelete.Text = "X";
            btnSimpleListDelete.Click += new EventHandler(btnSimpleListDelete_Click);
            btnSimpleListDelete.CommandArgument = name;
            phControlSimpleList.Controls.Add(btnSimpleListDelete);
        }

        private void btnSimpleListDelete_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            PlaceHolder ph = button.Parent as PlaceHolder;
            string txtId = button.ID.Replace("btnSimpleListDelete", "txtControlSimpleList");
            TextBox textBox = ph.FindControl(txtId) as TextBox;
            ph.Controls.Remove(button);
            ph.Controls.Remove(textBox);
        }

        private void btnSimpleList_Click(object sender, EventArgs e)
        {
            Button control = sender as Button;
            PlaceHolder ph = control.Parent as PlaceHolder;
            int count = Int32.Parse(ViewState["txtControlSimpleList" + control.CommandArgument].ToString()) + 1;
            ViewState["txtControlSimpleList" + control.CommandArgument] = count;
            Session["phDynamicControls"] = ph.Parent as PlaceHolder;

            CreateSimpleListElement(control.CommandArgument + count, ph);
        }

        private void GetBaseProduct(string baseProductID)
        {
            BaseProduct baseProduct = new BaseProduct();
            EntBaseProduct entProduct = baseProduct.GetByID(baseProductID);

            txtBaseProductID.Text = entProduct.BaseProductId;
            txtName.Text = entProduct.Name;
            ddlTrade.SelectedValue = entProduct.TradeId.ToString();
            chkIsActive.Checked = entProduct.IsActive;
            txtLastMod.Text = entProduct.LastMod.ToString();
        }

        protected void btnAction_Command(object sender, CommandEventArgs e)
        {
            BaseProduct baseProduct = new BaseProduct();

            EntBaseProduct entProduct = new EntBaseProduct();
            entProduct.BaseProductId = txtBaseProductID.Text;
            entProduct.Name = txtName.Text;
            entProduct.TradeId = Int32.Parse(ddlTrade.SelectedValue);
            entProduct.PropertyCategoryID = Int32.Parse(ddlPropertyCategoryID.SelectedValue);
            entProduct.PropertySubCategoryID = Int32.Parse(ddlPropertySubCategoryID.SelectedValue);

            entProduct.IsActive = chkIsActive.Checked;

            if (e.CommandName == "Add")
            {
                baseProduct.Add(entProduct);

                btnAction.CommandArgument = txtBaseProductID.Text;
                btnAction.CommandName = "Edit";
                btnAction.Text = "Editar";
            }
            else
            {
                entProduct.BaseProductId = e.CommandArgument.ToString();
                baseProduct.Update(entProduct);
            }
        }

        protected void ddlPropertySubCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPropertyCategoryID.SelectedValue == null)
                return;

            PropertySubCategory propertySubCategory = new PropertySubCategory();
            ddlPropertySubCategoryID.DataSource = propertySubCategory.GetByCategoryID(Int32.Parse(ddlPropertyCategoryID.SelectedValue));
            ddlPropertySubCategoryID.DataTextField = "Name";
            ddlPropertySubCategoryID.DataValueField = "PropertySubCategoryId";
            ddlPropertySubCategoryID.DataBind();

            CreatePropertyValues();
        }

        protected void ddlPropertyCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreatePropertyValues();
        }
    }
}