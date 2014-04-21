using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PlataformaComercio.Entities.Catalog
{
    public class EntProperty
    {
        [NotNullValidator]
        public int PropertyId { get; set; }

        [NotNullValidator]
        [StringLengthValidator(100)]
        public string Name { get; set; }

        [StringLengthValidator(100)]
        public string FriendlyName { get; set; }

        [NotNullValidator]
        public int PropertyCategoryId { get; set; }

        public int? PropertySubCategoryId { get; set; }

        [NotNullValidator]
        public Int16 Type { get; set; }

        [NotNullValidator]
        public bool IsRequired { get; set; }

        [NotNullValidator]
        public bool IsActive { get; set; }

        [NotNullValidator]
        public bool IsBase { get; set; }
    }
}