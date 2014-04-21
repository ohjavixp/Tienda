using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.User
{
    public class EntCounty
    {
        public int CountryID { get; set; }
        public int EstateID { get; set; }        
        public int ID { get; set; }
        public string Name { get; set; }
        public EntState Estate { get; set; }
    }
}
