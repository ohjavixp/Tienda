using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlataformaComercio.Business.BasketManagement;
using PlataformaComercio.FrameWork.Configuracion;

namespace PlataformaComercio.Web.webcontrols
{
    public partial class ProductDisplay : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgAgregarCarrito_Command(object sender, CommandEventArgs e)
        {
            Basket basket = new Basket(BasketConfiguration.DefaultBasketName);
            if (basket.Lines.Count == 0)
                basket.Lines.Add("default");

            basket.Lines[0].AddProduct(e.CommandArgument.ToString(), 1);
            PrincipalBootstrap masterPage = Page.Master as PrincipalBootstrap;
            if (masterPage != null)
                masterPage.OnMessage(this, new FrameWork.Events.MessageEventArgs("Carrito de Compras","El producto se agrego al carrito de compras"));
        }
    }


}