using System;
using System.Text;
using PlataformaComercio.Entities.Product;


namespace PlataformaComercio.Datos.Fachada.Catalog
{
    public interface IBaseProduct
	{
		String Add(EntBaseProduct entBaseProduct);

		bool Update(EntBaseProduct entBaseProduct);

        EntBaseProduct GetByID(String baseProductId);

		bool Delete(String BaseProductId);

	}
}
