using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Basket
{
    public class EntBasket
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid UserID { get; set; }        
        public bool IsAnonymous { get; set; }
    }
}
