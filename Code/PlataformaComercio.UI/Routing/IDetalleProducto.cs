using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace PlataformaComercio.UI.Routing
{
    public interface IDetalleProducto : IHttpHandler
    {
         string Sku { get; set; }
    }
}
