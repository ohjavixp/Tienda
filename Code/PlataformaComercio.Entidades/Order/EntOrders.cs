using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities
{
    public class EntOrders
    {
        public int OrderId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public Guid UserID { get; set; }
        public Int16 Status { get; set; }
        public decimal SubTotal { get; set; }
        public string ClientName { get; set; }
    }
}
