using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.User;

namespace PlataformaComercio.Entities.Basket
{
    public class EntShippingAddress
    {
        public Guid BasketID { get; set; }        
        public int NeighborghoodID { get; set; }     
        public string StreetNumber { get; set; }
        public string StreetInternalNumber { get; set; }
        public string StreetBetween { get; set; }
        public string AddressName { get; set; }
        public string TelephoneContact { get; set; }
        public string Comments { get; set; }
        public string Street { get; set; }
        public int ShippingId { get; set; }

        public int CountryID { get; set; }

        public string ZipCode { get; set; }
    }
}
