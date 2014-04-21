using System;
using System.Text;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.Datos.Fachada.Catalog
{
	public partial interface IProperty
	{
		Int32 Add(EntProperty entProperty);

		bool Update(EntProperty entProperty);

		EntProperty GetByID(Int32 PropertyId);

		bool Delete(Int32 PropertyId);
        
    }

    #region Extended
    public partial interface IProperty
    {
        EntProperty[] GetByCategoryAndSubCategoryId(int categoryID, int subCategoryID);
    }
    #endregion
}
