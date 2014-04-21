using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Shipping;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Entities.User;

namespace PlataformaComercio.Business.BasketManagement
{
    public class BasketShippingMethods
    {
        #region Private Fields
        private IBasketDA basketDA;
        private Guid basketID;
        private Basket basket;        
        #endregion

        public BasketShippingMethods(IBasketDA basketDA, Guid basketID,Basket basket)
        {
            this.basketDA = basketDA;
            this.basketID = basketID;
            this.basket = basket;
        }

        public EntShippingMethod ShippingMethod 
        {
            get
            {
                int result = basketDA.GetShippingMethod(basketID, 1);
                if (result != -1)
                {
                    Catalog catalog = new Catalog();
                    return catalog.GetShippingMethod(result);
                }
                else
                    return null;
            }
        }
        
        public EntShippingMethod[] GetShippingMethods()
        {

            if (basket.Shipping.ShippingAddress.Address == null)
                throw new InternalException("No se ha especificado la dirección de envío");


            Catalog catalog = new Catalog();
            EntNeighborghood entNeighborghood = catalog.GetNeighborghoodByZipCodeAndId(basket.Shipping.ShippingAddress.Address.NeighborghoodID, basket.Shipping.ShippingAddress.Address.ZipCode);

            string shippingCostKey = string.Empty;
            EntShippingMethod[] shippingMethods;
            
            //Busqueda por municipio
            shippingCostKey = string.Format("IdPais:{0}|IdEstado:{1}|IdMunicipio:{2}", entNeighborghood.CountryID,entNeighborghood.EstateID,entNeighborghood.CountyID);
            shippingMethods = catalog.GetShippingMethods(shippingCostKey);

            if (shippingMethods.Count() <= 0)
            { 
                //Busca por Estado
                shippingCostKey = string.Format("IdPais:{0}|IdEstado:{1}", entNeighborghood.CountryID, entNeighborghood.EstateID);
                shippingMethods = catalog.GetShippingMethods(shippingCostKey);
            }

            //Busca costos de envio por peso
            if (shippingMethods.Count() > 0)
            {                
                shippingMethods = shippingMethods.Where(Costo => basket.TotalWeight <= Costo.MaxWeight ).OrderBy(Costo => Costo.MaxWeight).Take(1).ToArray();

            }

            return shippingMethods;
        }

        /// <summary>
        /// Agrega un nuevo método de envio
        /// </summary>
        /// <param name="shippingCostId">Id del costo de envío</param>
        public void Add(int shippingCostId)
        {
            basketDA.AddShippingMethod(basketID, 1, shippingCostId);
        }

        /// <summary>
        /// Actualiza el método de envío
        /// </summary>
        /// <param name="shippingCostId">Id del costo de envío</param>
        public void Update(int shippingCostId)
        {
            basketDA.UpdateShippingMethod(basketID, 1, shippingCostId);
        }

        /// <summary>
        /// Agrega o actualiza el método de envio
        /// </summary>
        /// <param name="shippingCostId">Id del costo de envío</param>
        public void AddOrUpdate(int shippingCostId)
        {
            int result = basketDA.GetShippingMethod(basketID, 1);

            if (result != -1)
                Update(shippingCostId);
            else
                Add(shippingCostId);            
        }

        public decimal ShippingCost
        {
            get
            {
                int result = basketDA.GetShippingMethod(basketID, 1);

                if (result != 1)
                {
                    Catalog catalog = new Catalog();
                    return catalog.GetShippingCost(result);
                }
                else
                    return 0;
                
            }
        }
        
    }
}
