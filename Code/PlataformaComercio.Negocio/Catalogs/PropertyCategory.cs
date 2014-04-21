using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

using PlataformaComercio.Entities;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.Datos.Fachada;

namespace PlataformaComercio.Business.Catalogs
{
	public class PropertyCategory : Base
	{
        #region Private Fields
        ICatalogDA catalogDA;
        #endregion

		public PropertyCategory()
		{
            catalogDA = dataContainer.Resolve<ICatalogDA>();
		}

		public Int32 Add(EntPropertyCategory entPropertyCategory)
		{
			Validate(entPropertyCategory);
            return catalogDA.PropertyCategory.Add(entPropertyCategory);
		}

		public bool Update(EntPropertyCategory entPropertyCategory)
		{
			Validate(entPropertyCategory);
            return catalogDA.PropertyCategory.Update(entPropertyCategory);
		}

		public EntPropertyCategory GetByID(Int32 PropertyCategoryId)
		{
            return catalogDA.PropertyCategory.GetByID(PropertyCategoryId);
		}

		public bool Delete(Int32 PropertyCategoryId)
		{
            return catalogDA.PropertyCategory.Delete(PropertyCategoryId);
		}

        public EntPropertyCategory[] GetAll()
        {
            return catalogDA.PropertyCategory.GetAll();
        }

		private  void Validate(EntPropertyCategory entPropertyCategory)
		{
            Util.Validate<EntPropertyCategory>(entPropertyCategory);
		}

	}
}

