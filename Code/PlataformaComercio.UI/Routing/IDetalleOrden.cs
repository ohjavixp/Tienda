using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PlataformaComercio.UI.Routing
{
    public interface IDetalleOrden : IHttpHandler
    {
        string OrderId { get; set; }
    }
}
