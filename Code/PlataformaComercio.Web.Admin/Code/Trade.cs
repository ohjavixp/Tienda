using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PlataformaComercio.Web.Admin
{
     [MetadataType(typeof(TradeMetadata))]
    public partial class Trade
    {
        public Trade()
        {
            PlataformaComercioEntities e = new PlataformaComercioEntities();
            
        }
    }

    public class TradeMetadata
    {
        [System.ComponentModel.DataAnnotations.Editable(false)]
        public object LastMod { get; set; }
    }
}