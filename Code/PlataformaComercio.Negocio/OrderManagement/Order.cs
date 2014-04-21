
namespace PlataformaComercio.Business.OrderManagement
{
    using Microsoft.Practices.Unity;
    using PlataformaComercio.Business.BasketManagement;
    using PlataformaComercio.Business.Core;
    using PlataformaComercio.Business.Enums;
    using PlataformaComercio.Datos.Fachada;
    using PlataformaComercio.Entities;
    using PlataformaComercio.Entities.Order;
    using PlataformaComercio.FrameWork.Configuracion;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Configuration;
    using System.Threading;
    using System.Transactions;
    using System.Web;
    using System.Web.Configuration;

    public class Order : Base
    {
        #region Private Fields
        private IOrderDA orderDA;
        private int orderId;
        private DateTime creationDate;
        private DateTime lastUpdate;
        private Guid userID;
        private EOrderStatus status;
        private decimal subTotal;
        private string clientName;
        private OrderShipping shipping;
        private OrderPayment paymentMethod;

        /// <summary>
        /// Orden actual
        /// </summary>
        private EntOrders entOrder;
        #endregion

        #region Properties
        public int OrderId { get { return orderId; } }
        public DateTime CreationDate { get { return creationDate; } }
        public DateTime LastUpdate { get { return lastUpdate; } }
        public Guid UserID { get { return userID; } }
        public EOrderStatus Status { get { return status; } }
        public decimal SubTotal { get { return subTotal; } }
        public decimal Total { get { return subTotal; } }
        public string ClientName { get { return clientName; } }
        #endregion

        #region Constructors
        public Order()
        {
            orderDA = dataContainer.Resolve<IOrderDA>();
        }

        internal Order(EntOrders entOrder)
        {
            this.orderDA = dataContainer.Resolve<IOrderDA>();

            if (entOrder == null)
            {
                return;
            }

            this.entOrder = entOrder;
            this.orderId = entOrder.OrderId;
            this.creationDate = entOrder.CreationDate;
            this.lastUpdate = entOrder.LastUpdate;
            this.userID = entOrder.UserID;
            this.status = (EOrderStatus)entOrder.Status;
            this.subTotal = entOrder.SubTotal;
            this.clientName = entOrder.ClientName;

        }
        #endregion

        public EntOrderProduct[] Products
        {
            get
            {
                if (entOrder == null)
                {
                    return null;
                }

                return this.orderDA.GetProducts(entOrder.OrderId);
            }

        }

        public OrderPayment PaymentMethod
        {
            get
            {
                if (paymentMethod == null)
                {
                    paymentMethod = new OrderPayment(this.orderId, this.orderDA);
                }

                return paymentMethod;
            }
        }

        /// <summary>
        /// Crea una orden de compra a partir de un carrito de compras existente
        /// </summary>
        /// <param name="basketId">Identificador del carrito de compras a migrar</param>
        /// <param name="deleteBasket">Especifica si el carrito de compras será eliminado despues de hacer la conversión</param>
        /// <returns>Número de Orden asignada</returns>
        public int CreateFromBasket(Guid basketId, bool deleteBasket)
        {
            int orderId = -1;
            decimal totalOrden = 0;

            if (basketId == null)
                throw new ArgumentNullException("basketId");

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                orderId = orderDA.ConvertFromBasket(basketId);

                if (deleteBasket)
                {
                    Basket basket = new Basket(basketId);
                    totalOrden = basket.Total;
                    basket.Delete();
                }

                scope.Complete();

            }

            //Se hace afuera de la transacción para no detener en caso de falla en el smtp
            if (orderId != -1)
            {
                Configuration c = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                MailSettingsSectionGroup configuration = (MailSettingsSectionGroup)c.GetSectionGroup("system.net/mailSettings");
                EmailSendConfig emailConfig = new EmailSendConfig();
                emailConfig.From = configuration.Smtp.From;
                User user = new User();
                emailConfig.TO = user.GetByID(new Guid(Thread.CurrentPrincipal.Identity.Name)).EmailAddress;
                emailConfig.Subjet = "Confirmación de Orden " + orderId.ToString();
                emailConfig.IsBodyHtml = true;
                emailConfig.Template = EmailSendTemplate.OrderConfirmTransfer;
                try
                {
                    List<string> parameters = new List<string>();
                    EmailManagement.SendEmailFromTemplate(emailConfig, orderId.ToString(), totalOrden.ToString("c"));
                }
                catch (Exception)
                {
                    //TODO : Log Excepción
                    //NO Hace nada ya que no es un error critico
                }

            }

            return orderId;
        }

        /// <summary>
        /// Crea una orden de compra a partir del carrito de compras actual (Predeterminado)
        /// </summary>
        /// <param name="basketId">Identificador del carrito de compras a migrar</param>
        /// <param name="deleteBasket">Especifica si el carrito de compras será eliminado despues de hacer la conversión</param>
        /// <returns>Número de Orden asignada</returns>
        public int CreateFromBasket(bool deleteBasket)
        {
            Basket basket = new Basket(BasketConfiguration.DefaultBasketName);
            int orderId = CreateFromBasket(basket.BasketId, deleteBasket);
            return orderId;
        }

        public OrderShipping Shipping
        {
            get
            {
                if (shipping == null)
                {
                    shipping = new OrderShipping(this.entOrder.OrderId, this.orderDA);
                }
                return shipping;
            }
        }


    }

}
