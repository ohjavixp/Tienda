using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Basket;

namespace PlataformaComercio.Datos.Fachada
{
    public interface IBasketLineDA
    {
        int Add(Guid basketId,string name);
        EntBasketLine[] Get(Guid basketID);
        int AddProduct(EntBasketDetail entBasketDetail);
        EntBasketProduct GetProductBySku(Guid basketID,int lineID, string sku);
        EntBasketProduct[] GetProducts(Guid basketID, int lineID);
        void UpdateQuantity(Guid basketID, int lineID, int basketDetailID, decimal quantity, bool replaceValue);
        void RemoveProduct(Guid basketID, int lineID, string sku);
    }
}
