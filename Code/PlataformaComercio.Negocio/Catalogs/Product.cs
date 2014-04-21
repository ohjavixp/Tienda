using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Exceptions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business.Catalogs
{
    public class Product:Base
    {
         #region Private Fields
        ICatalogDA catalogDA;
        #endregion

        #region Constructors
        public Product()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }
        #endregion

        #region Public Methods
        public EntProduct[] GetAll()
        {
            return catalogDA.GetAllProducts();
        }

        /// <summary>
        /// Obtiene un producto a partir de su id
        /// </summary>
        /// <param name="productID">Id del producto a obtener</param>
        /// <returns><see cref="EntProduct"/></returns>
        public EntProduct GetByID(string productID)
        {
            return catalogDA.GetProductByID(productID);
        }

        public bool Add(EntProduct product)
        {
            ValidateProduct(product);

            return catalogDA.AddProduct(product);
        }

        private static void ValidateProduct(EntProduct product)
        {
            if(string.IsNullOrEmpty(product.SKU))
                throw new UserException("Debe proporcionar el id del producto");

            if(string.IsNullOrEmpty(product.Name))
                throw new UserException("Debe proporcionar el nombre del producto");

            if(string.IsNullOrEmpty(product.ShortDescription))
                throw new UserException("Debe proporcionar la descripción corta del producto");

            if(product.ShortDescription.Length > 200)
                throw new UserException("La descripción corta del producto no debe ser superior a 200 caracteres");

            if(string.IsNullOrEmpty(product.LargeDescription))
                throw new UserException("Debe proporcionar la descripción larga del producto");

            if(string.IsNullOrEmpty(product.LargeDescriptionRaw))
                throw new UserException("Debe proporcionar la descripción larga del producto sin HTML");

            
        }

        public bool Update(EntProduct product)
        {
            ValidateProduct(product);

            return catalogDA.UpdateProduct(product);
        }
        public bool Delete(string productID)
        {
            return catalogDA.DeleteProduct(productID);
        }
        #endregion
    }
}
