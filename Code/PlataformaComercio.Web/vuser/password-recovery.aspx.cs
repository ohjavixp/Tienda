using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.IO;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Business.Core;

namespace PlataformaComercio.Web.vuser
{
    public partial class password_recovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Recupera tu contraseña";
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Página de recuperación de contraseña");
        }

        private bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string userName = string.Empty;

                if (EmailIsValid(txtUser.Text))
                {
                    try
                    {
                        userName = Membership.GetUserNameByEmail(txtUser.Text);
                    }
                    catch (UserException ux)
                    {
                        MessageControl1.Show(ux.Message, UI.Enums.MessageType.Error);
                        return;
                    }
                }
                else
                {
                    userName = txtUser.Text;
                }

                MembershipUser user = Membership.GetUser(userName);
                if (user == null)
                {
                    MessageControl1.Show("El usuario o email no existe", UI.Enums.MessageType.Error);
                    return;
                }

                string password = user.GetPassword();
               
                MailMessage mailMessage = new MailMessage("me@misaelmonterroca.com", user.Email);
                string mailTemplate = File.ReadAllText(Server.MapPath("~/templates/mail-template.htm"));
                string content = string.Format("<center><h2 class='cart_title'>{0}</h2></center>Ingrese a la siguiente url para iniciar sesión en el sitio <a href='http://{1}/usuario/iniciar-sesion'>http://{1}/usuario/iniciar-sesion</a></b>", password, Request.ServerVariables["SERVER_NAME"]);
                mailMessage.Subject = "Recuperación de contraseña";
                mailMessage.Body =string.Format( mailTemplate,content);
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.IsBodyHtml = true;

                EmailManagement.Send(mailMessage,2);

                Session["RedirectUrl"] = "~/usuario/recuperar-password";
                Response.Redirect("~/usuario/iniciar-sesion");
            }
            
        }

    }
}