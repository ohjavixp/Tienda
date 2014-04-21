using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.User
{
    public class EntNeighborghood
    {
        public EntCounty County { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public int CountryID { get; set; }        
        public int EstateID { get; set; }
        public int CountyID { get; set; }
    }
}
