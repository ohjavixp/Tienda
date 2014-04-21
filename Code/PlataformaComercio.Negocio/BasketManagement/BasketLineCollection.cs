using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.FrameWork.Configuracion;
using Microsoft.Practices.Unity;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Basket;

namespace PlataformaComercio.Business.BasketManagement
{
    public class BasketLineCollection : CollectionBase
    {

        #region Protected Fields

        #endregion

        #region Fields
        IBasketLineDA iBasketLineDA;
        Guid basketId;
        #endregion


        #region Private Methods
        private BasketLine GetByName(string name)
        {
            //TODO: Refactor
            for (int i = 0; i < List.Count; i++)
            {
                if (((BasketLine)List[i]).Name.Equals(name))
                    return List[i] as BasketLine;
            }

            return null;
        }
        #endregion

        public BasketLineCollection(Guid basketId)
        {
            IUnityContainer dataContainer = GeneralConfiguration.GetGeneralContainer();
            iBasketLineDA = dataContainer.Resolve<IBasketLineDA>();

            EntBasketLine[] entBasketLines = iBasketLineDA.Get(basketId);

            foreach (var item in entBasketLines)
            {
                BasketLine basketLine = new BasketLine(iBasketLineDA,basketId,item.LineID,item.Name);                
                List.Add(basketLine);
            }

            this.basketId = basketId;


        }

        public void Add(string name)
        {

            if (GetByName(name) != null)
                throw new Exception("Ya existe un elemento con el nombre " + name);

            int lineID = iBasketLineDA.Add(basketId, name);

            BasketLine basketLine = new BasketLine(iBasketLineDA, basketId,lineID,name);            
            List.Add(basketLine);

        }

        public BasketLine this[int index]
        {
            get
            {
                return List[index] as BasketLine;
            }
          
        }

        public BasketLine this[string name]
        {
            get
            {
                return GetByName(name);
            }
           
        }

    }
}
