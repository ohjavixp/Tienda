using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business;
using PlataformaComercio.Entities.User;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.FrameWork.Configuracion;

namespace PlataformaComercio.Web.vcheckout
{
    public partial class sendaddress : System.Web.UI.Page, IHttpHandler
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            Session["RedirectUrl"] = "~/proceso-compra/seleccionar-direccion";
            

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/usuario/iniciar-sesion");
            }

            if (!Page.IsPostBack)
                LoadAddress();
		}

        private void LoadAddress()
        {
            User user = new User();
            EntUserAddress entUserAddress = user.GetAddressByID(new Guid(Page.User.Identity.Name), 1);
            
            if (entUserAddress != null)
            {
                Session["UserAddressID"] = entUserAddress.AddressID;
                ddlCountry.SelectedValue = entUserAddress.CountryID.ToString();
                txtZipCode.Text = entUserAddress.ZipCode;                
                txtStreet.Text = entUserAddress.Street;
                txtStreetNumber.Text = entUserAddress.StreetNumber;
                txtStreetInternalNumber.Text = entUserAddress.StreetInternalNumber;
                txtStreetBetween.Text = entUserAddress.StreetBetween;
                txtTelephoneContact.Text = entUserAddress.TelephoneContact;
                txtComments.Text = entUserAddress.Comments;

                GetNeighborghood();

                ddlNeighborghood.SelectedValue = entUserAddress.NeighborghoodID.ToString();
            }
        }

        protected void btnContinueZipCode_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                GetNeighborghood();
            }
        }

        private void GetNeighborghood()
        {
            Catalog catalog = new Catalog();
            EntNeighborghood[] entNeighborghood = catalog.GetNeighborghoodsByZipCode(txtZipCode.Text, true);

            ddlNeighborghood.DataSource = entNeighborghood;
            ddlNeighborghood.DataTextField = "Name";
            ddlNeighborghood.DataValueField = "ID";
            ddlNeighborghood.DataBind();

            if (entNeighborghood.Length > 0)
            {
                txtCountry.Text = entNeighborghood[0].County.Name;
                txtEstate.Text = entNeighborghood[0].County.Estate.Name;
            }
        }

    

        protected void btnSaveAddress_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EntUserAddress entUserAddress = new EntUserAddress();
                entUserAddress.UserID = new Guid(Page.User.Identity.Name);
                entUserAddress.CountryID = int.Parse(ddlCountry.SelectedValue);
                entUserAddress.ZipCode = txtZipCode.Text;
                entUserAddress.NeighborghoodID = int.Parse(ddlNeighborghood.SelectedValue);
                entUserAddress.Street = txtStreet.Text;
                entUserAddress.StreetNumber = txtStreetNumber.Text;
                entUserAddress.StreetInternalNumber = txtStreetInternalNumber.Text;
                entUserAddress.StreetBetween = txtStreetBetween.Text;
                entUserAddress.AddressName = "Predeterminada";
                entUserAddress.TelephoneContact = txtTelephoneContact.Text;
                entUserAddress.Comments = txtComments.Text;
                User user = new User();

                if (Session["UserAddressID"] == null)
                    Session["UserAddressID"] = user.AddAddress(entUserAddress);
                else
                {
                    entUserAddress.AddressID = (int)Session["UserAddressID"];
                    user.UpdateAddress(entUserAddress);
                }

                Basket basket = new Basket(BasketConfiguration.DefaultBasketName);
                basket.Shipping.ShippingAddress.AddOrUpdate(entUserAddress);

                Response.Redirect("seleccionar-forma-envio");
                
            }
        }

        protected void txtZipCode_TextChanged(object sender, EventArgs e)
        {
            if(! string.IsNullOrEmpty(txtZipCode.Text))
                GetNeighborghood();
        }
	}
}