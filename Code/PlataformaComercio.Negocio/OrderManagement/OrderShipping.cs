using PlataformaComercio.Datos.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Business.OrderManagement
{
    public class OrderShipping
    {
        private int orderId;
        IOrderDA orderDA;

        internal OrderShipping(int orderId, IOrderDA orderDA)
        {
            this.orderId = orderId;
            this.ShippingAddress = new OrderShippingAddress(orderId, orderDA);
            this.ShippingMethods = new OrderShippingMethods(orderId, orderDA);
            this.orderDA = orderDA;
        }

        public OrderShippingAddress ShippingAddress { get; set; }

        public OrderShippingMethods ShippingMethods { get; set; }
    }
}
