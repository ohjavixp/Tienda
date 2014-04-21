using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PlataformaComercio.Entities.Catalog
{
    public class EntCurrency
    {
        [NotNullValidator]
        public int CurrencyId { get; set; }

        [NotNullValidator]
        [StringLengthValidator(50)]
        public string Name { get; set; }

        [NotNullValidator]
        [StringLengthValidator(1)]
        public string Sign { get; set; }

        [NotNullValidator]
        [StringLengthValidator(3)]
        public string IsoCode { get; set; }

        [NotNullValidator]
        [NotNullValidator]
        public decimal ExchangeRate { get; set; }

    }
}
