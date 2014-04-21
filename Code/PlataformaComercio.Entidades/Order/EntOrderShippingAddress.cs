using PlataformaComercio.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Order
{
    public class EntOrderShippingAddress : EntShippingAddress
    {
        new private Guid BasketID { get; set; }
        public int OrderId { get; set; }
    }
}
