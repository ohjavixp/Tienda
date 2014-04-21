using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Business.OrderManagement
{
    public class OrderShippingAddress
    {
        private int orderId;
        IOrderDA orderDA;

        internal OrderShippingAddress(int orderId, IOrderDA orderDA)
        {
            this.orderId = orderId;
            this.orderDA = orderDA;

            this.Address = orderDA.GetShippingAddress(orderId);
        }

        public EntShippingAddress Address { get; set; }
    }
}
