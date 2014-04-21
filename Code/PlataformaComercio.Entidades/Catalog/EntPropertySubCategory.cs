using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PlataformaComercio.Entities.Catalog
{
	public class EntPropertySubCategory
	{
		[NotNullValidator]
		public int PropertyCategoryId { get; set; }

		[NotNullValidator]
		public int PropertySubCategoryId { get; set; }

		[NotNullValidator]
		[StringLengthValidator(50)]
		public string Name { get; set; }

		[NotNullValidator]
		public bool IsActive { get; set; }

	}
}
