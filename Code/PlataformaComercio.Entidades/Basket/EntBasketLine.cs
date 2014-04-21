using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Basket
{
    public class EntBasketLine
    {
        public Guid BasketID { get; set; }
        public int LineID { get; set; }
        public string Name { get; set; }
    }
}
