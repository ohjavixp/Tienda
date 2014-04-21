using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.FrameWork.Configuracion
{
    public class GeneralConfiguration
    {
        public static IUnityContainer GetGeneralContainer()
        {
            
            IUnityContainer container = new UnityContainer().LoadConfiguration();
            return container;            
        }

        /// <summary>
        /// Obtiene la ruta del webapplication
        /// </summary>
        public static string WebApplication
        {
            get
            {
                return string.Empty;
            }
        }

        public static string ConnectionString 
        {
            get
            {

                return ConfigurationManager.ConnectionStrings["PlataformaComercio"].ConnectionString;

            }
        }
    }
}
