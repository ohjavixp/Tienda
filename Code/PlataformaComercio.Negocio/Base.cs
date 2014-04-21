using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using PlataformaComercio.FrameWork.Configuracion;

namespace PlataformaComercio.Business
{
    public abstract class Base
    {
        protected IUnityContainer dataContainer;
           public Base()
           {
               dataContainer = GeneralConfiguration.GetGeneralContainer();

           }
    }
}
