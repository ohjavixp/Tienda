using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Entities.Product;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Threading;

namespace PlataformaComercio.Business.Catalogs
{
    public class BaseProduct:Base
    {
         #region Private Fields
        ICatalogDA catalogDA;
        #endregion

        #region Constructors
        public BaseProduct()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }
        #endregion

        #region Public Methods
        public String Add(EntBaseProduct entBaseProduct)
        {
            entBaseProduct.LastMod = DateTime.Now;
            Validate(entBaseProduct);
            return catalogDA.BaseProduct.Add(entBaseProduct);
        }

        public bool Update(EntBaseProduct entBaseProduct)
        {
            entBaseProduct.LastMod = DateTime.Now;
            Validate(entBaseProduct);
            return catalogDA.BaseProduct.Update(entBaseProduct);
        }

        public EntBaseProduct GetByID(String baseProductId)
        {
            return catalogDA.BaseProduct.GetByID(baseProductId);
        }

        public bool Delete(String BaseProductId)
        {
            return catalogDA.BaseProduct.Delete(BaseProductId);
        }

        object objLock = new Object();
        private  void Validate(EntBaseProduct entBaseProduct)
        {
            Util.Validate<EntBaseProduct>(entBaseProduct);
        }
        
        #endregion
    }
}
