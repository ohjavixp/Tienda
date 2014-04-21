using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Shipping
{
    public class EntShippingMethod
    {
        public int ShippingCostId { get; set; }
        public EntShippingCompany Company { get; set; }
        public EntShippingType ShippingType { get; set; }
        public decimal Cost { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal AditionalCost { get; set; }
        public bool IsActive { get; set; }

    }
}
