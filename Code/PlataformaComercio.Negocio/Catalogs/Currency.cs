using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using Microsoft.Practices.Unity;

namespace PlataformaComercio.Business.Catalogs
{
    public class Currency : Base
    {
        ICurrencyDA iCurrencyDA;
        public Currency()
        {
            iCurrencyDA = dataContainer.Resolve<ICurrencyDA>();
        }

        public Int32 Add(EntCurrency entCurrency)
        {
            Validate(entCurrency);
            return iCurrencyDA.Add(entCurrency);
        }

        public bool Update(EntCurrency entCurrency)
        {
            Validate(entCurrency);
            return iCurrencyDA.Update(entCurrency);
        }

        public EntCurrency GetByID(Int32 CurrencyId)
        {
            return iCurrencyDA.GetByID(CurrencyId);
        }

        public EntCurrency[] GetAll()
        {
            return iCurrencyDA.GetAll();
        }

        public bool Delete(Int32 CurrencyId)
        {
            return iCurrencyDA.Delete(CurrencyId);
        }

        private static void Validate(EntCurrency entCurrency)
        {
            Util.Validate<EntCurrency>(entCurrency);
        }

    }
}
