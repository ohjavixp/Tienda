using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.IO;
using System.Net;
using PlataformaComercio.FrameWork.Configuracion;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;
using PlataformaComercio.Entities;

namespace PlataformaComercio.Business.Core
{
    public class EmailManagement
    {
        //public static void Send(MailMessage message)
        //{
        //    Configuration c = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //    MailSettingsSectionGroup configuration = (MailSettingsSectionGroup)c.GetSectionGroup("system.net/mailSettings");

        //    var client = new SmtpClient()
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,                
        //        Credentials = new NetworkCredential(configuration.Smtp.Network.UserName, configuration.Smtp.Network.Password)
        //    };
        //    client.Send(message);

        //}

        public static void Send(MailMessage message, int emailId)
        {
            MailAddress emailAddress = new MailAddress();
            EntMailAddress entMailAddress = new EntMailAddress();
            entMailAddress = emailAddress.GetMailAddressByID(emailId);
            var client = new SmtpClient()
            {
                Host = entMailAddress.host,
                Port = entMailAddress.port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(entMailAddress.mail, entMailAddress.password)
            };
            client.Send(message);

        }

        public static void SendEmailFromTemplate(EmailSendConfig config,params string[] parametros)
        {

            if(config == null)
                throw new ArgumentNullException("config");
           

            MailMessage message = new MailMessage(config.From, config.TO);
            

            message.IsBodyHtml = config.IsBodyHtml;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            string templatePath = string.Empty;

            switch (config.Template)
            {
                case EmailSendTemplate.OrderConfirmTransfer:
                    templatePath = HttpContext.Current.Server.MapPath("~/MailTemplates/order-confirm-transfer.htm");                        
                    break;
                default:
                    break;
            }

            string body = string.Format( File.ReadAllText(templatePath),parametros);
            message.Body = body;
            message.Subject = config.Subjet;

            Send(message,2);

        }
    }
}
