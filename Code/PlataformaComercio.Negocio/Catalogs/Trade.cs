using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.FrameWork.Exceptions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business.Catalogs
{
    public class Trade:Base
    {
        #region Private Fields
        ICatalogDA catalogDA;
        #endregion

        #region Constructors
        public Trade()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }
        #endregion

        #region Public Methods
        public EntTrade[] GetAll()
        {
            return catalogDA.GetAllTrades();
        }

        public int Add(EntTrade entTrade)
        {
            if (string.IsNullOrEmpty(entTrade.Name))
                throw new UserException("Debe proporcionar el nombre de la marca");
            
            return catalogDA.AddTrade(entTrade);
        }
        #endregion




        public bool Update(EntTrade entTrade)
        {
            if (string.IsNullOrEmpty(entTrade.Name))
                throw new UserException("Debe proporcionar el nombre de la marca");

            return catalogDA.UpdateTrade(entTrade);
        }

        public EntTrade GetByID(int tradeID)
        {
            return catalogDA.GetTradeByID(tradeID);
        }

        public EntTrade GetByName(string tradeName)
        {
            var trade = catalogDA.GetTradeByName(tradeName);
            if (trade == null)
                throw new NotFoundException("La marca " + tradeName + " no existe");
            
            return trade;
        }

        public void Delete(int tradeId)
        {
            catalogDA.DeleteTrade(tradeId);
        }
    }
}
