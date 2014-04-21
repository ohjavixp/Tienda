using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PlataformaComercio.Entities.Product
{
    public class EntBaseProduct
    {
        [NotNullValidator]
        [StringLengthValidator(50)]
        public string BaseProductId { get; set; }

        [NotNullValidator]
        [StringLengthValidator(50)]
        public string Name { get; set; }

        [NotNullValidator]
        public bool IsActive { get; set; }

        [NotNullValidator]
        public DateTime LastMod { get; set; }

        [NotNullValidator]
        public int TradeId { get; set; }

        [NotNullValidator]
        public int PropertyCategoryID { get; set; }

        [NotNullValidator]
        public int PropertySubCategoryID { get; set; }
    }
}