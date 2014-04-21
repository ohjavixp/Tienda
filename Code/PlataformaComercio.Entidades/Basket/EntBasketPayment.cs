using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Payment;

namespace PlataformaComercio.Entities.Basket
{
    public class EntBasketPayment
    {        
        public int PaymentId { get; set; }
        public decimal TotalPayed { get; set; }
        public Int16 Status { get; set; }
        public EntPayment PaymentType { get; set; }
    }
}
