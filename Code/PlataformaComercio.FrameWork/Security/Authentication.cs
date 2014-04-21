using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using PlataformaComercio.FrameWork.Configuracion;
using System.Security.Principal;
using System.Threading;

namespace PlataformaComercio.FrameWork.Security
{
    public class Authentication
    {

        private bool GenerateAuthenticateToken(HttpCookie authCookie)
        {
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Cookies.Remove(authCookie.Name);
                GenerateAnonymousToken(false);
                return true;
            }
            
            if (null == authTicket)
            {
                // Cookie failed to decrypt.
                return false;
            }
            
            AssignIdentity(authTicket);

            return true;
        }

        public void AssignIdentity(FormsAuthenticationTicket authTicket)
        {
            // When the ticket was created, the UserData property was assigned
            // a pipe delimited string of role names.
            string[] roles = new string[0];

            // Add an Identity object
            FormsIdentity id = new FormsIdentity(authTicket);
            // This principal will flow throughout the request.
            GenericPrincipal principal = new GenericPrincipal(id, roles);
            // Attach the new principal object to the current HttpContext object
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;
        }
        
        public bool GenerateAnonymousToken(bool forceCreate)
        {
            // There is no authentication cookie.                
            HttpCookie anonymousCookie = HttpContext.Current.Request.Cookies[SecurityConfig.AnonymousCookieName];

            if (anonymousCookie == null || forceCreate)
            {
                anonymousCookie = CreateAnonymousCookie(Guid.NewGuid());
            }

            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(anonymousCookie.Value);
            }
            catch (Exception ex)
            {
                //TODO: Log exception details (omitted for simplicity)                          
            }
            if (null == authTicket)
            {
                // Cookie failed to decrypt.
                return false;
            }


            // When the ticket was created, the UserData property was assigned
            // a pipe delimited string of role names.
            string[] roles = new string[0];

            // Add an Identity object
            PlataformaComercioIdentity id = new PlataformaComercioIdentity(authTicket, true);
            // This principal will flow throughout the request.
            GenericPrincipal principal = new GenericPrincipal(id, roles);
            // Attach the new principal object to the current HttpContext object
            HttpContext.Current.User = principal;
            Thread.CurrentPrincipal = principal;

            return true;
        }

        public  HttpCookie CreateAnonymousCookie(Guid userID)
        {
            HttpCookie anonymousCookie = HttpContext.Current.Request.Cookies[SecurityConfig.AnonymousCookieName];
            
            string userData = "";

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              userID.ToString(),
              DateTime.Now,
              DateTime.Now.AddYears(10),
              true,
              userData);

            // Encrypt the ticket.
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // Add the cookie.
            anonymousCookie = new HttpCookie(SecurityConfig.AnonymousCookieName, encTicket);
            anonymousCookie.Expires = DateTime.Now.AddYears(10);
            HttpContext.Current.Response.Cookies.Add(anonymousCookie);
            return anonymousCookie;
        }

        public  bool Validate(bool forceCreateAnonymous)
        {

            if (HttpContext.Current.User == null)
            {
                // Extract the forms authentication cookie
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];

                if (null == authCookie)
                {
                    return GenerateAnonymousToken(forceCreateAnonymous);    
                }
                else
                {
                    return GenerateAuthenticateToken(authCookie);
                }
            }
            
            return true;
        }

        public Guid GetAnonymousUserID()
        {

            // There is no authentication cookie.                
            HttpCookie anonymousCookie = HttpContext.Current.Request.Cookies[SecurityConfig.AnonymousCookieName];

            if (anonymousCookie == null)
            {
                throw new Exception("No se encontro la cookie del usuario anonimo");
            }

            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(anonymousCookie.Value);
            }
            catch (Exception ex)
            {
                // Log exception details (omitted for simplicity)
                throw;
            }
            if (null == authTicket)
            {
                throw new Exception("No se pudo desencriptar la información del  cookie del usuario anonimo");
            }


            return new Guid(authTicket.Name);
            
        }
    }
}
