using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;

namespace PlataformaComercio.UI.Routing
{
    public interface IGenericDisplay : IHttpHandler
    {
        RouteValueDictionary RoutedValues { get; set; }
        
    }
}
