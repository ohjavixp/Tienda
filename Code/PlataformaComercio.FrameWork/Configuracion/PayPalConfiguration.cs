using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Configuracion
{
    public class PayPalConfiguration
    {
        public static string UserName
        {
            get
            {
                return "me_1254514291_biz_api1.misaelmonterroca.com";
            }
        }

        public static string Password
        {
            get
            {
                return "1254514302";
            }
        }

        public static string Signature
        {
            get
            {
                return "An5ns1Kso7MWUdW4ErQKJJJ4qi4-ApBgBIwQJA81YmIRXRP4a4RO0tvr";
            }
        }

        public static string Enviroment
        {
            get
            {
                return "sandbox";
            }
        }

        public static bool Is3token
        {
            get
            {
                return true;
            }
        }


    }
}
