using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;

namespace PlataformaComercio.Business.BasketManagement
{
    public class BasketShipping
    {
        #region Private Fields
        private IBasketDA basketDA;   
        private Guid basketID;
        private Basket basket;
        #endregion

        public BasketShipping(IBasketDA basketDA, Guid basketID,Basket basket)
        {
            this.basketDA = basketDA;
            this.basketID = basketID;
            this.basket = basket;

            ShippingAddress = new BasketShippingAddress(basketDA, basketID);
            ShippingMethods = new BasketShippingMethods(basketDA, basketID,basket);
        }

        public BasketShippingAddress ShippingAddress { get; set; }

        public BasketShippingMethods ShippingMethods { get; set; }
        
    }
}
