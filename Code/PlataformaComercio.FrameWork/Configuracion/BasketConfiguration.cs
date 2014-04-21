using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Configuracion
{
    public static class BasketConfiguration
    {
        public static bool AllowDuplicateProducts 
        {
            get
            {
                return false;
            }
        }

        public static bool AllowZeroQuantity
        {
            get
            {
                return false;
            }
        }

        public static string DefaultBasketName 
        {
            get
            {
                return "default";
            }
        }
    }
}
