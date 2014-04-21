using PlataformaComercio.Datos.Fachada;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace PlataformaComercio.Business.OrderManagement
{
    public class OrderCatalog : Base
    {
        #region Private Fields
        IOrderDA orderDA;
        #endregion

        #region Constructors
        public OrderCatalog()
        {
            orderDA = dataContainer.Resolve<IOrderDA>();
        }
        #endregion

        public Order[] GetAll()
        {
            List<Order> orders = new List<Order>();
            var entOrders = this.orderDA.GetAll();

            foreach (var item in entOrders)
            {
                orders.Add(new Order(item));
            }

            return orders.ToArray();
        }

        public Order GetById(int orderId)
        {
            var entOrder = this.orderDA.GetById(orderId);

            if (entOrder == null)
            {
                return null;
            }

            return new Order(entOrder);
        }
    }
}
