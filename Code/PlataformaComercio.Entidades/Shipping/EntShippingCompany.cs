using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Shipping
{
    public class EntShippingCompany
    {
        public int ShippingCompanyId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
