using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Basket
{
    public class EntBasketDetail
    {
        public Guid BasketID { get; set; }
        public int LineID { get; set; }
        public int BasketDetailID { get; set; }
        public string InventoryID { get; set; }
        public string Sku { get; set; }
        public int? ProductCategoryID { get; set; }
        public decimal Quantity { get; set; }
    }
}
