using System;
using System.Text;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.Datos.Fachada.Catalog
{
	public interface IPropertySubCategory
	{
		bool Add(EntPropertySubCategory entPropertySubCategory);

		bool Update(EntPropertySubCategory entPropertySubCategory);

		EntPropertySubCategory GetByID(Int32 PropertyCategoryId, Int32 PropertySubCategoryId);

        EntPropertySubCategory[] GetByCategoryID(Int32 PropertyCategoryId);

		bool Delete(Int32 PropertyCategoryId, Int32 PropertySubCategoryId);

	}
}
