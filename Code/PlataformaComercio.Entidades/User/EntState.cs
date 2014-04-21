using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.User
{
    public class EntState
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public EntCountry Country { get; set; }

        public int CountryID { get; set; }

        
    }
}
