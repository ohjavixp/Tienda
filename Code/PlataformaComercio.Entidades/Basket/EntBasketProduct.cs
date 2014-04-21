using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Inventory;

namespace PlataformaComercio.Entities.Basket
{
    public class EntBasketProduct
    {
        public decimal Quantity { get; set; }
        public int BasketDetailID { get; set; }
        public string SKU { get; set; }
        public decimal Total { get; set; }
        public EntProduct Product { get; set; }
    }
}
