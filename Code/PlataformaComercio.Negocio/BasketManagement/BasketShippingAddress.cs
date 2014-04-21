using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.User;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.Datos.Fachada;

namespace PlataformaComercio.Business.BasketManagement
{
    public class BasketShippingAddress
    {
        #region Private Fields
        private IBasketDA basketDA;   
        private Guid basketID;
        #endregion

        public BasketShippingAddress(IBasketDA basketDA, Guid basketID)
        {
            this.basketDA = basketDA;
            this.basketID = basketID;

            Address = basketDA.GetShippingAddress(basketID);
        }

        public bool AddOrUpdate(EntUserAddress entUserAddress)
        {
            EntShippingAddress shippingAddress = new EntShippingAddress();
            shippingAddress.ShippingId = 1;
            shippingAddress.AddressName = entUserAddress.AddressName;
            shippingAddress.BasketID = basketID;
            shippingAddress.Comments = entUserAddress.Comments;
            shippingAddress.CountryID = entUserAddress.CountryID;
            shippingAddress.NeighborghoodID = entUserAddress.NeighborghoodID;
            shippingAddress.Street = entUserAddress.Street;
            shippingAddress.StreetBetween = entUserAddress.StreetBetween;
            shippingAddress.StreetInternalNumber = entUserAddress.StreetInternalNumber;
            shippingAddress.StreetNumber = entUserAddress.StreetNumber;
            shippingAddress.TelephoneContact = entUserAddress.TelephoneContact;
            shippingAddress.ZipCode = entUserAddress.ZipCode;

            return AddOrUpdate(shippingAddress);
        }

        /// <summary>
        /// Agrega o actualiza una unica dirección de envio. 
        /// Si no existe ninguna dirección se inserta una nueva, en caso de existir alguna se actualiza.
        /// </summary>
        /// <param name="address">Dirección a agregar</param>
        /// <returns>true en caso que la dirección se agrego correctamente</returns>
        public bool AddOrUpdate(EntShippingAddress address)
        {
            if (Address == null)
                return basketDA.AddShippingAddress(address);
            else
            {
                address.BasketID = Address.BasketID;
                return basketDA.UpdateShippingAddress(address);
            }
        }

        public EntShippingAddress Address { get; set; }
    }
}
