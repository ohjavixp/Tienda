using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Business.Catalogs;

namespace PlataformaComercio.Business.BasketManagement
{   
    public class BasketLine:Base
    {
        #region Fields
        IBasketLineDA iBasketLineDA;
        Guid basketID;
        int lineID;
        string name;
        /// <summary>
        /// Monto total de la linea
        /// </summary>
        decimal total;
        /// <summary>
        /// Número de productos de la linea
        /// </summary>
        int totalProducts;
        /// <summary>
        /// Peso total de los productos de la linea
        /// </summary>
        decimal totalWeight;
        #endregion
        
        #region Constructors
        public BasketLine(IBasketLineDA iBasketLineDA,Guid basketID, int lineID,string name)
        {
            this.basketID = basketID;
            this.lineID = lineID;
            this.name = name;
            this.iBasketLineDA = iBasketLineDA;

            //Obtiene los productos para realizar calculos de totales
            GetProducts(true);
            
            
        }
        #endregion
        

        #region Properties
        public string Name { get { return name;} }
        internal int ID { get { return lineID; } }
        /// <summary>
        /// Número de productos de la linea
        /// </summary>
        public int TotalProducts
        {
            get
            {
                return totalProducts;
            }
        }

        /// <summary>
        /// Peso total de los productos de la linea
        /// </summary>
        public decimal TotalWeight
        {
            get
            {
                return totalWeight;
            }
        }

        /// <summary>
        /// Monto total de la linea
        /// </summary>
        public decimal Total
        {
            get
            {
                return total;
            }
        }

        #endregion      


        
        #region Public Methods
        /// <summary>
        /// Agregar un nuevo producto al carrito de compras utilizando el inventario predeterminado
        /// </summary>
        /// <param name="sku">Sku del producto</param>
        /// <param name="quantity">Cantidad a agregar</param>
        /// <returns>Id del registro que corresponde al producto</returns>
        public int AddProduct(string sku, decimal quantity)
        {
            return AddProduct(InventoryConfiguration.DefaultInventory, sku, quantity,false);
        }

        /// <summary>
        /// Agregar un nuevo producto al carrito de compras utilizando el inventario predeterminado.
        /// </summary>
        /// <param name="sku">Sku del producto</param>
        /// <param name="quantity">Cantidad a agregar</param>
        /// <param name="replaceQuantity">Especifica si el valor se reemplazará con el proporcionado en caso de que el producto se encuentre en el carrito</param>
        /// <returns>Id del registro que corresponde al producto</returns>
        public int AddProduct(string sku, decimal quantity,bool replaceQuantity)
        {
            return AddProduct(InventoryConfiguration.DefaultInventory, sku, quantity,replaceQuantity);
        }

        public int AddProduct(string inventoryID, string sku, decimal quantity, bool replaceQuantity)
        {
            EntBasketDetail entBasketDetail = new EntBasketDetail();
            entBasketDetail.BasketID = basketID;
            entBasketDetail.LineID = ID;
            entBasketDetail.InventoryID = inventoryID;
            entBasketDetail.Sku = sku;
            entBasketDetail.ProductCategoryID = null;
            entBasketDetail.Quantity = quantity;
            
            

            if (BasketConfiguration.AllowDuplicateProducts)
            {
                return iBasketLineDA.AddProduct(entBasketDetail);
            }
            else
            {
                EntBasketProduct entBasketProduct = GetProduct(sku);
                if (entBasketProduct != null)
                {
                    iBasketLineDA.UpdateQuantity(basketID, ID, entBasketProduct.BasketDetailID, quantity, replaceQuantity);
                    return entBasketDetail.BasketDetailID;
                }
                else
                    return iBasketLineDA.AddProduct(entBasketDetail);
            }
            
        }

        public void RemoveProduct(string sku)
        {
            iBasketLineDA.RemoveProduct(basketID, ID, sku);
        }

        public void UpdateQuantity(string sku,decimal quantity)
        {
            if (!BasketConfiguration.AllowZeroQuantity && quantity.Equals(0))
                throw new UserException("No puede poner una cantidad cero en el producto");


            EntBasketProduct entBasketProduct = GetProduct(sku);
            if (entBasketProduct != null)
            {
                iBasketLineDA.UpdateQuantity(basketID, ID, entBasketProduct.BasketDetailID, quantity,true);                
            }
        }

        public EntBasketProduct GetProduct(string sku)
        {
            return iBasketLineDA.GetProductBySku(basketID, ID, sku);
        }

        /// <summary>
        /// Obtiene todos los productos de la linea
        /// </summary>
        /// <param name="getProductInfo">True para obtener la información del producto y poder realizar los calculos para el total</param>
        /// <returns>Todos los productos activos de un línea<see cref="EntBasketProduct[]"/></returns>
        public EntBasketProduct[] GetProducts(bool getProductInfo)
        {
            EntBasketProduct[] entBasketProducts = iBasketLineDA.GetProducts(basketID, ID);

            if (!getProductInfo)
                return entBasketProducts;

            Currency currency = new Currency();
            var currencies = currency.GetAll();

            total = 0;
            totalProducts = 0;

            //Obtiene solo los productos que sigan en el catalogo
            List<EntBasketProduct> validatedProducts = new List<EntBasketProduct>();
            Inventory ctrlCatalog = new Inventory();            
            foreach (var item in entBasketProducts)
            {
                try
                {
                    item.Product = ctrlCatalog.GetProductByID(item.SKU);
                    item.Total = item.Product.Price * item.Quantity;
                    var currentCurrency = currencies.FirstOrDefault(c => c.CurrencyId.Equals(item.Product.CurrencyID));
                    total += (item.Total * currentCurrency.ExchangeRate);
                    totalProducts += Convert.ToInt32(item.Quantity);
                    totalWeight += item.Product.Weight * item.Quantity;
                    validatedProducts.Add(item);
                }
                catch (NotFoundException)
                {
                    this.RemoveProduct(item.SKU);
                }
                
            }
            return validatedProducts.ToArray();
            
        }
        #endregion




    }
}
