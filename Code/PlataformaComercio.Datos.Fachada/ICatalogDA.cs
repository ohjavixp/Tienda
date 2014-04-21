using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Entities.Payment;
using PlataformaComercio.Entities.Shipping;
using PlataformaComercio.Entities.UI;
using PlataformaComercio.Entities.User;

namespace PlataformaComercio.Datos.Fachada
{
    public interface ICatalogDA
    {
        EntNeighborghood[] GetNeighborghoodByZipCode(string zipCode);

        EntCounty GetCounty(int countryID, int estateID, int countyID);

        EntState GetState(int countryID, int estateID);

        EntCountry GetCountry(int countryID);

        EntNeighborghood GetNeighborghoodByZipCodeAndId(int neighborghoodId, string zipCode);

        #region Payment

        EntPayment GetPayment(int paymentId);

        #endregion Payment

        #region Trades

        EntTrade[] GetAllTrades();

        EntTrade GetTradeByID(int tradeID);

        int AddTrade(EntTrade trade);

        bool UpdateTrade(EntTrade trade);

        bool DeleteTrade(int tradeID);

        EntTrade GetTradeByName(string tradeName);

        #endregion Trades

        #region Products

        EntProduct[] GetAllProducts();

        EntProduct GetProductByID(string productID);

        bool AddProduct(EntProduct product);

        bool UpdateProduct(EntProduct product);

        bool DeleteProduct(string productID);

        #endregion Products

        #region Shipping

        EntShippingMethod[] GetShippingMethods(string shippingCostKey);

        /// <summary>
        /// Obtiene el costo de envío
        /// </summary>
        /// <param name="shippingCostId">Id del método de envío</param>
        /// <returns>Costo del envío</returns>
        decimal GetShippingCost(int shippingCostId);

        /// <summary>
        /// Obtiene un método de envío
        /// </summary>
        /// <param name="shippingMethod">Identificador del método a obtner</param>
        /// <returns><see cref="EntShippingMethod"/></returns>
        EntShippingMethod GetShippingMethod(int shippingMethod);

        #endregion Shipping

        #region Search

        void AddSearchNotFound(string inventoryId, string searchString);

        #endregion Search

        #region SiteMap

        /// <summary>
        /// Obtiene una lista de la información existente para la generación del sitemap
        /// </summary>
        EntSiteMapUI[] GetShowSiteMap();

        #endregion SiteMap

        IBaseProduct BaseProduct { get; }

        IPropertyCategory PropertyCategory { get; }

        IPropertySubCategory PropertySubCategory { get; }

        IProperty Property { get; }
    }
}