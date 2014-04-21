using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Order
{
    public class EntOrderProduct
    {
        public int OrderId { get; set; }
        public int LineId { get; set; }
        public int OrderLineDetailID { get; set; }
        public string InventoryId { get; set; }
        public string Sku { get; set; }
        public int ProductCategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
