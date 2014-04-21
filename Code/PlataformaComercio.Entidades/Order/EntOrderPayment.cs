using PlataformaComercio.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Order
{
    public class EntOrderPayment
    {
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
        public decimal TotalPayed { get; set; }
        public Int16 Status { get; set; }
        public EntPayment PaymentType { get; set; }
    }
}
