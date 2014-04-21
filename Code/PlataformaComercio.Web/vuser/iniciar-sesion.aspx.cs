using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PlataformaComercio.Business;
using PlataformaComercio.FrameWork.Security;
using PlataformaComercio.Business.BasketManagement;

namespace PlataformaComercio.Web.vuser
{
    public partial class iniciar_sesion : System.Web.UI.Page, IHttpHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Iniciar Sesión";            
            ((PrincipalBootstrap)Page.Master).AddHtmlDescription("Iniciar sesión para disfrutar de todos los beneficios del sitio");

            if (!Page.IsPostBack)
                ShowMessage();
        }

        private void ShowMessage()
        {
            if (Session["RedirectUrl"] != null)
            {
                switch (Session["RedirectUrl"].ToString())
                {
                    case "~/proceso-compra/seleccionar-direccion":
                        MessageControlFromPage.Show("Para poder comprar es necesario que ingrese su usuario y contraseña", UI.Enums.MessageType.HighLight);
                        break;
                    case "~/usuario/recuperar-password":
                        MessageControlFromPage.Show("En breve recibiras un correo electronico con información de acceso a tu cuenta", UI.Enums.MessageType.HighLight);
                        Session["RedirectUrl"] = null;
                        break;
                    case "~/usuario/crear":
                        MessageControlFromPage.Show("El usuario se creo de manera correcta. Por favor inicie sesión para verificar que sus datos son correctos", UI.Enums.MessageType.HighLight);
                        Session["RedirectUrl"] = null;
                        break;
                    default:
                        break;
                }
                

            }
        }

        protected void btnAutenticate_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(txtUser.Text, txtPassword.Text))
            {
                MembershipUser membershipUser = Membership.GetUser(txtUser.Text);
                Guid userID = new Guid( membershipUser.ProviderUserKey.ToString());
                Session["UserID"] = userID;

                // Create the authentication ticket
                FormsAuthenticationTicket authTicket = new
                                    FormsAuthenticationTicket(1,    //  version
                                     userID.ToString(),             // user    name
                                     DateTime.Now,                  //  creation
                                     DateTime.Now.AddMinutes(60),   //   Expiration
                                     false,                         // Persistent
                                     string.Empty);                 // User   data

                // Now encrypt the ticket.
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                // Create a cookie and add the encrypted ticket to the
                // cookie as data.
                HttpCookie authCookie =
                             new HttpCookie(FormsAuthentication.FormsCookieName,
                                            encryptedTicket);

                authCookie.Expires = DateTime.Now.AddMinutes(20);

                // AddOrUpdate the cookie to the outgoing cookies collection.
                Response.Cookies.Add(authCookie);                

                Authentication auth = new Authentication();
                //Asigna la identidad al thread
                auth.AssignIdentity(authTicket);
                auth.CreateAnonymousCookie(new Guid( Page.User.Identity.Name));

                
                Basket.MigrateFromAnonymousUser("default");

                if (Session["RedirectUrl"] != null)
                {
                    Response.Redirect(Session["RedirectUrl"].ToString());
                    Session.Remove("RedirectUrl");
                }
                else
                    Response.Redirect("~/");
            }
            else
            {
                //MessageControl1.Show("El nombre de usuario o contraseña son incorrectos", UI.Enums.MessageType.Error);
                FailureText.Text = "El nombre de usuario o contraseña son incorrectos";
                ErrorMessage.Visible = true;
            }
        }

      
    }
}