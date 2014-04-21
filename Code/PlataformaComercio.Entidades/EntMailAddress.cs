using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities
{
    public class EntMailAddress
    {
        public int id { get; set; }
        public string mail {get; set;}
        public string host {get; set;}
        public string password {get; set;}
        public int port { get; set; }
    }
}
