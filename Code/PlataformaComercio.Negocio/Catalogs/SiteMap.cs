using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Entities.UI;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business.Catalogs
{
    public class SiteMap : Base
    {
         #region Private Fields
        ICatalogDA catalogDA;
        #endregion

        #region Constructors
        public SiteMap()
        {
            catalogDA = dataContainer.Resolve<ICatalogDA>();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Genera el sitemap a partir de la información existente
        /// </summary>
        /// <returns>Arreglo de <typeparamref name="EntSiteMapUI[]"/>EntSiteMapUI que contiene la información del sitemap</returns>
        public EntSiteMapUI[] GetAll()
        {
            var infoSiteMap = catalogDA.GetShowSiteMap();

            foreach (var item in infoSiteMap)
            {
                switch (item.Source)
                {
                    case 0:
                        item.Url = "/producto/detalleproducto/" + item.Url;
                        break;
                    case 1:
                        item.Url = String.Format("/marca/{0}/productos", item.Url);
                        break;
                    case 2:
                        //No se hace nada por que es un custom url
                        break;                    
                }
            }

            return infoSiteMap.ToArray();
        }
        #endregion

        
    }
}
