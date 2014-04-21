using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.User
{
    public class EntUserAddress
    {
        public Guid UserID { get; set; }
        public int AddressID { get; set; }
        public int CountryID { get; set; }
        public string ZipCode { get; set; }
        public string StreetNumber { get; set; }
        public string StreetInternalNumber { get; set; }
        public string StreetBetween { get; set; }
        public string AddressName { get; set; }
        public string TelephoneContact { get; set; }
        public string Comments { get; set; }
        public string Street { get; set; }
        public int NeighborghoodID { get; set; }
    }       
}
