using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Order;

namespace PlataformaComercio.Datos.Fachada
{
    public interface IOrderDA
    {
        /// <summary>
        /// Crea una orden a partir de un carrito de compras
        /// </summary>
        /// <param name="basketId">Identificador del carrito de compras</param>
        /// <returns>número de orden</returns>
        int ConvertFromBasket(Guid basketId);

        /// <summary>
        /// Obtiene un arreglo de Ordenes
        /// </summary>
        /// <returns>Arreglo de EntOrders</returns>
        List<EntOrders> GetAll();

        /// <summary>
        /// Obtiene los productos de una orden
        /// </summary>
        /// <param name="orderId">Id de la orden</param>
        /// <returns>Productos</returns>
        EntOrderProduct[] GetProducts(int orderId);

        EntOrderShippingAddress GetShippingAddress(int orderId);

        EntOrderPayment[] GetOrderPayment(int orderId);

        decimal GetShippingCost(int orderId);

        int GetShippingMethod(int orderId);

        /// <summary>
        /// Obtiene la entidad Orden segun su Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>EntOrders</returns>
        EntOrders GetById(int Id);
    }
}
