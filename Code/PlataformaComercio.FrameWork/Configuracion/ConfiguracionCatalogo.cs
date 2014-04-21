using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.FrameWork.Configuracion
{
    public class ConfiguracionCatalogo
    {
        public static string UrlImagenes 
        {
            get
            {
                return "~/images/products";
            }
        }

        public static string UrlImagenes128
        {
            get
            {

                return UrlImagenes + "/128";
            }
        }

        public static string UrlImagenes256
        {
            get
            {

                return UrlImagenes + "/256";
            }
        }

        public static string Imagen128Predeterminada
        {
            get
            {

                return "Default128.png";
            }
        }

        public static string Imagen256Predeterminada
        {
            get
            {

                return "Default256.png";
            }
        }

        public static string ExtensionImagen
        {
            get
            {
                return ".png";
            }
        }
    }
}
