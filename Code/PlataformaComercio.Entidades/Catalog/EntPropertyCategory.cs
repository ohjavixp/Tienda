using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace PlataformaComercio.Entities.Catalog
{
	public class EntPropertyCategory
	{
		[NotNullValidator]
		public int PropertyCategoryId { get; set; }

		[NotNullValidator]
		[StringLengthValidator(50)]
		public string Name { get; set; }

		[NotNullValidator]
		public bool IsActive { get; set; }

	}
}
