using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Inventory
{
    public class EntInventoryProduct
    {
        public string InventoryID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
