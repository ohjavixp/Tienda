using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business.BasketManagement
{
    public class Basket:Base
    {
        #region Private Fields
        private IBasketDA basketDA;
        private Guid basketID;
        private BasketShipping shipping;
        private PaymentMethod paymentMethod;
        private decimal subTotal;
        private decimal totalWeight;
        private decimal shippingCost;
        #endregion


        #region Private Methods
        private void InternalContructor(string name, Guid? userID)
        {            
            basketDA = dataContainer.Resolve<IBasketDA>();


            if (string.IsNullOrEmpty(name))
                return;

            if (!userID.HasValue)
                return;

            EntBasket entBasket = basketDA.Get(userID.Value, name);

            if (entBasket == null)
            {
                entBasket = new EntBasket();
                entBasket.Name = name;
                entBasket.CreationDate = DateTime.Now;
                entBasket.LastUpdateDate = DateTime.Now;
                entBasket.UserID = userID.Value;
                entBasket.IsAnonymous = !Thread.CurrentPrincipal.Identity.IsAuthenticated;
                basketID = basketDA.Add(entBasket);
            }
            else
            {
                basketID = entBasket.ID;
            }

            GetLines();

            
        }

        private void GetLines()
        {
            Lines = new BasketLineCollection(basketID);
            subTotal = 0;

            for (int i = 0; i < Lines.Count; i++)
            {
                subTotal += Lines[i].Total;
                totalWeight += Lines[i].TotalWeight;
            }
        }
        #endregion

        #region Constructors
       
        /// <summary>
        /// Obtiene una instancia a partir del nombre del carrito y el usuario actual autenticado
        /// </summary>
        /// <param name="name">Nombre del carrito</param>
        public Basket(string name)
        {
            InternalContructor(name, new Guid(Thread.CurrentPrincipal.Identity.Name));
        }

        /// <summary>
        /// Obtiene una nueva instancia
        /// </summary>
        /// <param name="name">Nombre del carrito</param>
        /// <param name="userID">Usuario al que pertenece el carrito</param>
        public Basket(string name, Guid userID)
        {
            InternalContructor(name, userID);
        }

        /// <summary>
        /// Obtiene un Carrito de compras a partir de su identificador
        /// </summary>
        /// <param name="basketId">Identificador del carrito de compras</param>
        public Basket(Guid basketId)
        {
            if (basketID == null)
                throw new ArgumentNullException("basketID");

            basketDA = dataContainer.Resolve<IBasketDA>();
            this.basketID = basketId;
            GetLines();
        }  
        #endregion


        #region Properties
        /// <summary>
        /// Identificador del carrito de compras
        /// </summary>
        public Guid BasketId
        {
            get
            {
                return basketID;
            }
        }

        public BasketShipping Shipping
        {
            get
            {
                if (shipping == null)
                {
                    shipping = new BasketShipping(basketDA, basketID,this);
                }
                return shipping;
            }
        }

        public PaymentMethod PaymentMethod
        {
            get
            {
                if (paymentMethod == null)
                    paymentMethod = new PaymentMethod(basketDA, basketID);
                return paymentMethod;
            }
        }

        public BasketLineCollection Lines { get; set; }
        /// <summary>
        /// SubTotal del carrito
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return subTotal;
            }
        }

        /// <summary>
        /// Costo de envio
        /// </summary>
        public decimal ShippingCost
        {
            get
            {
                return shippingCost;
            }
        }
        /// <summary>
        /// Total de la compra, incluye descuentos, gastos de envio, y total de productos
        /// </summary>
        public decimal Total
        {
            get
            {
                decimal total = subTotal + Shipping.ShippingMethods.ShippingCost;
                return total;
            }
        }

        /// <summary>
        /// Peso total de la orden
        /// </summary>
        public decimal TotalWeight
        {
            get
            {
                return totalWeight;
            }
        }
        #endregion       

        

        public void Delete()
        {
            if (basketID == null)
                throw new ArgumentNullException("BasketId");

            Delete(basketID);
        }

        public void Delete(Guid basketID)
        {
            basketDA.Delete(basketID);
        }


        /// <summary>
        /// Realiza la migración de un carrito de compras de un usuario anonimo a un usuario autenticado
        /// </summary>
        /// <param name="basketName">nombre del carrito</param>
        public static void MigrateFromAnonymousUser(string basketName)
        {
            if (!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                throw new Exception("No se puede realizar la migración por que el usuario actual no está autenticado");
            
            Authentication authentication = new Authentication();
            Guid anonymousUserID = authentication.GetAnonymousUserID();
            Guid authenticatedUserID = new Guid(Thread.CurrentPrincipal.Identity.Name);

            //El ID del usuario anonimo es el mismo del usuario autenticado
            if (anonymousUserID.Equals(authenticatedUserID))
                return;

            Basket anonymousBasket = new Basket(basketName,anonymousUserID);

            if (anonymousBasket.Lines.Count > 0)
            {
                Basket currentUserBasket = new Basket(basketName);

                //TODO: Revisar para multiples lineas
                EntBasketProduct[] anonymousBasketProducts = anonymousBasket.Lines[0].GetProducts(false);

                if (currentUserBasket.Lines.Count == 0)
                    currentUserBasket.Lines.Add("default");

                foreach (var item in anonymousBasketProducts)
                {
                    currentUserBasket.Lines[0].AddProduct(item.SKU, item.Quantity, true);
                }
            }

            anonymousBasket.Delete();
        }
    }
}
