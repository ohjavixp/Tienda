using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using PlataformaComercio.Entities;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.Datos.Fachada;

namespace PlataformaComercio.Business
{
	public class PropertySubCategory : Base
	{
        #region Private Fields
        ICatalogDA catalogDA;
        #endregion
		
		public PropertySubCategory()
		{
            catalogDA = dataContainer.Resolve<ICatalogDA>();
		}

		public bool Add(EntPropertySubCategory entPropertySubCategory)
		{
			Validate(entPropertySubCategory);
            return catalogDA.PropertySubCategory.Add(entPropertySubCategory);
		}

		public bool Update(EntPropertySubCategory entPropertySubCategory)
		{
			Validate(entPropertySubCategory);
            return catalogDA.PropertySubCategory.Update(entPropertySubCategory);
		}

		public EntPropertySubCategory GetByID(Int32 PropertyCategoryId, Int32 PropertySubCategoryId)
		{
            return catalogDA.PropertySubCategory.GetByID(PropertyCategoryId, PropertySubCategoryId);
		}

		public bool Delete(Int32 PropertyCategoryId, Int32 PropertySubCategoryId)
		{
            return catalogDA.PropertySubCategory.Delete(PropertyCategoryId, PropertySubCategoryId);
		}

        public EntPropertySubCategory[] GetByCategoryID(Int32 PropertyCategoryId)
        {
            return catalogDA.PropertySubCategory.GetByCategoryID(PropertyCategoryId);
        }

		private static void Validate(EntPropertySubCategory entPropertySubCategory)
		{
            Util.Validate<EntPropertySubCategory>(entPropertySubCategory);
		}

	}
}

