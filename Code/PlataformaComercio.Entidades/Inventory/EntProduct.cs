using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Entities.Inventory
{
    public class EntProduct
    {
        public string Inventory { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LargeDescription { get; set; }
        public string LargeDescriptionRaw { get; set; }    
        public Decimal Price { get; set; }
        public int TradeID { get; set; }
        public string TradeName { get; set; }
        public bool Image128 { get; set; }
        public string Image128Url { get; set; }
        public bool Image256 { get; set; }
        public string Image256Url { get; set; }
        public decimal Weight { get; set; }
        public bool IsActive { get; set; }
        public string Measure { get; set; }
        public int CurrencyID { get; set; }
        public string CurrencyIsoCode { get; set; }
    }
}
