using System;
using System.Text;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.Datos.Fachada.Catalog
{
	public interface IPropertyCategory
	{
		Int32 Add(EntPropertyCategory entPropertyCategory);

		bool Update(EntPropertyCategory entPropertyCategory);

		EntPropertyCategory GetByID(Int32 PropertyCategoryId);

		bool Delete(Int32 PropertyCategoryId);

        EntPropertyCategory[] GetAll();
        

	}
}
