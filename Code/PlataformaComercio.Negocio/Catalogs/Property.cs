using System;
using Microsoft.Practices.Unity;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.Business.Catalogs
{
    public partial class Property : Base
    {
        #region Private Fields

        ICatalogDA catalogDA;

        #endregion Private Fields

        #region Constructors

        public Property()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }

        #endregion Constructors

        public Int32 Add(EntProperty entProperty)
        {
            Validate(entProperty);
            return catalogDA.Property.Add(entProperty);
        }

        public bool Update(EntProperty entProperty)
        {
            Validate(entProperty);
            return catalogDA.Property.Update(entProperty);
        }

        public EntProperty GetByID(Int32 PropertyId)
        {
            return catalogDA.Property.GetByID(PropertyId);
        }

        public bool Delete(Int32 PropertyId)
        {
            return catalogDA.Property.Delete(PropertyId);
        }

        private static void Validate(EntProperty entProperty)
        {
            Util.Validate<EntProperty>(entProperty);
        }
    }

    #region Extended

    public partial class Property
    {
        public EntProperty[] GetByCategoryAndSubCategoryId(int categoryID, int subCategoryID)
        {
            return catalogDA.Property.GetByCategoryAndSubCategoryId(categoryID, subCategoryID);
        }
    }

    #endregion Extended
}