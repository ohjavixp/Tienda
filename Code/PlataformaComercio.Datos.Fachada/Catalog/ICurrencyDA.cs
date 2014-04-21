using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.Datos.Fachada.Catalog
{
    public interface ICurrencyDA
    {
        Int32 Add(EntCurrency entCurrency);

        bool Update(EntCurrency entCurrency);

        EntCurrency GetByID(Int32 CurrencyId);

        EntCurrency[] GetAll();

        bool Delete(Int32 CurrencyId);

    }
}
