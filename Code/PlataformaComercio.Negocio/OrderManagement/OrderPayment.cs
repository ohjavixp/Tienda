using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Business.OrderManagement
{
    public class OrderPayment
    {
        private int orderId;
        private IOrderDA orderDA;

        public OrderPayment(int orderId, IOrderDA orderDA)
        {
            this.orderId = orderId;
            this.orderDA = orderDA;
        }

        /// <summary>
        /// Tipo de pago
        /// </summary>        
        public EntOrderPayment[] Payment
        {
            get
            {
                EntOrderPayment[] basketPayment = orderDA.GetOrderPayment(this.orderId);
                Catalog catalog = new Catalog();

                foreach (var item in basketPayment)
                {
                    item.PaymentType = catalog.GetPayment(item.PaymentId);
                }

                return basketPayment;
            }
        }
    }
}
