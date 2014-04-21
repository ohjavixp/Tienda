using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using PlataformaComercio.Business.Core;

namespace PlataformaComercio.Web
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Página de contacto";
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Página de contacto de espacio mascota");

            ClientScript.RegisterStartupScript(this.GetType(), "prueba", "initialize();", true);
        }

        private void  Clean()
        {
            txtEmail.Text = string.Empty;
            txtMessage.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //MailMessage message = new MailMessage("misael.monterroca@espaciomascota.com","ventas@espaciomascota.com");
                PlataformaComercio.Business.MailAddress mailDA = new PlataformaComercio.Business.MailAddress();
                string mail = mailDA.GetUserNameByID(2);
                MailMessage message = new MailMessage(txtEmail.Text,mail);
                message.Subject = "Información desde página de contacto";
                StringBuilder sbMessage = new StringBuilder();
                sbMessage.AppendLine("Nombre : " + txtName.Text);
                sbMessage.AppendLine("Correo Electronico : " + txtEmail.Text);
                sbMessage.AppendLine("Teléfono : " + txtPhone.Text);
                sbMessage.AppendLine("Mensaje : " + txtMessage.Text);                
                
                message.Body = sbMessage.ToString();
                try
                {
                    EmailManagement.Send(message,2);

                    MasterPagePrincipal masterPage = Page.Master as MasterPagePrincipal;
                    if (masterPage != null)
                    {
                        masterPage.OnMessage(this, new FrameWork.Events.MessageEventArgs("Formulario de Contacto", "El mensaje se envío correctamente"));
                    }
                }
                catch (Exception ex)
                {
                    MessageControl1.Show("Lo sentimos, ocurrio un error al enviar el mensaje", UI.Enums.MessageType.Error);
                }
                //Clean();
                lblaviso.Text = "Mensaje Enviado gracias por tomarse el tiempo de escribir...!";
            }
            else
            {
                lblaviso.Text = "No has escrito correctamente el codigo de verificacion";

            }
        }
    }
}