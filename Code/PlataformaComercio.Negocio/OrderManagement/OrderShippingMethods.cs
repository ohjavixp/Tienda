using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlataformaComercio.Business.OrderManagement
{
    public class OrderShippingMethods
    {
        private int orderId;
        private IOrderDA orderDA;

        public OrderShippingMethods(int orderId, IOrderDA orderDA)
        {
            this.orderId = orderId;
            this.orderDA = orderDA;
        }

        public EntShippingMethod ShippingMethod
        {
            get
            {
                int result = orderDA.GetShippingMethod(this.orderId);
                if (result != -1)
                {
                    Catalog catalog = new Catalog();
                    return catalog.GetShippingMethod(result);
                }
                else
                    return null;
            }
        }

        public decimal ShippingCost
        {
            get
            {
                decimal result = orderDA.GetShippingCost(this.orderId);
                return result;
            }
        }
    }
}
