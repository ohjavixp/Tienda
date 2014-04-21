using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Inventory
{
    public class EntInventoryCategory
    {
        public string InventoryID { get; set; }
        public int CategoryID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool IsActive { get; set; }
        public bool Show { get; set; }
        public short Order { get; set; }
        
    }
}
