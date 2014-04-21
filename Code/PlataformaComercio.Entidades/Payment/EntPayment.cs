using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Payment
{
    public class EntPayment
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
