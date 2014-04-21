using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.User;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.Shipping;
using PlataformaComercio.Entities.Payment;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business
{
    public class Catalog:Base
    {
        #region Private Fields
        ICatalogDA catalogDA;        
        #endregion

        #region Constructors
        public Catalog()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }
        #endregion

        #region Payment
        /// <summary>
        /// Obtiene el tipo de pago especificado
        /// </summary>
        /// <param name="paymentId">Id del tipo de pago</param>
        /// <returns><see cref="EntPayment"/></returns>
        public EntPayment GetPayment(int paymentId)
        {
            return catalogDA.GetPayment(paymentId);
        }
        #endregion

        #region Search
        /// <summary>
        /// Agrega un termino de busqueda no localizado
        /// </summary>
        /// <param name="inventoryId">Identificador del inventario</param>
        /// <param name="searchString">Criterio de busqueda</param>
        public void AddSearchNotFound(string inventoryId, string searchString)
        {
            catalogDA.AddSearchNotFound(inventoryId, searchString);
        }
        #endregion

        #region Properties
        public void GetPropertySubCategories(int propertyCategory)
        { 

        }
        #endregion

        public EntNeighborghood GetNeighborghoodByZipCodeAndId(int neighborghoodId, string zipCode)
        {
            return catalogDA.GetNeighborghoodByZipCodeAndId(neighborghoodId, zipCode);
        }

        /// <summary>
        /// Obtiene un listado de colonias a partir del código postal
        /// </summary>
        /// <param name="zipCode">Código postal</param>
        /// <param name="fillParentInfo">Especifica si se llenará la información de delegación/municipio, estado, pais</param>
        /// <returns>Las colonias localizadas</returns>
        /// <exception cref="UserException">En caso de no especificar el código postal</exception>        
        public EntNeighborghood[] GetNeighborghoodsByZipCode(string zipCode,bool fillParentInfo)
        {

            if (string.IsNullOrEmpty(zipCode))
                throw new UserException("Debe proporcionar el código postal");

            EntNeighborghood[] entNeighborghoods = catalogDA.GetNeighborghoodByZipCode(zipCode);

            if (!fillParentInfo)
                return entNeighborghoods;


            if (entNeighborghoods.Length > 0)
            {
                EntCounty entCounty = catalogDA.GetCounty(entNeighborghoods[0].CountryID, entNeighborghoods[0].EstateID, entNeighborghoods[0].CountyID);
                EntState entState = catalogDA.GetState(entNeighborghoods[0].CountryID, entNeighborghoods[0].EstateID);
                EntCountry entCountry = catalogDA.GetCountry(entNeighborghoods[0].CountryID);

                foreach (var item in entNeighborghoods)
                {
                    item.County = entCounty;
                    item.County.Estate = entState;
                    item.County.Estate.Country = entCountry;
                }
            }            

            return entNeighborghoods;
        }

        /// <summary>
        /// Obtiene los métodos de envio
        /// </summary>
        /// <param name="shippingCostKey">Clave del método a buscar</param>
        /// <returns></returns>
        public EntShippingMethod[] GetShippingMethods(string shippingCostKey)
        {
            return catalogDA.GetShippingMethods(shippingCostKey);
        }

        public EntShippingMethod GetShippingMethod(int shippingMethod)
        {
            return catalogDA.GetShippingMethod(shippingMethod);
        }

        /// <summary>
        /// Obtiene el costo de envío
        /// </summary>
        /// <param name="shippingCostId">Id del método de envío</param>
        /// <returns>Costo del envío</returns>
        public decimal GetShippingCost(int shippingCostId)
        {
            return catalogDA.GetShippingCost(shippingCostId);
        }
    }
}
