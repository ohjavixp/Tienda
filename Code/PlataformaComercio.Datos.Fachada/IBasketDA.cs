using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.Entities.Shipping;

namespace PlataformaComercio.Datos.Fachada
{
    public interface IBasketDA
    {        
        EntBasket Get(Guid userId, string basketName);
        Guid Add(EntBasket entBasket);
        bool Delete(Guid basketID);

        #region Payment
        bool AddPaymentMethod(EntBasketPayment paymentMethod, Guid basketId);
        bool DeleteAllPaymentMethods(Guid basketId);
        EntBasketPayment GetBasketPayment(Guid basketId);
        #endregion
        #region Shipping
        bool AddShippingAddress(EntShippingAddress shippingAddress);
        bool UpdateShippingAddress(EntShippingAddress shippingAddress);
        EntShippingAddress GetShippingAddress(Guid basketID);

        void AddShippingMethod(Guid basketId,int shippingId, int shippingCostId);
        void UpdateShippingMethod(Guid basketId, int shippingId, int shippingCostId);
        /// <summary>
        /// Obtiene el identificador del método de envio seleccionado
        /// </summary>
        /// <param name="basketId">id del carrito</param>
        /// <param name="shippingId">id  de compra</param>
        /// <returns></returns>
        int GetShippingMethod(Guid basketId, int shippingId);
        #endregion
    }
}
