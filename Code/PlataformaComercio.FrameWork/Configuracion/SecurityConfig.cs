using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Configuracion
{
    public class SecurityConfig
    {
        public static string AnonymousCookieName 
        {
            get
            {
                return "PC_AnonymousUser";
            }
        }
    }
}
