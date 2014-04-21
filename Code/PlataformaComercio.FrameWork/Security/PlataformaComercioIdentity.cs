using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Web.Security;

namespace PlataformaComercio.FrameWork.Security
{
#if DEBUG
    //Se especifica MarshalByRefObject solo cuando se está ejecutando con CASSINI, por que si no da un error de thread
    public class PlataformaComercioIdentity :MarshalByRefObject, IIdentity
#else
    public class PlataformaComercioIdentity :IIdentity
#endif

    {
        bool isAnonymous;
        string authenticationType;
        bool isAuthenticated;
        string name;

        public PlataformaComercioIdentity(FormsAuthenticationTicket ticket,bool isAnonymous)
        {
            this.isAnonymous = isAnonymous;
            this.isAuthenticated = !isAnonymous;
            this.authenticationType = "PCAnonymous";
            this.name = ticket.Name;
        }

        public bool IsAnonymous
        {
            get { return isAnonymous; }
        }
        
        #region IIdentity Members

        public string AuthenticationType
        {
            get { return authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
        }

        public string Name
        {
            get { return name; }
        }

        

        #endregion
    }
}
