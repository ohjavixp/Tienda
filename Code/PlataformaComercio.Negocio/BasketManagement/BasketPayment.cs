using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Basket;

namespace PlataformaComercio.Business.BasketManagement
{
    public class PaymentMethod
    {
        #region Private Fields
        private IBasketDA basketDA;   
        private Guid basketID;
        #endregion

        public PaymentMethod(IBasketDA basketDA, Guid basketID)
        {
            this.basketDA = basketDA;
            this.basketID = basketID;
        }

        public bool Add(EntBasketPayment basketPayment)
        {
            basketDA.AddPaymentMethod(basketPayment,basketID);
            return true;
        }

        /// <summary>
        /// Tipo de pago
        /// </summary>        
        public EntBasketPayment Payment
        {
            get
            {
                EntBasketPayment basketPayment = basketDA.GetBasketPayment(basketID);
                Catalog catalog = new Catalog();
                basketPayment.PaymentType = catalog.GetPayment(basketPayment.PaymentId);
                return basketPayment;
            }
        }

        /// <summary>
        /// Borra todas las formas de pago
        /// </summary>
        /// <returns>true si la eliminación fue correcta</returns>
        public bool DeleteAll()
        {
            return basketDA.DeleteAllPaymentMethods(basketID);
            
        }
    }
}
