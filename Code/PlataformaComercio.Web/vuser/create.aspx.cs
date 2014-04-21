using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Entities.User;
using PlataformaComercio.FrameWork.Exceptions;

namespace PlataformaComercio.Web.vuser
{
    public partial class create : System.Web.UI.Page, IHttpHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = "Crear un nuevo usuario";            
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Crea un nuevo usuario para disfrutar de todos nuestros beneficios");

            if (!Page.IsPostBack)
            {
                LoadInfo();
            }
        }

        private void LoadInfo()
        {
            for (int i = 1; i <= 31; i++)
            {
                ddlDay.Items.Add(new ListItem(i.ToString(),i.ToString()));
            }

            ddlMonth.Items.Add(new ListItem("Enero", "1"));
            ddlMonth.Items.Add(new ListItem("Febrero","2"));
            ddlMonth.Items.Add(new ListItem("Marzo","3"));
            ddlMonth.Items.Add(new ListItem("Abril","4"));
            ddlMonth.Items.Add(new ListItem("Mayo","5"));
            ddlMonth.Items.Add(new ListItem("Junio","6"));
            ddlMonth.Items.Add(new ListItem("Julio","7"));
            ddlMonth.Items.Add(new ListItem("Agosto","8"));
            ddlMonth.Items.Add(new ListItem("Septiembre","9"));
            ddlMonth.Items.Add(new ListItem("Octubre","10"));
            ddlMonth.Items.Add(new ListItem("Noviembre","11"));
            ddlMonth.Items.Add(new ListItem("Diciembre","12"));

            int currentYear = DateTime.Now.Year - 18;
            for (int i = 0; i <= 100; i++)
            {                
                ddlYear.Items.Add(new ListItem((currentYear - i).ToString(), (currentYear - i).ToString()));
            }

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                EntUser entUser = new EntUser();                
                entUser.UserName = txtUserName.Text;
                entUser.Password = txtPassword.Text;
                entUser.PasswordConfirm = txtPasswordConfirm.Text;
                entUser.Name = txtName.Text;
                entUser.LastName = txtLastName.Text;
                entUser.EmailAddress = txtEmail.Text;
                entUser.EmailAddressConfirm = txtConfirmEmail.Text;
                
                DateTime birthDate;
                string date = ddlDay.SelectedValue + "/" + ddlMonth.SelectedValue + "/" + ddlYear.SelectedValue;
                bool isValidDate = DateTime.TryParse(date, out birthDate);

                if (! isValidDate)
                    throw new UserException("La fecha no es valida");

                entUser.BirthDate = birthDate;
                entUser.PhoneNumber = txtPhoneNumber.Text;
                entUser.PhoneNumberExtension = txtPhoneNumberExt.Text;
                entUser.MobileNumber = txtMobileNumber.Text;
                entUser.Sex = rdbFemale.Checked;
                entUser.SendInfo = chkSendInfo.Checked;
                entUser.ShareInfo = chkShareInfo.Checked;

                Business.User user = new Business.User();

                try
                {
                    user.Add(entUser);
                    Session["RedirectUrl"] = "~/usuario/crear";
                    Response.Redirect("~/usuario/iniciar-sesion");

                }
                catch (UserException ex)
                {
                    //MessageControl1.Show(ex.Message, UI.Enums.MessageType.Error);   
                    FailureText.Text = ex.Message;
                    ErrorMessage.Visible = true;
                }                

            }
        }
    }

}