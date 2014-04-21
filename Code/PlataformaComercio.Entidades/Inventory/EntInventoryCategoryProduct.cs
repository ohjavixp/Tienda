using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Inventory
{
    public class EntInventoryCategoryProduct
    {
        public string InventoryID { get; set; }
        public int CategoryID { get; set; }
        public string ProductID { get; set; }
        public bool IsPrimary { get; set; }        
        public bool IsActive { get; set; }        
        public short Order { get; set; }


    }
}
